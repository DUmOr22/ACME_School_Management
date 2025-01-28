using ACME.SchoolManagement.Domain.Models;
using System.Collections.Generic;

namespace ACME.SchoolManagement.Core.Interfaces
{
    public interface IStudentService
    {
        /// <summary>
        /// Registers a new student.
        /// </summary>
        /// <param name="name">The name of the student.</param>
        /// <param name="age">The age of the student.</param>
        /// <exception cref="ArgumentException">Thrown when the student is underage.</exception>
        void RegisterStudent(string name, int age);

        /// <summary>
        /// Gets all registered students.
        /// </summary>
        /// <returns>A list of all students.</returns>
        List<Student> GetAllStudents();

        /// <summary>
        /// Gets a student by their name.
        /// </summary>
        /// <param name="name">The name of the student.</param>
        /// <returns>The student with the specified name, or null if not found.</returns>
        Student GetStudentByName(string name);

        /// <summary>
        /// Enrolls a student in a course.
        /// </summary>
        /// <param name="studentName">The name of the student.</param>
        /// <param name="course">The course to enroll the student in.</param>
        void EnrollStudentInCourse(string studentName, Course course);

        /// <summary>
        /// Unenrolls a student from a course.
        /// </summary>
        /// <param name="studentName">The name of the student.</param>
        /// <param name="course">The course to unenroll the student from.</param>
        void UnenrollStudentFromCourse(string studentName, Course course);

        /// <summary>
        /// Gets the courses a student is enrolled in.
        /// </summary>
        /// <param name="studentName">The name of the student.</param>
        /// <returns>A list of courses the student is enrolled in.</returns>
        List<Course> GetEnrolledCourses(string studentName);

        /// <summary>
        /// Removes a student by their name.
        /// </summary>
        /// <param name="name">The name of the student to remove.</param>
        void RemoveStudent(string name);
    }
}