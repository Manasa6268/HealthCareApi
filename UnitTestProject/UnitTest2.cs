using AdminApi.Controllers;
using MemberApi.Controllers;
using MemberApi.Models;
using MemberApi.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject

{
    public class UnitTest2
    {
        public Mock<IMemberService> mock = new Mock<IMemberService>();
        [Fact]
        public void FetchDetails_Success()
        {

            int member = 1001;
            MemberDetails list = new MemberDetails();

            mock.Setup(p => p.FetchDetails(member)).Returns(list);
            MemberController emp = new MemberController(mock.Object);
            var result = emp.FetchDetails(member);
            Assert.True(list.Equals(result));



        }

        [Fact]
        public void FetchDetails_Failed()
        {

            int member = 0;
            MemberDetails list = new MemberDetails();
            mock.Setup(p => p.FetchDetails(member)).Returns(list);
            MemberController
                emp = new MemberController(mock.Object);
            var result = emp.FetchDetails(member);
            Assert.True(list.Equals(result));
        }
        [Fact]
        public void SubmitClaim_Success()
        {

            var usersDtls = new ClaimDetails()
            {
                Code = "",
                Id = 0,
                MemberId = "",
                ClaimType = "",
                ClaimDate = DateTime.Now.Date,
                ClaimAmount = 0,
                Remarks = "",
                CreatedBy = "",

            };
            string TestResult = "Claim Successfully Submitted";
            mock.Setup(p => p.SubmitClaim(usersDtls)).Returns(TestResult);
            MemberController emp = new MemberController(mock.Object);
            var result = emp.SubmitClaim(usersDtls);
            Assert.True(TestResult.Equals(result));



        }

        [Fact]
        public void SubmitClaim_Failed()
        {
            var usersDtls = new ClaimDetails()
            {
                Code = "",
                Id = 0,
                MemberId = "",
                ClaimType = "",
                //ClaimDate = DateTime.Now.Date,
                ClaimAmount = 0,
                Remarks = "",
                CreatedBy = "",

            };

            string TestResult = "Claim Cannot be Submitted";
            mock.Setup(p => p.SubmitClaim(usersDtls)).Returns(TestResult);
            MemberController
                emp = new MemberController(mock.Object);
            var result = emp.SubmitClaim(usersDtls);
            Assert.True(TestResult.Equals(result));
        }

        [Fact]
        public void FetchClaimDetails_Success()
        {

            string member ="HCMM1001";
            List<ClaimDetails> list = new List<ClaimDetails>();

            mock.Setup(p => p.FetchClaimDetails(member)).Returns(list);
            MemberController emp = new MemberController(mock.Object);
            var result = emp.FetchClaimDetails(member);
            Assert.True(list.Equals(result));



        }

        [Fact]
        public void FetchClaimDetails_Failed()
        {

            string member = "";
            List<ClaimDetails> list = new List<ClaimDetails>();
            mock.Setup(p => p.FetchClaimDetails(member)).Returns(list);
            MemberController
                emp = new MemberController(mock.Object);
            var result = emp.FetchClaimDetails(member);
            Assert.True(list.Equals(result));
        }
    }
}
