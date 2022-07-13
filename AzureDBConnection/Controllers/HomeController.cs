using AzureDBConnection.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureDBConnection.Controllers
{
    [Route("api/V1")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly EmployeeContext _employeeContext;
        public HomeController(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        [Route("addEmployee")]
        [HttpPost]
        public IActionResult AddEmpoyeeData(Movie movie)
        {
            movie.ReleaseDate = System.DateTime.Now;
            _employeeContext.Movies.Add(movie);
            _employeeContext.SaveChanges();

            return Ok(true);
        }

        [Route("getEmployee")]
        [HttpGet]
        public IActionResult GetEmpoyeeData()
        {
            var data = _employeeContext.Movies.ToList();

            return Ok(data);
        }
        [Route("employeeDetails")]
        [HttpPost]
        public IActionResult GetEmployeeDetails(Movie movie)
        {
            var data = _employeeContext.Movies.FirstOrDefault(x=>x.ID==1);

            return Ok(data);
        }
    }
}
