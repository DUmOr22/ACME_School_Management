using System;
using System.Collections.Generic;
using ACME.SchoolManagement.Domain.Models;

namespace ACME.SchoolManagement.Core.Interfaces
{
    public interface ICourseService
    {
        /// <summary>
        /// Registers a new course.
        /// </summary>
        /// <param name="name">The name of the course.</param>
        /// <param name="enrollmentFee">The enrollment fee for the course.</param>
        /// <param name="startDate">The start date of the course.</param>
        /// <param name="endDate">The end date of the course.</param>
        void RegisterCourse(string name, decimal enrollmentFee, DateTime startDate, DateTime endDate);

        /// <summary>
        /// Enrolls a student in a course.
        /// </summary>
        /// <param name="courseName">The name of the course.</param>
        /// <param name="student">The student to enroll.</param>
        void EnrollStudentInCourse(string courseName, Student student);

        /// <summary>
        /// Gets a list of courses within a specified date range.
        /// </summary>
        /// <param name="startDate">The start date of the range.</param>
        /// <param name="endDate">The end date of the range.</param>
        /// <returns>A list of courses within the specified date range.</returns>
        List<Course> GetCourses(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Gets a list of students enrolled in a specific course.
        /// </summary>
        /// <param name="courseName">The name of the course.</param>
        /// <returns>A read-only list of students enrolled in the course.</returns>
        IReadOnlyList<Student> GetStudentsInCourse(string courseName);

        /// <summary>
        /// Updates the details of an existing course.
        /// </summary>
        /// <param name="courseName">The name of the course.</param>
        /// <param name="enrollmentFee">The new enrollment fee for the course.</param>
        /// <param name="startDate">The new start date of the course.</param>
        /// <param name="endDate">The new end date of the course.</param>
        void UpdateCourse(string courseName, decimal enrollmentFee, DateTime startDate, DateTime endDate);

        /// <summary>
        /// Deletes a course by its name.
        /// </summary>
        /// <param name="courseName">The name of the course to delete.</param>
        void DeleteCourse(string courseName);

        /// <summary>
        /// Gets a course by its name.
        /// </summary>
        /// <param name="courseName">The name of the course.</param>
        /// <returns>The course with the specified name.</returns>
        Course GetCourseByName(string courseName);

        /// <summary>
        /// Gets all available courses.
        /// </summary>
        /// <returns>A list of all courses.</returns>
        List<Course> GetAllCourses();

        /// <summary>
        /// Unenrolls a student from a course.
        /// </summary>
        /// <param name="courseName">The name of the course.</param>
        /// <param name="student">The student to unenroll.</param>
        void UnenrollStudentFromCourse(string courseName, Student student);
    }
}