using System;
using System.Collections.Generic;
using ACME.SchoolManagement.Core.Interfaces;
using ACME.SchoolManagement.Domain.Models;

namespace ACME.SchoolManagement.Infrastructure.Services
{
    public class StudentService : IStudentService
    {
        private readonly List<Student> _students = new List<Student>();

        public void RegisterStudent(string name, int age)
        {
            if (age < 18)
            {
                throw new ArgumentException("Only adults can be registered.");
            }

            var student = new Student(name, age);

            _students.Add(student);
        }

        public List<Student> GetAllStudents()
        {
            return _students;
        }

        public Student GetStudentByName(string name)
        {
            return _students.Find(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void EnrollStudentInCourse(string studentName, Course course)
        {
            var student = GetStudentByName(studentName);
            if (student == null)
            {
                throw new ArgumentException("Student not found.");
            }
            student.EnrollInCourse(course);
        }

        public void UnenrollStudentFromCourse(string studentName, Course course)
        {
            var student = GetStudentByName(studentName);
            if (student == null)
            {
                throw new ArgumentException("Student not found.");
            }
            student.UnenrollFromCourse(course);
        }

        public List<Course> GetEnrolledCourses(string studentName)
        {
            var student = GetStudentByName(studentName);
            if (student == null)
            {
                throw new ArgumentException("Student not found.");
            }
            return student.EnrolledCourses;
        }

        public void RemoveStudent(string name)
        {
            var student = GetStudentByName(name);
            if (student == null)
            {
                throw new ArgumentException("Student not found.");
            }
            _students.Remove(student);
        }
    }
}