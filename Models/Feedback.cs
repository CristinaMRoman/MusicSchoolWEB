namespace MusicSchoolWEB.Models
{
    public class Feedback
    {
        public int ID { get; set; }
        public int? ProgramareID { get; set; }
        public Programare? Programare { get; set; }

        public int? MembruID { get; set; }
        public Membru? Membru { get; set; }

        public int Stars { get; set; }
        public string Description { get; set; }

    }
}
