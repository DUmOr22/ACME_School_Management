using System;
using System.Collections.Generic;

namespace ACME.SchoolManagement.Domain.Models
{
    public class Student
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public List<Course> EnrolledCourses { get; private set; }

        public Student(string name, int age)
        {

            Name = name;
            Age = age;
            EnrolledCourses = new List<Course>();
        }

        public void EnrollInCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            if (EnrolledCourses == null)
            {
                EnrolledCourses = new List<Course>();
            }

            if (EnrolledCourses.Contains(course))
            {
                throw new InvalidOperationException("Student is already enrolled in this course.");
            }

            EnrolledCourses.Add(course);
        }

        public void UnenrollFromCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }
            EnrolledCourses.Remove(course);
        }
    }
}