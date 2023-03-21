namespace Isu.Tools
{
    public class StudentNotFoundException : Exception
    {
        public StudentNotFoundException(string message)
            : base(message)
        { }
    }
}
