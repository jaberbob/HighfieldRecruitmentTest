using HighfieldRecruitmentTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HighfieldRecruitmentTest.Controllers
{
    /// <summary>
    /// Default entry point to site controller
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Constructor - default entry point to site
        /// </summary>
        /// <param name="logger"></param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Default / first page of site - Shows requested results of the test
        /// </summary>
        /// <returns>IActionResult</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// User's tab - Shows a list of users
        /// </summary>
        /// <returns>IActionResult</returns>
        public IActionResult Users()
        {
            return View();
        }

        /// <summary>
        /// ResponseDtoJson tab - Shows results of the test - JSON object
        /// </summary>
        /// <returns>IActionResult</returns>
        public IActionResult ResponseDtoJson()
        {
            return View();
        }

        /// <summary>
        /// Shows error page
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}