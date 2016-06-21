using System;
using NUnit.Framework;
using CRM_Application.Controllers;
using CRM_Application.Models;
using System.Web.Mvc;


namespace NUnitTestProject1
{
    [TestFixture]
    public class ControllerTestClass
    {
        [Test]
        public void TestCustomerIndex()
        {
            var obj = new CustomersController();
            var actResult = obj.Index() as ViewResult;
            Assert.That(actResult.ViewName, Is.EqualTo("Index"));
        }
    }
}