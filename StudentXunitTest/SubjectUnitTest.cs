using Moq;
using StudentAPI.Controllers;
using StudentAPI.Models;
using StudentAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentXunitTest
{
    public class SubjectUnitTest
    {

        private readonly Mock<ISubjectRepository> testSubject;
        public SubjectUnitTest()
        {
            testSubject = new Mock<ISubjectRepository>();
        }
        [Fact]
        public void GetSubjects_Return_Result()
        {
            //Arrange
            var subjectList = GetSubjectsData();
            testSubject.Setup(s => s.GetSubjects()).Returns(subjectList);
            var subjectController = new SubjectController(testSubject.Object);

            //Act
            var Result = subjectController.GetSubjects();

            //Assert
            Assert.NotNull(Result);
            Assert.Equal(GetSubjectsData().Count(), Result.Count());
            Assert.True(subjectList.Equals(Result));
            Assert.Equal(GetSubjectsData().ToString(), Result.ToString());
        }

        [Fact]
        public void GetSubjects_CheckCount_ReturnResult()
        {
            //Arrange
            var subjectList = GetSubjectsData();
            testSubject.Setup(s => s.GetSubjects()).Returns(subjectList);
            var subjectController = new SubjectController(testSubject.Object);

            //Act
            var Result = subjectController.GetSubjects();

            //Assert
            Assert.Equal(GetSubjectsData().Count(), Result.Count());
            Assert.True(subjectList.Equals(Result));
            
        }


        [Fact]
        public void SubjectList_GetById_ReturnResult()
        {
            //Arrange
            var subjectList = GetSubjectsData();
            testSubject.Setup(s => s.GetSubjectById(2)).Returns(subjectList[1]);
            var subjectController = new SubjectController(testSubject.Object);

            //Act
            var Result = subjectController.GetSubjectById(2);

            //Assert
            Assert.NotNull(Result);
            Assert.Equal(subjectList[1].SubId, Result.SubId);
            Assert.True(subjectList[1].SubId == Result.SubId);
        }

        [Fact]
        public void CheckAddSubject_ReturnResult()
        {
            //Arrange
            var subjectList = GetSubjectsData();
            testSubject.Setup(s => s.AddSubject(subjectList[1])).Returns(subjectList[1]);
            var subjectController = new SubjectController(testSubject.Object);


            //Act
            var subjectResult = subjectController.AddSubject(subjectList[1]);

            //Assert
            Assert.Equal(subjectList[1].SubId, subjectResult.SubId);
            Assert.True(subjectList[1].SubId == subjectResult.SubId);
        }
        [Fact]
        public void CheckAddSubject_NotNull_ReturnResult()
        {
            //Arrange
            var subjectList = GetSubjectsData();
            testSubject.Setup(s => s.AddSubject(subjectList[1])).Returns(subjectList[1]);
            var subjectController = new SubjectController(testSubject.Object);

            //Act
            var Result = subjectController.AddSubject(subjectList[1]);

            //Assert
            Assert.NotNull(Result);
            
            
        }

        [Fact]
        public void CheckSubject_DeleteById_ReturnResult()
        {
            //Arrange
            testSubject.Setup(s => s.DeleteSubject(1)).Returns(true);
            var subjectController = new SubjectController(testSubject.Object);

            //Act
            var Result = subjectController.DeleteById(1);

            //Assert
            Assert.True(Result);
        }
        private List<Subject> GetSubjectsData()
        {
            List<Subject> subjectsData = new List<Subject>()
            {
                new Subject()
                { SubId = 1, SubName = "Social", MaxMarks = 100, MarksObtained = 92,StudentId = 1},
                new Subject()
                { SubId = 2, SubName = "Science", MaxMarks = 100,MarksObtained = 84, StudentId = 1 },
            };
            return subjectsData;
        }
    }

}

