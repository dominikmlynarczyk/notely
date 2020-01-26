using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Notely.Domain.Users;
using Notely.Domain.Users.Policies;
using Notely.SharedKernel;
using Notely.SharedKernel.Exceptions;

namespace Notely.Domain.UnitTests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void Should_Register_User_With_Correct_Password()
        {
            var user = new User(new AggregateId(Guid.NewGuid()), "xxx", "xxx", "xxx", "xxx@xxx.com");

            user.SetPassword("12345678", new FourLettersPasswordPolicy());

            var result = user.IsPasswordValid("12345678");

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void Should_Not_Register_With_Incorrect_Password()
        {
            var user = new User(new AggregateId(Guid.NewGuid()), "xxx", "xxx", "xxx", "xxx@xxx.com");

            user.SetPassword("12345678", new FourLettersPasswordPolicy());

            var result = user.IsPasswordValid("123456");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Should_Not_Register_With_Empty_UserName()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
                new User(new AggregateId(Guid.NewGuid()), "", "xxx", "xxx", "xxx@xxx.com"));
        }

        [TestMethod]
        public void Should_Not_Register_With_Empty_FirstName()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
                new User(new AggregateId(Guid.NewGuid()), "xxx", "", "xxx", "xxx@xxx.com"));
        }

        [TestMethod]
        public void Should_Not_Register_With_Empty_SecondName()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
                new User(new AggregateId(Guid.NewGuid()), "xxx", "xxx", "", "xxx@xxx.com"));
        }

        [TestMethod]
        public void Should_Not_Register_With_Empty_Email()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
                new User(new AggregateId(Guid.NewGuid()), "xxx", "", "xxx", ""));
        }

        [TestMethod]
        public void Should_Not_Register_With_Below_4Char_Password()
        {
            var user = new User(new AggregateId(Guid.NewGuid()), "xxx", "xxx", "xxx", "xxx@xxx.com");

            Assert.ThrowsException<BusinessLogicException>(() => user.SetPassword("123", new FourLettersPasswordPolicy()));
        }

        [TestMethod]
        public void Should_Not_Update_User_After_Empty_UserName_Change()
        {
            var user = new User(new AggregateId(Guid.NewGuid()), "xxx", "xxx", "xxx", "xxx@xxx.com");
            Assert.ThrowsException<ArgumentNullException>(() => user.Update(String.Empty, user.FirstName, user.SecondName, user.Email));
        }

        [TestMethod]
        public void Should_Not_Update_User_After_Empty_FirstName_Change()
        {
            var user = new User(new AggregateId(Guid.NewGuid()), "xxx", "xxx", "xxx", "xxx@xxx.com");
            Assert.ThrowsException<ArgumentNullException>(() => user.Update(user.UserName, String.Empty, user.SecondName, user.Email));
        }

        [TestMethod]
        public void Should_Not_Update_User_After_Empty_SecondName_Change()
        {
            var user = new User(new AggregateId(Guid.NewGuid()), "xxx", "xxx", "xxx", "xxx@xxx.com");
            Assert.ThrowsException<ArgumentNullException>(() => user.Update(user.UserName, user.FirstName, String.Empty, user.Email));
        }

        [TestMethod]
        public void Should_Not_Update_User_After_Empty_Email_Change()
        {
            var user = new User(new AggregateId(Guid.NewGuid()), "xxx", "xxx", "xxx", "xxx@xxx.com");
            Assert.ThrowsException<ArgumentNullException>(() => user.Update(user.UserName, user.FirstName, user.SecondName, String.Empty));
        }

        [TestMethod]
        public void Should_Update_User()
        {
            var user = new User(new AggregateId(Guid.NewGuid()), "xxx", "xxx", "xxx", "xxx@xxx.com");
            user.Update("newTest", "testName", "testSecName", "testmail@mail.com");
            Assert.AreEqual(user.UserName, "newTest");
            Assert.AreEqual(user.FirstName, "testName");
            Assert.AreEqual(user.SecondName, "testSecName");
            Assert.AreEqual(user.Email, "testmail@mail.com");
        }

        [TestMethod]
        public void Should_Archive_User()
        {
            var user = new User(new AggregateId(Guid.NewGuid()), "xxx", "xxx", "xxx", "xxx@xxx.com");
            user.Archive();
            Assert.IsTrue(user.IsArchived);
        }
    }
}