namespace Isu.Tools
{
    public class ExceededMaxNumberOfStudentsException : Exception
    {
        public ExceededMaxNumberOfStudentsException(string message, int value)
            : base(message)
        {
            Value = value;
        }

        public int Value { get; }
    }
}
