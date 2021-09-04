using Microsoft.AspNetCore.Mvc;
using TravelAgentWeb.Data;

namespace TravelAgentWeb.Controllers
{
    [ApiController, Route("api/[controller]")] public class NotificationsController : ControllerBase {
        private readonly TravelAgentDbContext _context;
        public NotificationsController(TravelAgentDbContext context)
        {
            _context = context ;  
        }
    }
}