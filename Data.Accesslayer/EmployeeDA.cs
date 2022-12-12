using Data.Accesslayer.Models;
using GE = Global.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.Accesslayer
{
    public class EmployeeDA : IEmployeeDA
    {
        private readonly Learn_DBContext learn_DBContext;
        public EmployeeDA(Learn_DBContext _learn_DBContext)
        {
            this.learn_DBContext = _learn_DBContext;
        }

        public async Task<List<GE::Employee>> GetEmployee()
        {
            var _data = await this.learn_DBContext.TblEmployees.ToListAsync();
            List<GE::Employee> employees = new List<GE::Employee>();
            if (_data != null && _data.Count > 0)
            {
                _data.ForEach(item =>
                {
                    employees.Add(new GE.Employee()
                    {
                        Code = item.Code,
                        Name = item.Name,
                        Designation = item.Designation,
                        Email = item.Email,
                        Phone = item.Phone

                    });
                });
            }
            return employees;
        }

        public async Task<GE::Employee> GetEmployeebycode(int code)
        {
            var _data = await this.learn_DBContext.TblEmployees.FirstOrDefaultAsync(item => item.Code == code);
            GE::Employee employees = new GE.Employee();
            if (_data != null)
            {
                employees = (new GE.Employee()
                {
                    Code = _data.Code,
                    Name = _data.Name,
                    Designation = _data.Designation,
                    Email = _data.Email,
                    Phone = _data.Phone
                });
            }
            return employees;
        }

        public async Task<string> Save(GE::Employee employee)
        {
            string Response = string.Empty;
            try
            {
                if (employee.Code > 0)
                {
                    var _exist = await this.learn_DBContext.TblEmployees.FirstOrDefaultAsync(item => item.Code == employee.Code);
                    if (_exist != null)
                    {
                        _exist.Name = employee.Name;
                        _exist.Email = employee.Email;
                        _exist.Phone = employee.Phone;
                        _exist.Designation = employee.Designation;
                    }
                }
                else
                {
                    TblEmployee _employee = new TblEmployee()
                    {
                        Name = employee.Name,
                        Email = employee.Email,
                        Phone = employee.Phone,
                        Designation = employee.Designation
                    };
                    await this.learn_DBContext.TblEmployees.AddAsync(_employee);
                }
                await this.learn_DBContext.SaveChangesAsync();
                Response = "pass";

            }
            catch(Exception ex)
            {
                Response = ex.Message;
            }
            return Response;
        }

        public async Task<string> RemoveEmployee(int code)
        {
            var _data = await this.learn_DBContext.TblEmployees.FirstOrDefaultAsync(item => item.Code == code);
            string Response = string.Empty;
            if (_data != null)
            {
                try
                {
                    this.learn_DBContext.TblEmployees.Remove(_data);
                    await this.learn_DBContext.SaveChangesAsync();
                    Response = "pass";
                }
                catch(Exception ex)
                {

                }
            }
            return Response;
        }

    }
}