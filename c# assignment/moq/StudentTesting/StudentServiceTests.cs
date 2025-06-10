using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using StudentTest.Business_Logic;
using StudentTest.Domain;
using StudentTest.Repository;

namespace StudentTesting
{
    [TestFixture]   
    class StudentServiceTests
    {
        private Mock<IStudentRepository> _mock;
        private StudentService _service;

        [SetUp]
        public void SetUp()
        {
            _mock= new Mock<IStudentRepository>();
            _service=new StudentService(_mock.Object);
        }
        [Test]
        public void AddStudent_Should_Call_Repository_Add()
        {
            var student = new Student
            {
                RollNo = 1,
                Name = "John",
                Email = "jogn@gmail.com"
            };
            _service.AddStudent(student);
            _mock.Verify(r=>r.Add(student),Times.Once);

        }
        [Test]
        public void GetAllStudents_Should_Return_List_From_Repository()
        {
            var students = new List<Student>
            {
                new Student { RollNo = 1, Name = "Alice", Email = "alice@example.com" }
            };

            _mock.Setup(r => r.GetAll()).Returns(students);

            var result = _service.GetAllStudents();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Name, Is.EqualTo("Alice"));
        }

        [Test]
        public void GetStudentByRollNo_Should_Return_Student()
        {
            var student = new Student { RollNo = 2, Name = "Bob", Email = "bob@example.com" };
            _mock.Setup(r => r.GetByRollNo(2)).Returns(student);

            var result = _service.GetStudentByRollNo(2);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo("Bob"));
        }

        [Test]
        public void DeleteStudent_Should_Call_Repository_Delete()
        {
            _service.DeleteStudent(1);

            _mock.Verify(r => r.Delete(1), Times.Once);
        }

        [Test]
        public void UpdateStudent_Should_Call_Repository_Update()
        {
            var student = new Student { RollNo = 3, Name = "Charlie", Email = "charlie@example.com" };

            _service.UpdateStudent(student);

            _mock.Verify(r => r.Update(student), Times.Once);
        }


    }
}
