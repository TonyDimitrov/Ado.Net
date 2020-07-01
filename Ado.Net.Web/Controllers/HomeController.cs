using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ado.Net.Web.Models;
using Ado.Net.Web.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Ado.Net.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            IDbAccessor dbConnection = new DbAccessor();

            using var db = await dbConnection.Open();

            string cmd = "SELECT COUNT(EmployeeID) FROM Employees";

            SqlCommand command = new SqlCommand(cmd, db);

            var count = command.ExecuteScalar();

            this.ViewData["count"] = (int)count;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
