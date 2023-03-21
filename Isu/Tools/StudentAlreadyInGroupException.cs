namespace Isu.Tools
{
    public class StudentAlreadyInGroupException : Exception
    {
        public StudentAlreadyInGroupException(string message, string value)
            : base(message)
        {
            Value = value;
        }

        public string Value { get; }
    }
}
