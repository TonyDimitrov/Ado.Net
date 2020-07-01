using Ado.Net.Web.Data;
using Ado.Net.Web.Models.Dto;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;
using System;
using System.Collections.Generic;

namespace Ado.Net.Web.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IDbAccessor db;

        public EmployeesService(IDbAccessor db)
        {
            this.db = db;
        }

        public async Task<List<EmployeeDto>> GetAll()
        {
            using var connection = await this.db.Open();

            SqlCommand command = new SqlCommand("sp_GetAll", connection);

            command.CommandType = CommandType.StoredProcedure;

            var data = command.ExecuteReader();

            List<EmployeeDto> employees = new List<EmployeeDto>();

            while (data.Read())
            {
                employees.Add(
                    new EmployeeDto
                    {
                        EmployeeID = (int)data["EmployeeID"],
                        FullName = (string)data["FullName"],
                        Salary = (decimal)data["Salary"],
                        DepartamentName = (string)data["DepartamentName"],
                    });
            }

            return employees;
        }

        public async Task<EmployeeDetailsDto> GetById(int id)
        {
            using var connection = await this.db.Open();

            SqlCommand command = new SqlCommand("sp_GetById", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            var data = command.ExecuteReader();

            EmployeeDetailsDto employee = new EmployeeDetailsDto();

            while (data.Read())
            {
                employee.EmployeeID = (int)data["EmployeeID"];
                employee.FullName = (string)data["FullName"];
                employee.Salary = (decimal)data["Salary"];
                employee.DepartamentName = (string)data["DepartamentName"];
                employee.HireDate = Convert.ToDateTime(data["HireDate"]).ToString("dd/MM/yyyy");
            }

            return employee;
        }

        public Task GetByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task Add(EmployeeDto employee)
        {
            throw new System.NotImplementedException();
        }

        public Task Edit(EmployeeDto employee)
        {
            throw new System.NotImplementedException();
        }
    }
}
