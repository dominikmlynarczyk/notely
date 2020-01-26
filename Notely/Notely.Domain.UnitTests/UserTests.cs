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
    }
}