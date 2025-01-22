using Task7.Task7.EntitiesTask7.PressReleaseItems.Interfaces;

namespace Task7.Task7.EntitiesTask7.PressReleaseItems
{
    public class ElectronicFormat : IPressReleaseItem
    {
        public string Value { get; set; }
        public ElectronicFormat()
        {
            Value = string.Empty;
        }
        public ElectronicFormat(string value)
        {
            Value = value;
        }
        public override string ToString()
        {
            return $"ElectronicFormat: {Value}";
        }
        public override bool Equals(object? obj)
        {
            var elForamt = obj as ElectronicFormat;
            if(elForamt == null) 
            {
                throw new NullReferenceException();
            }
            return Value.Equals(elForamt.Value);
        }
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
