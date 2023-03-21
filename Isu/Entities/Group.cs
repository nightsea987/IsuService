using Isu.Models;
using Isu.Tools;

namespace Isu.Entities
{
    public class Group
    {
        private const int MaxNumberOfStudents = 30;
        private List<Student> _listOfStudents;

        public Group(GroupName nameOfGroup)
        {
            if (nameOfGroup == null)
                throw new ArgumentNullException();

            _listOfStudents = new List<Student>();
            NameOfGroup = nameOfGroup;
        }

        public GroupName NameOfGroup { get; }

        public IReadOnlyList<Student> ListOfStudents => _listOfStudents.AsReadOnly();

        public static int GetMaxNumberOfStudents()
        {
            return MaxNumberOfStudents;
        }

        public void DeleteFromGroup(Student student)
        {
            if (student == null)
                throw new ArgumentNullException();

            if (_listOfStudents.Count == 0)
                throw new Exception();

            if (_listOfStudents.Find(x => x.Id == student.Id) == null)
                throw new StudentNotFoundException("Cannot delete student because he's not found");

            _listOfStudents.Remove(student);
        }

        public void AddToGroup(Student student)
        {
            if (student == null)
                throw new ArgumentNullException();

            if (_listOfStudents.Find(x => x.Id == student.Id) != null)
                throw new StudentAlreadyInGroupException("Student with this name is already in group", student.Name);

            if (_listOfStudents.Count + 1 > MaxNumberOfStudents)
                throw new ExceededMaxNumberOfStudentsException("Maximum number of students exceeded", MaxNumberOfStudents);

            _listOfStudents.Add(student);
        }
    }
}
