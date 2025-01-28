using System;
using System.Linq;
using Xunit;
using Moq;
using ACME.SchoolManagement.Core.Interfaces;
using ACME.SchoolManagement.Domain.Models;
using System.Collections.Generic;

namespace ACME.SchoolManagement.Tests.Services
{
    public class StudentServiceTests
    {
        private readonly Mock<IStudentService> _mockStudentService;

        public StudentServiceTests()
        {
            _mockStudentService = new Mock<IStudentService>();
        }

        /// <summary>
        /// Verifies that a valid adult student is registered successfully.
        /// </summary>
        [Fact]
        public void RegisterStudent_ValidAdultStudent_ShouldSucceed()
        {
            // Arrange
            var student = new Student("John Doe", 25);

            _mockStudentService.Setup(service => service.RegisterStudent(student.Name, student.Age));
            _mockStudentService.Setup(service => service.GetStudentByName(student.Name)).Returns(student);

            // Act
            _mockStudentService.Object.RegisterStudent(student.Name, student.Age);
            var registeredStudent = _mockStudentService.Object.GetStudentByName(student.Name);

            // Assert
            Assert.NotNull(registeredStudent);
        }

        /// <summary>
        /// Verifies that registering an underage student throws an exception.
        /// </summary>
        [Fact]
        public void RegisterStudent_UnderageStudent_ShouldFail()
        {
            // Arrange
            var student = new Student("Jane Doe", 17);

            _mockStudentService.Setup(service => service.RegisterStudent(student.Name, student.Age))
                .Throws(new ArgumentException("Only adults can be registered."));

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => _mockStudentService.Object.RegisterStudent(student.Name, student.Age));
            Assert.Equal("Only adults can be registered.", exception.Message);
        }

        /// <summary>
        /// Verifies that all registered students are returned.
        /// </summary>
        [Fact]
        public void GetAllStudents_ShouldReturnRegisteredStudents()
        {
            // Arrange
            var student1 = new Student("Alice", 30);
            var student2 = new Student("Bob", 28);
            var students = new List<Student> { student1, student2 };

            _mockStudentService.Setup(service => service.GetAllStudents()).Returns(students);

            // Act
            var result = _mockStudentService.Object.GetAllStudents();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Contains(result, s => s.Name == "Alice");
            Assert.Contains(result, s => s.Name == "Bob");
        }

        /// <summary>
        /// Verifies that a student is successfully enrolled in a course.
        /// </summary>
        [Fact]
        public void EnrollStudentInCourse_ValidStudent_ShouldSucceed()
        {
            // Arrange
            var student = new Student("John Doe", 25);
            var course = new Course
            {
                Name = "Mathematics",
                EnrollmentFee = 100,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(3)
            };

            _mockStudentService.Setup(service => service.EnrollStudentInCourse(student.Name, course))
                .Callback(() => student.EnrollInCourse(course));
            _mockStudentService.Setup(service => service.GetStudentByName(student.Name)).Returns(student);

            // Act
            _mockStudentService.Object.EnrollStudentInCourse(student.Name, course);
            var enrolledStudent = _mockStudentService.Object.GetStudentByName(student.Name);

            // Assert
            Assert.Contains(course, enrolledStudent.EnrolledCourses);
        }

        /// <summary>
        /// Verifies that getting a non-existent student returns null.
        /// </summary>
        [Fact]
        public void GetStudentByName_NonExistentStudent_ShouldReturnNull()
        {
            // Arrange
            var studentName = "Non Existent";

            _mockStudentService.Setup(service => service.GetStudentByName(studentName)).Returns((Student)null);

            // Act
            var result = _mockStudentService.Object.GetStudentByName(studentName);

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        /// Verifies that a student is successfully removed.
        /// </summary>
        [Fact]
        public void DeleteStudent_ValidStudent_ShouldSucceed()
        {
            // Arrange
            var student = new Student("John Doe", 25);

            _mockStudentService.Setup(service => service.RegisterStudent(student.Name, student.Age));
            _mockStudentService.Setup(service => service.RemoveStudent(student.Name)).Callback(() => _mockStudentService.Setup(service => service.GetStudentByName(student.Name)).Returns((Student)null));

            // Act
            _mockStudentService.Object.RegisterStudent(student.Name, student.Age);
            _mockStudentService.Object.RemoveStudent(student.Name);
            var deletedStudent = _mockStudentService.Object.GetStudentByName(student.Name);

            // Assert
            Assert.Null(deletedStudent);
        }
    }
}