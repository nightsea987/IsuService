using Isu.Entities;
using Isu.Models;
using Isu.Tools;
using Xunit;

namespace Isu.Test
{
    public class IsuServiceTest
    {
        private Isu.Services.IsuService _service;
        public IsuServiceTest()
        {
            _service = new Isu.Services.IsuService();
        }

        [Fact]
        public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
        {
            var newGroup = new Group(new GroupName("M3205"));
            Student newStudent1 = _service.AddStudent(newGroup, "Yarik");
            Student newStudent2 = _service.AddStudent(newGroup, "Pasha");
            Assert.True(newStudent1.StudentGroup.NameOfGroup == newGroup.NameOfGroup);
            Assert.True(newStudent2.StudentGroup.NameOfGroup == newGroup.NameOfGroup);
            Assert.Contains(newStudent1, newGroup.ListOfStudents);
            Assert.Contains(newStudent2, newGroup.ListOfStudents);
        }

        [Fact]
        public void ReachMaxStudentPerGroup_ThrowException()
        {
            Assert.Throws<ExceededMaxNumberOfStudentsException>(() =>
            {
                var newGroup = new Group(new GroupName("M3204"));
                for (int i = 0; i < Group.GetMaxNumberOfStudents(); i++)
                    _service.AddStudent(newGroup, i.ToString());
                _service.AddStudent(newGroup, "Sasha");
            });
        }

        [Fact]
        public void CreateGroupWithInvalidName_ThrowException()
        {
            Assert.Throws<InvalidGroupNameException>(() =>
            {
                var newGroup = new Group(new GroupName("M4205"));
                var newGroup2 = new Group(new GroupName("R3205"));
                var newGroup3 = new Group(new GroupName("R320509"));
                var newGroup4 = new Group(new GroupName("R320p"));
            });
        }

        [Fact]
        public void TransferStudentToAnotherGroup_GroupChanged()
        {
            var newGroup = new Group(new GroupName("M3205"));
            var newNewGroup = new Group(new GroupName("M3202"));
            Student newStudent = _service.AddStudent(newGroup, "Sasha");
            Assert.True(newStudent.StudentGroup.NameOfGroup == newGroup.NameOfGroup);
            newStudent.ChangeStudentGroup(newNewGroup);
            Assert.True(newStudent.StudentGroup.NameOfGroup == newNewGroup.NameOfGroup);
        }
    }
}