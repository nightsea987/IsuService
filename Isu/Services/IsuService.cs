using Isu.Entities;
using Isu.Models;
using Isu.Tools;

namespace Isu.Services
{
    public class IsuService : IIsuService
    {
        private List<Group> _listOfGroups;

        public IsuService()
        {
            _listOfGroups = new List<Group>();
        }

        public IReadOnlyList<Group> ListOfGroups => _listOfGroups.AsReadOnly();

        public Group? FindGroup(GroupName groupName)
        {
            return _listOfGroups.SingleOrDefault(s => s.NameOfGroup == groupName);
        }

        public Group AddGroup(GroupName name)
        {
            if (FindGroup(name) != null)
                throw new GroupAlreadyExistsException("Group with this name exists", name.NameOfGroup);

            var group = new Group(name);
            _listOfGroups.Add(group);
            return group;
        }

        public Student AddStudent(Group group, string name)
        {
            Student? studentCheck = _listOfGroups
                .SelectMany(g => g.ListOfStudents)
                .SingleOrDefault(s => (s.StudentGroup.NameOfGroup == group.NameOfGroup && s.Name == name));
            if (studentCheck != null)
                throw new StudentAlreadyInGroupException("Student with this name is already in group", name);

            var newStudent = new Student(name, group);
            group.AddToGroup(newStudent);
            return newStudent;
        }

        public Student GetStudent(int id)
        {
            Student? student = _listOfGroups.SelectMany(g => g.ListOfStudents).SingleOrDefault(s => s.Id == id);
            if (student == null)
                throw new StudentNotFoundException("Cannot get student by this id");
            return student;
        }

        public Student? FindStudent(int id)
        {
            return _listOfGroups.SelectMany(g => g.ListOfStudents).SingleOrDefault(s => s.Id == id);
        }

        public IReadOnlyList<Student> FindStudents(GroupName groupName)
        {
            if (groupName == null)
                throw new ArgumentNullException();

            return (IReadOnlyList<Student>)_listOfGroups.Where(g => g.NameOfGroup == groupName).SelectMany(s => s.ListOfStudents);
        }

        public IReadOnlyList<Student> FindStudents(CourseNumber courseNumber)
        {
            if (courseNumber == null)
                throw new ArgumentNullException();

            return (IReadOnlyList<Student>)_listOfGroups.Where(g => g.NameOfGroup.NumberOfCourse == courseNumber).SelectMany(s => s.ListOfStudents);
        }

        public IReadOnlyList<Group> FindGroups(CourseNumber courseNumber)
        {
            if (courseNumber == null)
                throw new ArgumentNullException();

            return (IReadOnlyList<Group>)_listOfGroups.Where(g => g.NameOfGroup.NumberOfCourse == courseNumber);
        }

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            if (student == null)
                throw new ArgumentNullException();

            if (newGroup == null)
                throw new ArgumentNullException();

            student.ChangeStudentGroup(newGroup);
        }
    }
}
