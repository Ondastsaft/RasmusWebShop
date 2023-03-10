namespace RasmusAB.Models
{
    public class Användare
    {
        public int AnvändareId { get; set; }
        //public string Usertype { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Varukorg> Varukorgar { get; set; }
        public bool Admin { get; set; }
        public string Namn { get; set; }
        public string Gata { get; set; }
        public string Stad { get; set; }
        public string Land { get; set; }
        public int Telefonnummer { get; set; }
        public string Email { get; set; }

        public Användare()
        {
            Varukorgar = new HashSet<Varukorg>();
        }
    }
}
