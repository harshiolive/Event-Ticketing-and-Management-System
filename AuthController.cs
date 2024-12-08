//using EventTicketingManagement.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace EventTicketingManagement.Controllers
//{
//    public class AuthController : Controller
//    {
//        private object _context;
//        private object _tokenService;

//        public IActionResult Index()
//        {
//            return View();
//        }
//        [HttpPost("login")]
//        public IActionResult Login([FromBody] LoginRequest request)
//        {
//            var user = _context.User.SingleOrDefault(u => u.Username == request.Username);
//            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
//            {
//                return Unauthorized();
//            }

//            var token = _tokenService.GenerateToken(user);
//            return Ok(new { Token = token });
//        }
//    }
//}
