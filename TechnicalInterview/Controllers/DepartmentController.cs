using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.VM;
using Mapping;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace TechnicalInterview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        [HttpPost]
        public void Post([FromBody] DepartmentVM departmentVm)
        {
            var department = Mapper.GetDepartment(departmentVm);

            DepartmentService.Post(department);
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<DepartmentVM>> Get()
        {
            var deps = DepartmentService.GetDepartments();

            return Ok(deps);
        }
        
        //[HttpPost("FilterEntities")]
        //public ActionResult<FilterResultVM> FilterEntities([FromBody] FilterVM filter)
        //{
        //    //TODO: return filtered departments and employees from the repository
        //    //// exclude > include
        //    //// excluding/including a department excludes/includes all the employees in it

        //    return Ok(null);
        //}
    }
}
