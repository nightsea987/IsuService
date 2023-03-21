using Isu.Tools;

namespace Isu.Models
{
    public record CourseNumber
    {
        public int NumberOfCourse { get; }
        private const int _minCourseNumber = 1;
        private const int _maxCourseNumber = 4;

        public CourseNumber(int numberOfCourse)
        {
            if (!ValidationCheck(numberOfCourse))
                throw new InvalidCourseNumberException("Course number should be between 1 and 4", numberOfCourse);
            NumberOfCourse = numberOfCourse;
        }

        public static bool ValidationCheck(int numberOfCourse)
        {
            return numberOfCourse >= _minCourseNumber && numberOfCourse <= _maxCourseNumber;
        }
    }
}
