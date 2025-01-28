using ACME.SchoolManagement.Domain.Models;
using System;
using System.Collections.Generic;
public class Course
{
    public string Name { get; set; }
    public decimal EnrollmentFee { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    private List<Student> enrolledStudents;

    public Course()
    {
        enrolledStudents = new List<Student>();
    }

    public void AddStudent(Student student)
    {
        if (student == null)
        {
            throw new ArgumentNullException(nameof(student), "Student cannot be null.");
        }

        if (enrolledStudents.Contains(student))
        {
            throw new InvalidOperationException("Student is already enrolled in this course.");
        }

        enrolledStudents.Add(student);
    }

    public IReadOnlyList<Student> GetEnrolledStudents()
    {
        return enrolledStudents.AsReadOnly();
    }

    public void RemoveStudent(Student student)
    {
        if (student == null)
        {
            throw new ArgumentNullException(nameof(student), "Student cannot be null.");
        }
        enrolledStudents.Remove(student);
    }
}