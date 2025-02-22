using System.ComponentModel.DataAnnotations;

namespace MusicSchoolWEB.Models
{
    public class Membru
    {
        public int ID { get; set; }
        public string Nume { get; set; }
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
        public string Telefon { get; set; }
        public string Adresa { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    }
}
