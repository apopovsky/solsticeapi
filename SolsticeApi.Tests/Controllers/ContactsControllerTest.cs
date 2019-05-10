using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolsticeApi.Controllers;

namespace SolsticeApi.Tests.Controllers
{
    using System.Web.Http.Results;
    using Moq;
    using SolsticeData;

    [TestClass]
    public class ContactsControllerTest
    {
        private Mock<IContacRepository> _contactServiceMock;
        private ContactsController _controller;

        [TestInitialize]
        public void Setup()
        {
            _contactServiceMock = new Mock<IContacRepository>();
            _controller = new ContactsController(_contactServiceMock.Object);
        }

        [TestMethod]
        public void GetById_ContactDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            var contactId = Guid.NewGuid();
            _contactServiceMock.Setup(x => x.GetById(contactId)).Returns((Contact) null);


            // Act
            var result = _controller.Get(contactId);

            // Assert
            Assert.IsNotNull(result);
            var notFoundResult = result as NotFoundResult;
            Assert.IsNotNull(notFoundResult);
        }

        [TestMethod]
        public void GetById_ContactExists_ReturnsContact()
        {
            // Arrange
            var contactId = Guid.NewGuid();
            _contactServiceMock.Setup(x => x.GetById(contactId)).Returns(new Contact {Id = contactId, Name = "Joe"});


            // Act
            var result = _controller.Get(contactId);

            // Assert
            Assert.IsNotNull(result);
            var contentResult = result as OkNegotiatedContentResult<Contact>;
            Assert.IsNotNull(contentResult);
            Assert.AreEqual(contactId, contentResult.Content.Id);
        }
    }
}
