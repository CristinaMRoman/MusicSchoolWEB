namespace MusicSchoolWEB.Models
{
    public class MembruInstrument
    {
        public int ID { get; set; }

        // Relatii 
        public int? MembruID { get; set; }
        public Membru? Membru { get; set; }

        public int? InstrumentID { get; set; }
        public Instrument? Intrument { get; set; }

    }
}
