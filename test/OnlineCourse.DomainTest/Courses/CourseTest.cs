using Bogus;
using ExpectedObjects;
using OnlineCourse.Domain.Courses;
using OnlineCourse.DomainTest._Builders;
using OnlineCourse.DomainTest._Util;
using Xunit.Abstractions;

namespace OnlineCourse.DomainTest.Cursos
{
    public class CourseTest : IDisposable
    {
        private readonly ITestOutputHelper _output;
        private readonly string _name;
        private readonly string _description;
        private readonly double _workload;
        private readonly TargetPublic _targetPublic;
        private readonly double _value;

        public CourseTest(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("Running builder");

            var faker = new Faker();
            _name = faker.Random.Word();
            _description = faker.Lorem.Paragraph();
            _workload = faker.Random.Double(50, 1000);
            _targetPublic = TargetPublic.Student;
            _value = faker.Random.Double(50, 1000);
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
                Description = _description,
                Workload = _workload,
                TargetPublic = _targetPublic,
                Value = _value
            };

            var course = new Course(expected.Name, expected.Description, expected.Workload, expected.TargetPublic, expected.Value);

            expected.ToExpectedObject().ShouldMatch(course);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCourseNameBeInvalid(string invalidName)
        {
            Assert.Throws<ArgumentException>(() =>
                 CourseBuilder.New().WithName(invalidName).Build())
                 .WithMessage("Invalid name");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void ShouldNotCourseHaveWorkloadLassThanOne(double invalidWorkload)
        {
            Assert.Throws<ArgumentException>(() =>
                CourseBuilder.New().WithWorkload(invalidWorkload).Build())
                .WithMessage("Invalid workload");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void ShouldNotCourseHaveValueLassThanOne(double invalidValue)
        {
            Assert.Throws<ArgumentException>(() =>
                CourseBuilder.New().WithValue(invalidValue).Build())
                 .WithMessage("Invalid value");
        }
    }
}
