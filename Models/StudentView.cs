using learningwithos.Controllers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace learningwithos.Models
{
    public class StudentView
    {

        
        
        public int Id { get; set; }


        [Required]
        [DisplayName("Student_Name")]
        [StringLength(maximumLength:12,MinimumLength =8)]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage ="your email is wrong")]

        [UniqueEmailAttribute]
        public string Email { get; set; }
        [Required(ErrorMessage ="The password is needed")]
        public string Password{ get; set; }

        [Compare("Password",ErrorMessage ="your password is not matched try again")]
        public string Repass { get; set; }

        public int PassingYear { get; set; }
        [Range(18,30)]
        public int Age { get; set; }
    }
}
