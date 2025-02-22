using System.ComponentModel.DataAnnotations;

namespace MusicSchoolWEB.Models
{
    public class Membru
    {
        public int ID { get; set; }

        [Required]
        public string Nume { get; set; }

        [Required]
        public string Prenume { get; set; }
        [Display (Name = "Full Name")]
        public string FullName
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^\+40\d{9}$", ErrorMessage = "Numărul de telefon trebuie să fie în formatul +40XXXXXXXXX.")]
        public string Telefon { get; set; }
        public string Adresa { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    }
}
