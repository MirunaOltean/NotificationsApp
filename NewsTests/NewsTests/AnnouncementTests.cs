using NewsAPI.Controllers;
using NewsAPI.Models;
using NewsAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace NewsTests
{
    public class Tests
    {
        private AnnouncementsController _announcementsController;
        private Mock<IAnnouncementCollectionService> _mockAnnouncementCollectionService;
        private Announcement announcement;


        [SetUp]
        public void Setup()
        {
            announcement = new Announcement
            {
                Id = new Guid(),
                Title = "New Announcement",
                Author = "Luca",
                Description = "School is over,",
                Message = "Hi guys",
                CategoryId = "1",
                ImageUrl = "1.jpg",
                Category = "General"
            };
            _mockAnnouncementCollectionService = new Mock<IAnnouncementCollectionService>();
            _announcementsController = new AnnouncementsController(_mockAnnouncementCollectionService.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockAnnouncementCollectionService.Reset();
        }

        [Test]
        public void NullAnnouncementCollectionServiceTest()
        {
            //arrange
            string expectedParamName = "AnnouncementCollectionService";

            //act
            var exception = Assert.Throws<Exception>(() => new AnnouncementsController(null));

            //assert
            Assert.That(exception.Message, Is.EqualTo(expectedParamName));
        }

        [Test]
        public async Task GetAnnouncementsTest()
        {
            //arrange
            List<Announcement> Announcements = new List<Announcement> { announcement };

            _mockAnnouncementCollectionService.Setup(m => m.GetAll()).Returns(Task.FromResult(Announcements));

            //act
            var actionResult = await _announcementsController.GetAnnouncements();
            Assert.That(actionResult, Is.Not.Null);
            Assert.That(actionResult, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public async Task CreateInvalidAnnouncementsTest()
        {
            //act
            var result = await _announcementsController.CreateAnnouncement(null);

            //assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task CreateAnnouncementsTest()
        {
            //arrange
            _mockAnnouncementCollectionService.Setup(m => m.Create(It.IsAny<Announcement>())).Returns(Task.FromResult(true));

            //act
            var result = await _announcementsController.CreateAnnouncement(announcement);

            //assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public async Task DeleteAnnouncementsTest()
        {
            _mockAnnouncementCollectionService.Setup(m => m.Delete(It.IsAny<Guid>())).Returns(Task.FromResult(true));

            var result = await _announcementsController.DeleteAnnouncement(new Guid());

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<OkResult>());
        }

        [Test]
        public async Task DeleteAnnouncementsByInvalidIdTest()
        {
            //arrange
            _mockAnnouncementCollectionService.Setup(m => m.Delete(It.IsAny<Guid>())).Returns(Task.FromResult(false));

            //act
            var result = await _announcementsController.DeleteAnnouncement(new Guid());

            //assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task UpdateAnnouncementsByInvalidIdTest()
        {
            //arrange
            _mockAnnouncementCollectionService.Setup(m => m.Update(It.IsAny<Guid>(), announcement)).Returns(Task.FromResult(false));

            //act
            var result = await _announcementsController.UpdateAnnouncement(new Guid(), announcement);

            //assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<NotFoundObjectResult>());
        }

        [Test]
        public async Task UpdateAnnouncementsByIdTest()
        {
            _mockAnnouncementCollectionService.Setup(m => m.Update(It.IsAny<Guid>(), announcement)).Returns(Task.FromResult(true));

            var result = await _announcementsController.UpdateAnnouncement(new Guid(), announcement);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public async Task UpdateInvalidAnnouncementsTest()
        {
            //act
            var result = await _announcementsController.UpdateAnnouncement(new Guid(), null);

            //assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }
    }
}