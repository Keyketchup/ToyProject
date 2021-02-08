using StudentManager.Models;
using StudentManager.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace StudentManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentServices _studentService;

        public StudentController(StudentServices _service) {
            _studentService = _service;
        }

        [HttpGet]
        public ActionResult<List<Students>> Get() {
            return _studentService.Get();
        }
        [HttpGet("{id:length(24)}", Name = "GetStudent")]
        public ActionResult<Students> Get(string id) {
            var res = _studentService.Get(id);

            if(res == null) {
                return NotFound();
            }

            return res;
        }

        [HttpPost]
        public ActionResult<Students> Create(Students students) {
            _studentService.Create(students);

            return students;
        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult<Students> Delete(string id) {
            var res = _studentService.Get(id);

            if(res == null) {
                return NotFound();
            }            

            _studentService.Delete(id);
            return res;
        }

       
        [HttpPut("{id:length(24)}")]
        public ActionResult<Students> Update(string id, Students _st) {
            var _res = _studentService.Get(id);

            if(_res == null) {
                return NotFound();
            }    

            _studentService.Update(id, _st);
            return _res;
        }

    }
}