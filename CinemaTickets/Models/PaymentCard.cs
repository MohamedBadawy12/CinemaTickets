using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CinemaTickets.Models
{
    public class PaymentCard
    {
        [Key]
		public int Id { get; set; }
        [Display(Name = "Card Number")]
        [Required(ErrorMessage = "Card Number Is Required")]
        public decimal CardNumber { get; set; }
        [Display(Name = "Expired Date")]
        [Required(ErrorMessage = "Expired Date Is Required")]
        public string ExpiredDate { get; set; }
        [Display(Name = "CVV")]
        [Required(ErrorMessage = "CVV Is Required")]
        public int Cvv { get; set; }
	}
}
