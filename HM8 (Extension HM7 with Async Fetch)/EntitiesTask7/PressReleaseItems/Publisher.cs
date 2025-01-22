using Task7.Task7.EntitiesTask7.PressReleaseItems.Interfaces;

namespace Task7.Task7.EntitiesTask7.PressReleaseItems
{
    public class Publisher : IPressReleaseItem
    {
        public string Value { get; set; }
        public Publisher()
        {
            Value = string.Empty;
        }
        public Publisher(string value)
        {
            Value = value;
        }
        public override string ToString()
        {
            return $"Publisher: {Value}";
        }
    }
}
