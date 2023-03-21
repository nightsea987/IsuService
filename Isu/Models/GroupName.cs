using Isu.Tools;

namespace Isu.Models
{
    public record GroupName
    {
        private const int LengthOfGroupName = 5;

        public GroupName(string nameOfGroup)
        {
            ValidationCheck(nameOfGroup);
            NameOfGroup = nameOfGroup;
            NameOfFaculty = nameOfGroup[0];
            NumberOfGroup = int.Parse(nameOfGroup[3].ToString() + nameOfGroup[4].ToString());
            NumberOfCourse = new CourseNumber(int.Parse(nameOfGroup[2].ToString()));
        }

        public string NameOfGroup { get; }
        public char NameOfFaculty { get; }
        public int NumberOfGroup { get; }
        public CourseNumber NumberOfCourse { get; }

        public static bool ValidationCheck(string nameOfGroup)
        {
            if (string.IsNullOrWhiteSpace(nameOfGroup))
                throw new ArgumentNullException();

            if (nameOfGroup.Length != LengthOfGroupName)
                throw new InvalidGroupNameException("The length of group name should be 5", nameOfGroup.Length);

            if (!(char.IsDigit(nameOfGroup[1]) && char.IsDigit(nameOfGroup[2]) && char.IsDigit(nameOfGroup[3]) && char.IsDigit(nameOfGroup[4])))
                throw new InvalidGroupNameException("The group name should be M3___");

            if (nameOfGroup[1] != '3')
                throw new InvalidGroupNameException("The group name should be M3___");

            if (!CourseNumber.ValidationCheck(int.Parse(nameOfGroup[2].ToString())))
                throw new InvalidCourseNumberException("Ñourse number should be between 1 and 4", int.Parse(nameOfGroup[2].ToString()));

            return true;
        }
    }
}
