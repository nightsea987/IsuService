namespace Isu.Tools
{
    public class GroupAlreadyExistsException : Exception
    {
        public GroupAlreadyExistsException(string message, string value)
            : base(message)
        {
            Value = value;
        }

        public string Value { get; }
    }
}
