namespace OnlineCourse.DomainTest.Cursos
{
    public class CourseTest
    {
        [Fact]
        public void ShouldCreateCourse()
        {
            //Arrange
            const string name = "Basic tech";
            const double workload = 88;
            const string targetPublic = "Students";
            const double value = 958;

            //Act
            var course = new Course(name, workload, targetPublic, value);

            //Asserts
            Assert.Equal(name, course.Name);
            Assert.Equal(workload, course.Workload);
            Assert.Equal(targetPublic, course.TargetPublic);
            Assert.Equal(value, course.Value);
        }
    }

    public class Course
    {
        public string Name { get; private set; }
        public double Workload { get; private set; }
        public string TargetPublic { get; private set; }
        public double Value { get; private set; }

        public Course(string name, double workload, string targetPublic, double value)
        {
            Name = name;
            Workload = workload;
            TargetPublic = targetPublic;
            Value = value;
        }
    }
}
