using Ado.Net.Web.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ado.Net.Web.Services
{
    public interface IEmployeesService
    {
        Task<List<EmployeeDto>> GetAll(); 

        Task<EmployeeDetailsDto> GetById(int id);

        Task GetByName(string name);

        Task Add(EmployeeDto employee);

        Task Edit(EmployeeDto employee);
    }
}
