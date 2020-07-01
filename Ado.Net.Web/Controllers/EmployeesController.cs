using Ado.Net.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Ado.Net.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ILogger<EmployeesController> logger;
        private readonly IEmployeesService employeesService;

        public EmployeesController(ILogger<EmployeesController> logger, IEmployeesService employeesService)
        {
            this.logger = logger;
            this.employeesService = employeesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await this.employeesService.GetAll();

            return this.View(employees);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var employee = await this.employeesService.GetById(id);

            return this.View(employee);
        }
    }
}
