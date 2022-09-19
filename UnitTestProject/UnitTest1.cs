using AdminApi.Controllers;
using AdminApi.Models;
using AdminApi.Services;
using Moq;
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
        [Fact]
        public void GetStates_Success()
        {
            List<StateDetails> list = new List<StateDetails>();
            mock.Setup(p => p.GetStates()).Returns(list);
            int count = list.Count;
            AdminController emp = new AdminController(mock.Object);
            List<StateDetails> list1 = emp.GetStates();
            Assert.True(count.Equals(list1.Count));
        }
        [Fact]
        public void GetUserTypes_Success()
        {
            List<UserTypes> list = new List<UserTypes>();
            mock.Setup(p => p.GetUserTypes()).Returns(list);
            int count = list.Count;
            AdminController emp = new AdminController(mock.Object);
            List<UserTypes> list1 = emp.GetUserTypes();
            int count1=list1.Count;
            Assert.True(count.Equals(count1));
        }
        [Fact]
        public void GetUserNames_Success()
        {
            List<string> list = new List<string>();
            mock.Setup(p => p.GetUserNames()).Returns(list);
            int count = list.Count;
            AdminController emp = new AdminController(mock.Object);
            List<string> list1 = emp.GetUserNames();
            int count1 = list1.Count;
            Assert.True(count.Equals(count1));
        }
       
        [Fact]
        public void GetMails_Success()
        {
            List<string> list = new List<string>();
            mock.Setup(p => p.GetEmails()).Returns(list);
            int count = list.Count;
            AdminController emp = new AdminController(mock.Object);
            List<string> list1 = emp.GetMails();
            int count1 = list1.Count;
            Assert.True(count.Equals(count1));
        }
        [Fact]
        public void GetPhysicianName_Success()
        {
            List<PhysicianDetails> list = new List<PhysicianDetails>();
            mock.Setup(p => p.GetPhysicianNames()).Returns(list);
            int count = list.Count;
            AdminController emp = new AdminController(mock.Object);
            List<PhysicianDetails> list1 = emp.GetPhysicianName();
            int count1 = list1.Count;
            Assert.True(count.Equals(count1));
        }

    }
}