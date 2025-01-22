namespace Task4
{
    public class ElementChangedArgs<T> : EventArgs
    {
        public T? OldValue { get; set; }
        public T? NewValue { get; set; }
        public int Index { get; set; }
    }
}
