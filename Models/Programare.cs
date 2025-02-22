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

        public DateTime OraProgramarii { get; set; }
        public string AdresaProgramarii { get; set; }

    }
}
