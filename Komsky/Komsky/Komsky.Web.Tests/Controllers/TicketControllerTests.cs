using System;
using System.Web.Mvc;
using Komsky.Domain.Models;
using Komsky.Services.Factories;
using Komsky.Services.Handlers;
using Komsky.Web.Controllers;
using Komsky.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Komsky.Web.Tests.Controllers
{
    [TestClass]
    public class TicketControllerTests
    {
        private Mock<IBaseHandler<TicketDomain>> _ticketMock;
        private Mock<IBaseHandler<ProductDomain>> _productMock;
        private TicketController _ticketController;

        [TestInitialize]
        public void TestSetup()
        {
            _ticketMock = new Mock<IBaseHandler<TicketDomain>>();
            _productMock = new Mock<IBaseHandler<ProductDomain>>();
            _ticketMock.Setup(x => x.GetById(It.IsAny<Int32>()))
                .Returns(Fakes.FakeTicketRepository.GetFakeTicket().CreateTicketDomain());

            _ticketController = new TicketController(_ticketMock.Object, _productMock.Object);
        }

        [TestCleanup]
        public void TestTeardown()
        {
            _ticketMock = null;
            _productMock = null;
            _ticketController = null;
        }

        [TestMethod]
        public void TicketIndexTest()
        {

            // act
            ViewResult result = _ticketController.Index() as ViewResult;

            // asssert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TicketDetailsTest()
        {
            // act
            ViewResult result = _ticketController.Details(5) as ViewResult;

            // asssert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TicketEditTest()
        {
            // act
            var result = _ticketController.Edit(new TicketViewModel());

            // asssert
            Assert.IsNotNull(result);
        }
    }
}
