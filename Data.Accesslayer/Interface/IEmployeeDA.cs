using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GE = Global.Entity;

namespace Data.Accesslayer
{
    public interface IEmployeeDA
    {
        Task<List<GE::Employee>> GetEmployee();
        Task<GE::Employee> GetEmployeebycode(int code);
        Task<string> Save(GE::Employee employee);
        Task<string> RemoveEmployee(int code);
    }
}
