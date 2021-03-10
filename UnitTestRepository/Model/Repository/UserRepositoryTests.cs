using CMUDevday2021.Model;
using CMUDevday2021.Model.entity;
using CMUDevday2021.Model.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTestRepository.Model.Repository
{
    [TestClass]
    public class UserRepositoryTests
    {
        private MockRepository mockRepository;
        private Mock<UserContext> mockUserContext;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.mockUserContext = this.mockRepository.Create<UserContext>();
        }

        private UserRepository CreateUserRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<UserContext>();
            optionsBuilder.UseInMemoryDatabase(databaseName: "EvoteContext").ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            UserContext userContext = new UserContext(optionsBuilder.Options);
            userContext.Database.EnsureCreated();



            User user1 = new User();
            user1.UserId = 1;
            user1.UserName = "User1";
            user1.Account = "User1@cmu.ac.th";
            user1.Menus = userContext.Menu.OrderBy(o => o.MenuId).ToList();
            userContext.User.Add(user1);

            User user2 = new User();
            user2.UserId = 2;
            user2.UserName = "User2";
            user2.Account = "User2@cmu.ac.th";
            user2.Menus = userContext.Menu.Where(w=>w.MenuId!=1 && w.MenuId != 2).OrderBy(o => o.MenuId).ToList();
            userContext.User.Add(user2);


            userContext.SaveChanges();
            return new UserRepository(userContext);
        }

        [TestMethod]
        public async Task getMenu_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var userRepository = this.CreateUserRepository();
            string account = "User1@cmu.ac.th";

            // Act
            var result = await userRepository.getMenu(
                account);

            // Assert
            Assert.IsTrue(result.Count > 0);
            this.mockRepository.VerifyAll();
        }
    }
}
