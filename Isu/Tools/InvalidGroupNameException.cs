namespace Isu.Tools
{
    public class InvalidGroupNameException : Exception
    {
        public InvalidGroupNameException(string message, int value)
            : base(message)
        {
            Value = value;
        }

        public InvalidGroupNameException(string message)
            : base(message)
        { }

        public int Value { get; }
    }
}
