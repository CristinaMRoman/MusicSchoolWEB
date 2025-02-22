using System.ComponentModel.DataAnnotations;

namespace MusicSchoolWEB.Models
{
    public class Feedback
    {
        public int ID { get; set; }
        public int? ProgramareID { get; set; }
        public Programare? Programare { get; set; }

        public int? MembruID { get; set; }
        public Membru? Membru { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Rating-ul trebuie să fie între 1 și 5.")]
        public int Stars { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Descrierea nu poate avea mai mult de 500 de caractere.")]
        public string Description { get; set; }

    }
}
