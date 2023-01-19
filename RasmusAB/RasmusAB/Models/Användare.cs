namespace RasmusAB.Models
{
    public class Användare
    {
        public int Id { get; set; }
        //public string Usertype { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Varukorg? Varukorg { get; set; }
        public bool IsAdmin { get; set; }
        public int? VarukorgId { get; set; }
        public string Namn { get; set; }
        public string Gata { get; set; }
        public string Stad { get; set; }
        public string Land { get; set; }
        public int Telefonnummer { get; set; }
        public string Email { get; set; }

        public Användare()
        {

        }
    }
}
