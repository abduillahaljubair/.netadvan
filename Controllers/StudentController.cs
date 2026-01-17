using learningwithos.Models;
using learningwithos.Repo;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.Intrinsics.Arm;

namespace learningwithos.Controllers
{
    
    public class StudentController : Controller
    {
        [Route("/student/htpp")]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            //default value pass hoise 
            var Default = new StudentView();
            Default.Age = 15;
            Default.Email = "abc@gmail.com";
            return View(Default);
        }
        [HttpPost]
//http post dewate same namer onno function ee hit korbe
        public IActionResult Create(StudentView s1)
        {
            if(!ModelState.IsValid)
            {
                return View(s1);
            }
            return View();
        }
        public IActionResult Input()

        {
            var Default = new StudentList();
            Default.Id= 1;
            Default.Name = "abc@gmail.com";
            return View(Default);
        }
        public IActionResult List()
        {
            var StudentList = Repo.StudentListR.GetAllStudents();
            return View(StudentList);
        }
        [HttpPost]
        public IActionResult ListShow(StudentList s1)
        {
            StudentListR.AddStudent(s1);
            return RedirectToAction("List", "Student");
        }

        public IActionResult Edit(int id)
        {
            var student = StudentListR.GetById(id);
            if (student == null) return NotFound();

            return View(student);
        }

        // ✅ EDIT (POST)
        [HttpPost]
        public IActionResult Edit(StudentList s1)
        {
            if (!ModelState.IsValid)
                return View(s1);

            StudentListR.UpdateStudent(s1);
            return RedirectToAction("List");
        }


    }

    public class UniqueEmailAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var email = value as string;
            if((email != null && email.EndsWith("@gmail.com") ))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Email must be from learningwithos.com domain");
        }
    }
}
//Input-- > Input(View)-- >ListShow(POST)-- > List(View)-- >Edit(View)-->Edit(int id)-->Edit(View)-->Edit(post)-->Update00->List(View)