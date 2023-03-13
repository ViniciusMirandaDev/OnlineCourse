using ExpectedObjects;
using OnlineCourse.DomainTest._Util;
using Xunit.Abstractions;

namespace OnlineCourse.DomainTest.Cursos
{
    public class CourseTest : IDisposable
    {
        private readonly ITestOutputHelper _output;
        private readonly string _name;
        private readonly double _workload;
        private readonly TargetPublic _targetPublic;
        private readonly double _value;

        public CourseTest(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("Running builder");

            _name = "Basic tech";
            _workload = 88;
            _targetPublic = TargetPublic.Student;
            _value = 958;
        }

        public void Dispose()
        {
            _output.WriteLine("Running Disposer");
        }

        [Fact]
        public void ShouldCreateCourse()
        {
            var expected = new
            {
                Name = _name,
                Workload = _workload,
                TargetPublic = _targetPublic,
                Value = _value
            };

            var course = new Course(expected.Name, expected.Workload, expected.TargetPublic, expected.Value);

            expected.ToExpectedObject().ShouldMatch(course);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCourseNameBeInvalid(string invalidName)
        {
            Assert.Throws<ArgumentException>(() =>
                 new Course(invalidName, _workload, _targetPublic, _value))
                 .WithMessage("Invalid name");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void ShoulNotCourseHaveWorkloadLassThanOne(double invalidWorkload)
        {
            Assert.Throws<ArgumentException>(() =>
                new Course(_name, invalidWorkload, _targetPublic, _value))
                .WithMessage("Invalid workload");

        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void ShoulNotCourseHaveValueLassThanOne(double invalidValue)
        {
            Assert.Throws<ArgumentException>(() =>
                 new Course(_name, _workload, _targetPublic, invalidValue))
                 .WithMessage("Invalid value");
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
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Invalid name");

            if (workload < 1)
                throw new ArgumentException("Invalid workload");

            if (value < 1)
                throw new ArgumentException("Invalid value");

            Name = name;
            Workload = workload;
            TargetPublic = targetPublic;
            Value = value;
        }
    }
}
