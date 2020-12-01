using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using CourseManagement.Library.Data.Entities;
using Moq;
using System.Collections.Generic;
using System.Linq;
using CourseManagement.Library.Data;
using System.Diagnostics.CodeAnalysis;

namespace CourseManagement.Test
{
    [ExcludeFromCodeCoverage]
    public class Tests
    {
        private IRepository<Enrollment, Guid> _repo;
        private Enrollment _enrollment;
        private List<Enrollment> _enrollmentList;
        
        [SetUp]
        public void Setup()
        {
            var studentId = Guid.NewGuid();
            var courseId = Guid.NewGuid();
            var repositoryMock = new Mock<IRepository<Enrollment, Guid>>();
            _enrollment = new Enrollment() { StudentId = studentId, CourseId = courseId };
            _enrollmentList = new List<Enrollment> { _enrollment };
            repositoryMock.Setup(r => r.Add(_enrollment));
            repositoryMock.Setup(r => r.Get()).Returns(() => _enrollmentList.AsQueryable());
            repositoryMock.Setup(r => r.Get(_enrollment.Id)).Returns(_enrollment);
            _repo = repositoryMock.Object;
        }

        [Test]
        //[TestCase("44F4EE51-65BA-4493-9676-9CEDF7F53F00", "44F4EE51-65BA-4493-9676-9CEDF7F53F01")]
        public void EnrollmentRepository_Add_AddSuccessfull()
        {
            //arrange   
            
            //act 
            _repo.Add(_enrollment);
            var actualList = _repo.Get().ToList();
            var actualEnrollment = actualList.First();

            //assert
            Assert.Contains(_enrollment, actualList);
            Assert.AreSame(_enrollment, actualEnrollment);
            Assert.AreEqual(_enrollment.StudentId, actualEnrollment.StudentId);
            Assert.AreEqual(_enrollment.CourseId, actualEnrollment.CourseId);
        }
    }
}