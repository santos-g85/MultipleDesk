using Microsoft.AspNetCore.Mvc;
using MultipleDesk.Models;
using MultipleDesktop.Services;

namespace MultipleDesk.Controllers
{
    public class RegisterController : Controller
    {
        private readonly MongoDbService _db;
        private readonly ILogger<RegisterController> _logger;
        private readonly IWebHostEnvironment _env;

        public RegisterController(MongoDbService db, ILogger<RegisterController> logger, IWebHostEnvironment env)
        {
            _db = db;
            _logger = logger;
            _env = env;
        }

        [HttpPost]
        public IActionResult Register(UserRegistration user)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid registration attempt.");
                return View("Index", user);
            }

            try
            {
                user.RegistrationDate = DateTime.UtcNow;
                _db.Register(user);
                _logger.LogInformation("User registered successfully: {Email}", user.Email);

                // Set TempData flag for download
                TempData["TriggerDownload"] = true;
                return RedirectToAction("Index","Home");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while registering user: {Email}", user.Email);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        public IActionResult Download()
        {
            var filePath = Path.Combine(_env.WebRootPath, "Downloads", "MultipleDeskInstaller.exe");

            if (!System.IO.File.Exists(filePath))
            {
                _logger.LogError("Download file not found at: {Path}", filePath);
                return NotFound("Download file not available.");
            }

            return PhysicalFile(filePath, "application/octet-stream", "MultipleDeskInstaller.exe");
        }
    }
}

