using System;
using System.Collections.Generic;
using ACME.SchoolManagement.Domain.Models;
using ACME.SchoolManagement.Core.Interfaces;

namespace ACME.SchoolManagement.Infrastructure.Services
{
    public class CourseService : ICourseService
    {
        private readonly List<Course> _courses;

        public CourseService()
        {
            _courses = new List<Course>();
        }

        public void RegisterCourse(string name, decimal enrollmentFee, DateTime startDate, DateTime endDate)
        {
            var course = new Course
            {
                Name = name,
                EnrollmentFee = enrollmentFee,
                StartDate = startDate,
                EndDate = endDate
            };
            _courses.Add(course);
        }

        public void EnrollStudentInCourse(string courseName, Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Student cannot be null.");
            }
            var course = _courses.Find(c => c.Name.Equals(courseName, StringComparison.OrdinalIgnoreCase));
            if (course != null)
            {
                course.AddStudent(student);
            }
        }

        public List<Course> GetCourses(DateTime startDate, DateTime endDate)
        {
            return _courses.FindAll(c => c.StartDate >= startDate && c.EndDate <= endDate);
        }

        public IReadOnlyList<Student> GetStudentsInCourse(string courseName)
        {
            var course = _courses.Find(c => c.Name.Equals(courseName, StringComparison.OrdinalIgnoreCase));
            return course?.GetEnrolledStudents() ?? new List<Student>();
        }

        public void UpdateCourse(string courseName, decimal enrollmentFee, DateTime startDate, DateTime endDate)
        {
            var course = _courses.Find(c => c.Name.Equals(courseName, StringComparison.OrdinalIgnoreCase));
            if (course != null)
            {
                course.EnrollmentFee = enrollmentFee;
                course.StartDate = startDate;
                course.EndDate = endDate;
            }
        }

        public void DeleteCourse(string courseName)
        {
            var course = _courses.Find(c => c.Name.Equals(courseName, StringComparison.OrdinalIgnoreCase));
            if (course != null)
            {
                _courses.Remove(course);
            }
        }

        public Course GetCourseByName(string courseName)
        {
            return _courses.Find(c => c.Name.Equals(courseName, StringComparison.OrdinalIgnoreCase));
        }

        public List<Course> GetAllCourses()
        {
            return _courses;
        }

        public void UnenrollStudentFromCourse(string courseName, Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Student cannot be null.");
            }
            var course = _courses.Find(c => c.Name.Equals(courseName, StringComparison.OrdinalIgnoreCase));
            if (course != null)
            {
                course.RemoveStudent(student);
            }
        }
    }
}