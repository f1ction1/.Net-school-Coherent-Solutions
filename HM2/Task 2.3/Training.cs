namespace Task2
{
    internal class Training : TrainingEntity
    {
        private Lesson[] _lessons;
        public Lesson[] Lessons { get { return _lessons; } }
        public Training()
        {
            _lessons = null;
        }
        public Training(string description, Lesson[] lessons = null) : base(description) 
        {
            if (lessons != null && lessons.Length > 0)
            {
                _lessons = new Lesson[lessons.Length];
                Array.Copy(lessons,_lessons, _lessons.Length);
            } else
            {
                _lessons = null;
            }
        }
        public void Add(Lesson lesson)
        {
            if(Lessons != null)
            {
                Array.Resize(ref _lessons, _lessons.Length+1);
                _lessons[_lessons.Length - 1] = lesson;
            } else
            {
                _lessons = new Lesson[1] { lesson };
            }
        }
        public bool IsPractical()
        {
            if(Lessons != null)
            {
                foreach (var lesson in Lessons)
                {
                    if (!(lesson is PracticalLesson))
                        return false;
                }
                return true;
            }
            return false;   
        }
        public Training Clone()
        {
            Training tmp = new Training(this.Description);
            if (Lessons != null)
            {
                foreach(var lesson in Lessons)
                {
                    tmp.Add(lesson.Clone());
                }
            }
            return tmp;
        }
        public override string ToString()
        {
            string result = $"Training description: {Description}\n";
            if (Lessons != null)
            {
                result += "Lessons:\n";
                foreach(var i in  Lessons)
                {
                    result += $" - {i}\n";
                }    
            }
            return result;
        }
    }
}
