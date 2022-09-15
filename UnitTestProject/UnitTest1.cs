using AdminApi.Controllers;
using AdminApi.Models;
using AdminApi.Services;

using Moq;
using System.Security.Claims;

namespace UnitTestProject
{
    public class UnitTest1
    {
        public Mock<IAdminService> mock = new Mock<IAdminService>();
        

        [Fact]
        public void CreateAccount_Success()
        {

            var usersDtls = new MemberDetails()
            {
                Code = "",
                Id = 0,
                FirstName = "JK",
                LastName = "SDE",
                UserName = "Madhuri1",
                DOB = DateTime.Now,
                Address = "",
                State = "",
                Email = "",
                PhysicianName = "",
                Password = "",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                UserType = ""
            };
            string TestResult = "Account Successfully Created";
            mock.Setup(p => p.CreateAccount(usersDtls)).Returns(TestResult);
            AdminController emp = new AdminController(mock.Object);
            var result = emp.CreateAccount(usersDtls);
            Assert.True(TestResult.Equals(result));



        }

        [Fact]
        public void CreateAccount_Failed()
        {
            MemberDetails usersDtls = new MemberDetails();
            AdminController userController = new AdminController(null);
            usersDtls.Code = "";
            usersDtls.Id = 0;
            usersDtls.FirstName = "";
            usersDtls.LastName = "";
            usersDtls.UserName = "Madhuri";
            //usersDtls.DOB = DateTime.Now;
            usersDtls.Address = "";
            usersDtls.State = "";
            usersDtls.Email = "";
            usersDtls.PhysicianName = "";
            usersDtls.Password = "";
            usersDtls.CreatedDate = DateTime.Now;
            usersDtls.ModifiedDate = DateTime.Now;
            usersDtls.UserType = "";
            string TestResult = "User Cannot be Created";
            mock.Setup(p => p.CreateAccount(usersDtls)).Returns(TestResult);
            AdminController
                emp = new AdminController(mock.Object);
            var result = emp.CreateAccount(usersDtls);
            Assert.True(TestResult.Equals(result));
        }
        [Fact]
        public void GetMemberDetails_Success()
        {

            List<MemberList> list=new List<MemberList>();
            mock.Setup(p => p.GetMemberDetails("","","","","")).Returns(list);
            AdminController emp = new AdminController(mock.Object);
            var result = emp.GetMemberDetails("", "", "", "", "");
            Assert.True(list.Equals(result));



        }
        [Fact]
        public void GetMemberDetails_Failed()
        {

            List<MemberList> list = new List<MemberList>();
            mock.Setup(p => p.GetMemberDetails("", "test", "", "", "")).Returns(list);
            AdminController emp = new AdminController(mock.Object);

            var result = emp.GetMemberDetails("", "test", "", "", "");
            Assert.True(list.Equals(result));



        }

        

        [Fact]
        public void AssignPhysician_Success()
        {

            var usersDtls = new PhysicianAssign()
            {

                MemberId = "HCMM1001",
                PhysicianName = "",
                AdminId = ""
            };
            string TestResult = "Physician Assigned Successfully";
            mock.Setup(p => p.AssignPhysician(usersDtls)).Returns(TestResult);
            AdminController emp = new AdminController(mock.Object);
            var result = emp.AssignPhysician(usersDtls);
            Assert.True(TestResult.Equals(result));



        }

        [Fact]
        public void AssignPhysician_Failed()
        {
            var usersDtls = new PhysicianAssign()
            {
                
                MemberId = "",
                PhysicianName="",
                AdminId=""
            };

            string TestResult = "Member Not found";
            mock.Setup(p => p.AssignPhysician(usersDtls)).Returns(TestResult);
            AdminController
                emp = new AdminController(mock.Object);
            var result = emp.AssignPhysician(usersDtls);
            Assert.True(TestResult.Equals(result));
        }

      
    }
}