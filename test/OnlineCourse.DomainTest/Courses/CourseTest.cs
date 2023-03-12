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
                TargetPublic = TargetPublic.Student,
                Value = (double)958
            };
            //Act
            var course = new Course(expected.Name, expected.Workload, expected.TargetPublic, expected.Value);

            //Asserts
            expected.ToExpectedObject().ShouldMatch(course);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCourseNameBeInvalid(string invalidName)
        {
            var expected = new
            {
                Name = "Basic tech",
                Workload = (double)88,
                TargetPublic = TargetPublic.Student,
                Value = (double)958
            };

            Assert.Throws<ArgumentException>(() => 
                new Course(invalidName, expected.Workload, expected.TargetPublic, expected.Value));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void ShoulNotCourseHaveWorkloadLassThanOne(double invalidWorkload)
        {
            var expected = new
            {
                Name = "Basic tech",
                Workload = (double)88,
                TargetPublic = TargetPublic.Student,
                Value = (double)958
            };

            Assert.Throws<ArgumentException>(() =>
                new Course(expected.Name, invalidWorkload, expected.TargetPublic, expected.Value));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void ShoulNotCourseHaveValueLassThanOne(double invalidValue)
        {
            var expected = new
            {
                Name = "Basic tech",
                Workload = (double)88,
                TargetPublic = TargetPublic.Student,
                Value = (double)958
            };

            Assert.Throws<ArgumentException>(() =>
                new Course(expected.Name, expected.Workload, expected.TargetPublic, invalidValue));
        }
    }

    public enum TargetPublic
    {
        Student,
        CollegeStudent,
        Employee,
        Employer
    }

    public class Course
    {
        public string Name { get; private set; }
        public double Workload { get; private set; }
        public TargetPublic TargetPublic { get; private set; }
        public double Value { get; private set; }

        public Course(string name, double workload, TargetPublic targetPublic, double value)
        {
            if( string.IsNullOrEmpty(name))
                throw new ArgumentException();
            
            if(workload < 1 || value < 1)
                throw new ArgumentException();

            Name = name;
            Workload = workload;
            TargetPublic = targetPublic;
            Value = value;
        }
    }
}
