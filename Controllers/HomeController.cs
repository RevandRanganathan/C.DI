using HON.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HON.Controllers
{
   
    public class HomeController : Controller
    {
       
        private IStudentRepository _studentRepository;

        public HomeController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;

        }
        
        //  [Route("")]
        //  [Route("Home/Index")]
        public ActionResult Error()
        {
            throw new Exception("This is Exception Filter");
        }
        public ViewResult Index()
        {
            var stu =_studentRepository.GetAllStudent();
            return View (stu);
            //return View("~/Views/Home/Index.cshtml", stu);
        }

        public ViewResult Details()
        {
            DetailsViewModel detailsViewModel = new DetailsViewModel()
            {
                Student = _studentRepository.GetStudent(1),
                PageTitle = "Student Details"
            };
           
            return View (detailsViewModel);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToActionResult Create (Student student)
        {
            Student newstudent = _studentRepository.Add(student);
            return RedirectToAction ("Index");
            //return RedirectToAction("details", new { id = newstudent.Id });
        }
        
    }
}
