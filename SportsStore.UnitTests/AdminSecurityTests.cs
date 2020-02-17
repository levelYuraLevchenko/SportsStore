﻿using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.Infrastructure.Abstract;
using SportsStore.WebUI.Models;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class AdminSecurityTests
    {
        [TestMethod]
        public void Can_Login_With_Vilid_Credentials()
        {
            // Организация - создание имитированного поставщика аутентификации
            Mock<IAuthProvider> mock = new Mock<IAuthProvider>();
            mock.Setup(m => m.Authenticate("admin", "secret")).Returns(true);

            // Организация - создание модели представления
            LoginViewModel model = new LoginViewModel
            {
                UserName = "admin",
                Password = "secret"
            };

            // Организация - создание контроллера
            AccountController target = new AccountController(mock.Object);

            // Действие - аутентификация с использованием правилльных учетных данных
            ActionResult result = target.Login(model, "/MyURL");

            // Утверждение
            Assert.IsInstanceOfType(result, typeof(RedirectResult));
            Assert.AreEqual("/MyURL", ((RedirectResult)result).Url);
        }

        [TestMethod]
        public void Cannot_Login_With_Invalid_Credentials()
        {
            // Организация - создание имитированного поставщика аутентификации
            Mock<IAuthProvider> mock = new Mock<IAuthProvider>();
            mock.Setup(m => m.Authenticate("admin", "secret")).Returns(true);

            // Организация - создание модели представления
            LoginViewModel model = new LoginViewModel
            {
                UserName = "badUser",
                Password = "badPass"
            };

            // Организация - создание контроллера
            AccountController target = new AccountController(mock.Object);

            // Действие - аутентификация с использованием правилльных учетных данных
            ActionResult result = target.Login(model, "/MyURL");

            // Утверждение
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsFalse(((ViewResult)result).ViewData.ModelState.IsValid);
        }
    }
}
