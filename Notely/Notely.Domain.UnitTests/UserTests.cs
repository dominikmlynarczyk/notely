using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Notely.Domain.Users;
using Notely.Domain.Users.Policies;
using Notely.SharedKernel;

namespace Notely.Domain.UnitTests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void Should_Login_User_With_Correct_Password()
        {
            var user = new User(new AggregateId(Guid.NewGuid()), "xxx", "xxx", "xxx", "xxx@xxx.com");

            user.SetPassword("12345678", new FourLettersPasswordPolicy());

            var result = user.IsPasswordValid("12345678");

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void Should_Not_Login_With_Incorrect_Password()
        {
            var user = new User(new AggregateId(Guid.NewGuid()), "xxx", "xxx", "xxx", "xxx@xxx.com");

            user.SetPassword("12345678", new FourLettersPasswordPolicy());

            var result = user.IsPasswordValid("123456");

            Assert.IsFalse(result);
        }
    }
}
