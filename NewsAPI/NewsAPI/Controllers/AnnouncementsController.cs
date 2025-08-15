using Microsoft.AspNetCore.Mvc;
using NewsAPI.Models;
using NewsAPI.Services;
using System.Linq;

namespace NewsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]


    ///<summary>
    /// The controller for Announcement
    ///</summary>
    public class AnnouncementsController : ControllerBase
    {
        IAnnouncementCollectionService _announcementCollectionService;

        public AnnouncementsController(IAnnouncementCollectionService announcementCollectionService)
        {
            _announcementCollectionService = announcementCollectionService ?? throw new(nameof(AnnouncementCollectionService));
        }


        [HttpGet]
        public async Task<IActionResult> GetAnnouncements()
        {
            List<Announcement> announcements = await _announcementCollectionService.GetAll();
            return Ok(announcements);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnnouncement([FromBody] Announcement announcement)
        {
            if (announcement == null)
            {
                return BadRequest("Announcement cannot be null");
            }

            if (!(await _announcementCollectionService.Create(announcement)))
            {
                return BadRequest("Error");
            }
            return Ok(announcement);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnnouncement(Guid id)
        {
            if (!(await _announcementCollectionService.Delete(id)))
            {
                return BadRequest("Announcement not found");
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnnouncement(Guid id, [FromBody] Announcement announcement)
        {
            if (announcement == null)
            {
                return BadRequest("Announcement can't be null");
            }

            if(!(await _announcementCollectionService.Update(id,announcement)))
            {
                return NotFound("Announcement not found");
            }

            return Ok(announcement);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnnouncementById(Guid id)
        {
            Announcement announcement = await _announcementCollectionService.Get(id);
            if (announcement == null)
            {
                return NotFound("The announcement with that id doesn't exist.");
            }
            return Ok(announcement);
        }

        [HttpGet("Category/{category}")]
        public async Task<IActionResult> GetAnnouncementByCategory(string category)
        {
            List<Announcement> announcementsByCategory = await _announcementCollectionService.GetAnnouncementsByCategory(category);
            if (announcementsByCategory == null)
            {
                return NotFound("No announcement with that category exists.");
            }
            return Ok(announcementsByCategory);
        }
    }
}

