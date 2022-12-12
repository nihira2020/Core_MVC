using Microsoft.AspNetCore.Mvc;
using Business.Layer;
using GE = Global.Entity;

namespace LearnCoreMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeBC employeeBC;
        public EmployeeController(IEmployeeBC employeeBC)
        {
            this.employeeBC = employeeBC;

        }
        public async Task<IActionResult> Index()
        {
            List<GE::Employee> employees = new List<GE.Employee>();//await this.employeeBC.GetEmployees();
            return View(employees);
        }

        public IActionResult Create()
        {
            return View(new GE.Employee());
        }

        public async Task<IActionResult> Edit(string code)
        {
            GE::Employee employees = await this.employeeBC.GetEmployeebycode(Convert.ToInt32(code));
            return View("Create",employees);
        }


        public async Task<IActionResult> Save(GE::Employee employee)
        {
            string Response = await this.employeeBC.Save(employee);
            return Json(Response);
        }

        //public  JsonResult Save(string test)
        //{
        //    string Response = String.Empty;// await this.employeeBC.Save(employee);
        //    return Json(Response);
        //}

        public async Task<IActionResult> Remove(string code)
        {
            string Response = await this.employeeBC.RemoveEmployee(Convert.ToInt32(code));
            return Json(Response);
        }
        public async Task<IActionResult> GetAll()
        {
            var Response = await this.employeeBC.GetEmployees();
            return Json(Response);
        }


    }
}
