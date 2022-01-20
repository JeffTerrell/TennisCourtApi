namespace TennisCourt.Models
{
    public class Court
    {
        public int CourtId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string SurfaceType { get; set; }
        public string Address { get; set; }
        public bool Public { get; set; }
    }
}