namespace Isu.Entities
{
    public class Student
    {
        private static int id = 100000;

        public Student(string name, Group group)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException();

            if (group == null)
                throw new ArgumentNullException();

            Id = ++id;
            Name = name;
            StudentGroup = group;
        }

        public int Id { get; }

        public string Name { get; }

        public Group StudentGroup { get; private set; }

        public void ChangeStudentGroup(Group newGroup)
        {
            newGroup.AddToGroup(this);
            StudentGroup.DeleteFromGroup(this);
            StudentGroup = newGroup;
        }
    }
}
