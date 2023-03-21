namespace Isu.Tools
{
    public class InvalidCourseNumberException : Exception
    {
        public InvalidCourseNumberException(string message, int value)
            : base(message)
        {
            Value = value;
        }

        public int Value { get; }
    }
}
