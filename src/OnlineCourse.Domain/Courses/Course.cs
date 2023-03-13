namespace OnlineCourse.Domain.Courses
{
    public class Course
    {
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public double Workload { get; private set; }
        public TargetPublic TargetPublic { get; private set; }
        public double Value { get; private set; }

        public Course(string name, string? description, double workload, TargetPublic targetPublic, double value)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Invalid name");

            if (workload < 1)
                throw new ArgumentException("Invalid workload");

            if (value < 1)
                throw new ArgumentException("Invalid value");

            Name = name;
            Description = description;
            Workload = workload;
            TargetPublic = targetPublic;
            Value = value;
        }
    }
}
