using Data.Accesslayer;
using GE = Global.Entity;
namespace Business.Layer
{
    public class EmployeeBC : IEmployeeBC
    {
        private readonly IEmployeeDA employeeDA;
        public EmployeeBC(IEmployeeDA employee)
        {
            this.employeeDA = employee;
        }

        public async Task<List<GE::Employee>> GetEmployees()
        {
            return await this.employeeDA.GetEmployee();
        }

        public async Task<GE::Employee> GetEmployeebycode(int code)
        {
            return await this.employeeDA.GetEmployeebycode(code);
        }

        public async Task<string> Save(GE::Employee employee)
        {
            return await this.employeeDA.Save(employee);
        }

        public async Task<string> RemoveEmployee(int code)
        {
            return await this.employeeDA.RemoveEmployee(code);
        }


    }
}