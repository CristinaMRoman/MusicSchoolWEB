using System.ComponentModel.DataAnnotations;

namespace MusicSchoolWEB.Models
{
    public class Programare
    {
        public int ID { get; set; }

        //Profesor 
        public int? TeacherID { get; set; }
        public Membru? Teacher { get; set; }

        //Student
        public int? StudentID { get; set; }
        public Membru? Student { get; set; }

        [Required]
        public DateTime OraProgramarii { get; set; }

        [Required]
        public string AdresaProgramarii { get; set; }

    }
}
