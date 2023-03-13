using OnlineCourse.DomainTest.Cursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourse.DomainTest._Builders
{
    public class CourseBuilder
    {
        private string _name = "Basic tech";
        public string _description = "Basic description";
        private double _workload = 88;
        private TargetPublic _targetPublic = TargetPublic.Student;
        private double _value = 958;

        public static CourseBuilder New()
        {
            return new CourseBuilder();
        }

        public CourseBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public CourseBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public CourseBuilder WithWorkload(double workload)
        {
            _workload = workload;
            return this;
        }

        public CourseBuilder WithValue(double value)
        {
            _value = value;
            return this;
        }

        public CourseBuilder WithTargetPublic(TargetPublic targetPublic)
        {
            _targetPublic = targetPublic;
            return this;
        }

        public Course Build()
        {
            return new Course(_name, _description, _workload, _targetPublic, _value);
        }
    }
}
