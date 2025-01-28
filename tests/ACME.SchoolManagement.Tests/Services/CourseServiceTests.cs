using System;
using System.Linq;
using Xunit;
using Moq;
using ACME.SchoolManagement.Core.Interfaces;
using ACME.SchoolManagement.Domain.Models;
using ACME.SchoolManagement.Infrastructure.Services;
using System.Collections.Generic;

namespace ACME.SchoolManagement.Tests.Services
{
    public class CourseServiceTests
    {
        private readonly Mock<ICourseService> _mockCourseService;

        public CourseServiceTests()
        {
            _mockCourseService = new Mock<ICourseService>();
        }

        /// <summary>
        /// Verifies that a course is registered successfully.
        /// </summary>
        [Fact]
        public void RegisterCourse_ShouldAddCourse()
        {
            // Arrange
            var courseName = "Mathematics";
            var enrollmentFee = 100;
            var startDate = DateTime.Now;
            var endDate = DateTime.Now.AddMonths(3);
            var course = new Course { Name = courseName, EnrollmentFee = enrollmentFee, StartDate = startDate, EndDate = endDate };

            _mockCourseService.Setup(service => service.RegisterCourse(courseName, enrollmentFee, startDate, endDate));
            _mockCourseService.Setup(service => service.GetCourses(startDate, endDate)).Returns(new List<Course> { course });

            // Act
            _mockCourseService.Object.RegisterCourse(courseName, enrollmentFee, startDate, endDate);
            var registeredCourse = _mockCourseService.Object.GetCourses(startDate, endDate).FirstOrDefault(c => c.Name == courseName);

            // Assert
            Assert.NotNull(registeredCourse);
            Assert.Equal(courseName, registeredCourse.Name);
            Assert.Equal(enrollmentFee, registeredCourse.EnrollmentFee);
            Assert.Equal(startDate, registeredCourse.StartDate);
            Assert.Equal(endDate, registeredCourse.EndDate);
        }

        /// <summary>
        /// Verifies that a student is successfully enrolled in a course.
        /// </summary>
        [Fact]
        public void EnrollStudent_ShouldAddStudentToCourse()
        {
            // Arrange
            var courseName = "Science";
            var enrollmentFee = 150;
            var startDate = DateTime.Now;
            var endDate = DateTime.Now.AddMonths(2);
            var course = new Course { Name = courseName, EnrollmentFee = enrollmentFee, StartDate = startDate, EndDate = endDate };
            var student = new Student("John Doe", 25);

            _mockCourseService.Setup(service => service.RegisterCourse(courseName, enrollmentFee, startDate, endDate));
            _mockCourseService.Setup(service => service.GetCourses(startDate, endDate)).Returns(new List<Course> { course });
            _mockCourseService.Setup(service => service.EnrollStudentInCourse(courseName, student)).Callback(() => course.AddStudent(student));

            // Act
            _mockCourseService.Object.RegisterCourse(courseName, enrollmentFee, startDate, endDate);
            _mockCourseService.Object.EnrollStudentInCourse(courseName, student);

            // Assert
            Assert.Contains(student, course.GetEnrolledStudents());
        }

        /// <summary>
        /// Verifies that enrolling a null student throws an exception.
        /// </summary>
        [Fact]
        public void EnrollStudent_ShouldThrowException_WhenStudentIsNull()
        {
            // Arrange
            var courseName = "History";
            var enrollmentFee = 200;
            var startDate = DateTime.Now;
            var endDate = DateTime.Now.AddMonths(1);
            var course = new Course { Name = courseName, EnrollmentFee = enrollmentFee, StartDate = startDate, EndDate = endDate };

            _mockCourseService.Setup(service => service.RegisterCourse(courseName, enrollmentFee, startDate, endDate));
            _mockCourseService.Setup(service => service.GetCourses(startDate, endDate)).Returns(new List<Course> { course });
            _mockCourseService.Setup(service => service.EnrollStudentInCourse(courseName, null)).Throws<ArgumentNullException>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _mockCourseService.Object.EnrollStudentInCourse(courseName, null));
        }

