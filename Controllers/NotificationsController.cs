using Microsoft.AspNetCore.Mvc;
using TravelAgentWeb.Data;
using System;
using TravelAgentWeb.Dtos;

namespace TravelAgentWeb.Controllers
{
    [ApiController, Route("api/[controller]")] public class NotificationsController : ControllerBase {
        private readonly TravelAgentDbContext _context;
        public NotificationsController(TravelAgentDbContext context)
        {
            _context = context ;  
        }
        [HttpPost]
        public ActionResult FlightChanged(FlightDetailUpdateDto flightDetailUpdateDto){
            var secretModel = _context.SubscriptionSecrets.FirstOrDefault(x=>
            x.Secret == flightDetailUpdateDto.Secret && 
            x.Publisher == flightDetailUpdateDto.Publisher);
            if (secretModel == null){
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("Invalid secret, ignore webhook");
                Console.ResetColor();
            } else {
            
                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine("Valid webhook");
                Console.WriteLine($"Old Price {flightDetailUpdateDto.OldPrice} New Price {flightUpdateDto.NewPrice}");
                Console.ResetColor();
            }
        }
    }
}