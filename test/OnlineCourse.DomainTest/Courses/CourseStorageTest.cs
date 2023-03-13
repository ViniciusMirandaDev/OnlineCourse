using Bogus;
using Moq;
using OnlineCourse.Domain.Courses;
using OnlineCourse.DomainTest._Util;

namespace OnlineCourse.DomainTest.Courses
{
    public class CourseStorageTest
    {
        private CourseDto _courseDto;
        private Mock<ICourseRepository> _courseRepositoryMock;
        private CourseStorage _courseStorage;

        public CourseStorageTest()
        {
            var fakeData = new Faker();
            _courseDto = new CourseDto
            {
                Name = fakeData.Random.Words(),
                Description = fakeData.Lorem.Paragraph(),
                Workload = fakeData.Random.Double(50, 1000),
                TargetPublic = "Student",
                Value = fakeData.Random.Double(1000, 2000),
            };

            _courseRepositoryMock = new Mock<ICourseRepository>();
            _courseStorage = new CourseStorage(_courseRepositoryMock.Object);
        }

        [Fact]
        public void ShouldAddCourse()
        {
            _courseStorage.Storage(_courseDto);

            _courseRepositoryMock.Verify(r => r
                .Add(It.Is<Course>(c =>
                    c.Name == _courseDto.Name
                    && c.Description == _courseDto.Description
                 )
            ));
        }

        [Fact]
        public void ShouldNotInformInvalidTargetPublic()
        {
            var invalidTargetPublic = "Doctor";
            _courseDto.TargetPublic = invalidTargetPublic;

            Assert.Throws<ArgumentException>(() => _courseStorage.Storage(_courseDto))
                .WithMessage("Invalid target public");
        }
    }

    public interface ICourseRepository
    {
        void Add(Course course);
    }

    public class CourseStorage
    {
        private readonly ICourseRepository _courseRepository;
        public CourseStorage(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public void Storage(CourseDto courseDto)
        {
            Enum.TryParse(typeof(TargetPublic), courseDto.TargetPublic, out var targetPublic);

            if(targetPublic == null)
                throw new ArgumentException("Invalid target public");

            var course = new Course(
                courseDto.Name,
                courseDto.Description,
                courseDto.Workload,
                (TargetPublic)targetPublic,
                courseDto.Value);

            _courseRepository.Add(course);
        }
    }

    public class CourseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Workload { get; set; }
        public string TargetPublic { get; set; }
        public double Value { get; set; }
    }
}
