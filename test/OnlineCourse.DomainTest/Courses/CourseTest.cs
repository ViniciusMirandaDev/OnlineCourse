using ExpectedObjects;

namespace OnlineCourse.DomainTest.Cursos
{
    public class CourseTest
    {
        [Fact]
        public void ShouldCreateCourse()
        {
            //Arrange
            var expected = new
            {
                Name = "Basic tech",
                Workload = (double)88,
                TargetPublic = "Students",
                Value = (double)958
            };
            //Act
            var course = new Course(expected.Name, expected.Workload, expected.TargetPublic, expected.Value);

            //Asserts
            expected.ToExpectedObject().ShouldMatch(course);
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