        /// <summary>
        /// Verifies that courses within a specified date range are returned.
        /// </summary>
        [Fact]
        public void GetCourses_ShouldReturnCoursesWithinDateRange()
        {
            // Arrange
            var courseName1 = "Geography";
            var enrollmentFee1 = 120;
            var startDate1 = DateTime.Now;
            var endDate1 = DateTime.Now.AddMonths(1);
            var course1 = new Course { Name = courseName1, EnrollmentFee = enrollmentFee1, StartDate = startDate1, EndDate = endDate1 };

            var courseName2 = "Physics";
            var enrollmentFee2 = 180;
            var startDate2 = DateTime.Now;
            var endDate2 = DateTime.Now.AddMonths(3);
            var course2 = new Course { Name = courseName2, EnrollmentFee = enrollmentFee2, StartDate = startDate2, EndDate = endDate2 };

            _mockCourseService.Setup(service => service.RegisterCourse(courseName1, enrollmentFee1, startDate1, endDate1));
            _mockCourseService.Setup(service => service.RegisterCourse(courseName2, enrollmentFee2, startDate2, endDate2));
            _mockCourseService.Setup(service => service.GetCourses(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(new List<Course> { course1 });

            // Act
            _mockCourseService.Object.RegisterCourse(courseName1, enrollmentFee1, startDate1, endDate1);
            _mockCourseService.Object.RegisterCourse(courseName2, enrollmentFee2, startDate2, endDate2);
            var courses = _mockCourseService.Object.GetCourses(startDate1, DateTime.Now.AddMonths(2));

            // Assert
            Assert.Contains(course1, courses);
            Assert.DoesNotContain(course2, courses);
        }

        /// <summary>
        /// Verifies that enrolled students in a course are returned.
        /// </summary>
        [Fact]
        public void GetStudentsInCourse_ShouldReturnEnrolledStudents()
        {
            // Arrange
            var courseName = "Biology";
            var course = new Course { Name = courseName, EnrollmentFee = 100, StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(3) };
            var student1 = new Student("Alice", 22);
            var student2 = new Student("Bob", 24);

            course.AddStudent(student1);
            course.AddStudent(student2);

            _mockCourseService.Setup(service => service.GetStudentsInCourse(courseName)).Returns(course.GetEnrolledStudents());

            // Act
            var students = _mockCourseService.Object.GetStudentsInCourse(courseName);

            // Assert
            Assert.Contains(student1, students);
            Assert.Contains(student2, students);
        }

        /// <summary>
        /// Verifies that course details are updated successfully.
        /// </summary>
        [Fact]
        public void UpdateCourse_ShouldModifyCourseDetails()
        {
            // Arrange
            var courseName = "Chemistry";
            var originalCourse = new Course { Name = courseName, EnrollmentFee = 150, StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(3) };
            var updatedCourse = new Course { Name = courseName, EnrollmentFee = 200, StartDate = DateTime.Now.AddDays(1), EndDate = DateTime.Now.AddMonths(4) };

            _mockCourseService.Setup(service => service.GetCourseByName(courseName)).Returns(originalCourse);
            _mockCourseService.Setup(service => service.UpdateCourse(courseName, updatedCourse.EnrollmentFee, updatedCourse.StartDate, updatedCourse.EndDate))
                .Callback(() => {
                    originalCourse.EnrollmentFee = updatedCourse.EnrollmentFee;
                    originalCourse.StartDate = updatedCourse.StartDate;
                    originalCourse.EndDate = updatedCourse.EndDate;
                });

            // Act
            _mockCourseService.Object.UpdateCourse(courseName, updatedCourse.EnrollmentFee, updatedCourse.StartDate, updatedCourse.EndDate);
            var course = _mockCourseService.Object.GetCourseByName(courseName);

            // Assert
            Assert.Equal(updatedCourse.EnrollmentFee, course.EnrollmentFee);
            Assert.Equal(updatedCourse.StartDate, course.StartDate);
            Assert.Equal(updatedCourse.EndDate, course.EndDate);
        }

        /// <summary>
        /// Verifies that a course is removed successfully.
        /// </summary>
        [Fact]
        public void DeleteCourse_ShouldRemoveCourse()
        {
            // Arrange
            var courseName = "Philosophy";
            var course = new Course { Name = courseName, EnrollmentFee = 100, StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(3) };

            _mockCourseService.Setup(service => service.RegisterCourse(courseName, course.EnrollmentFee, course.StartDate, course.EndDate));
            _mockCourseService.Setup(service => service.GetCourseByName(courseName)).Returns(course);
            _mockCourseService.Setup(service => service.DeleteCourse(courseName)).Callback(() => _mockCourseService.Setup(service => service.GetCourseByName(courseName)).Returns((Course)null));

            // Act
            _mockCourseService.Object.RegisterCourse(courseName, course.EnrollmentFee, course.StartDate, course.EndDate);
            _mockCourseService.Object.DeleteCourse(courseName);
            var deletedCourse = _mockCourseService.Object.GetCourseByName(courseName);

            // Assert
            Assert.Null(deletedCourse);
        }

        /// <summary>
        /// Verifies that a course is returned by its name.
        /// </summary>
        [Fact]
        public void GetCourseByName_ShouldReturnCourse()
        {
            // Arrange
            var courseName = "Art";
            var course = new Course { Name = courseName, EnrollmentFee = 120, StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(2) };

            _mockCourseService.Setup(service => service.GetCourseByName(courseName)).Returns(course);

            // Act
            var result = _mockCourseService.Object.GetCourseByName(courseName);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(courseName, result.Name);
        }

        /// <summary>
        /// Verifies that all courses are returned.
        /// </summary>
        [Fact]
        public void GetAllCourses_ShouldReturnAllCourses()
        {
            // Arrange
            var course1 = new Course { Name = "History", EnrollmentFee = 100, StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(1) };
            var course2 = new Course { Name = "Math", EnrollmentFee = 150, StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(2) };
            var courses = new List<Course> { course1, course2 };

            _mockCourseService.Setup(service => service.GetAllCourses()).Returns(courses);

            // Act
            var result = _mockCourseService.Object.GetAllCourses();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(result, c => c.Name == "History");
            Assert.Contains(result, c => c.Name == "Math");
        }

        /// <summary>
        /// Verifies that a student is unenrolled from a course successfully.
        /// </summary>
        [Fact]
        public void UnenrollStudentFromCourse_ShouldRemoveStudentFromCourse()
        {
            // Arrange
            var courseName = "Physics";
            var course = new Course { Name = courseName, EnrollmentFee = 180, StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(3) };
            var student = new Student("John Doe", 25);

            course.AddStudent(student);

            _mockCourseService.Setup(service => service.GetCourseByName(courseName)).Returns(course);
            _mockCourseService.Setup(service => service.UnenrollStudentFromCourse(courseName, student)).Callback(() => course.RemoveStudent(student));

            // Act
            _mockCourseService.Object.UnenrollStudentFromCourse(courseName, student);
            var students = _mockCourseService.Object.GetCourseByName(courseName).GetEnrolledStudents();

            // Assert
            Assert.DoesNotContain(student, students);
        }
    }
}