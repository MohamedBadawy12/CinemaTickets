using System.ComponentModel.DataAnnotations;

namespace CinemaTickets.Data.CodeOfRegister
{
    public class CodeRegister
    {
        [Display(Name ="Code Number")]
        [Required(ErrorMessage ="Code Is Required")]
        public int CodeNumber { get;set; } 
    }
}
