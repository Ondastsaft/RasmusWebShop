namespace RasmusAB.Models
{
    public class Användare
    {
        public int Id { get; set; }
        //public string Usertype { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Varukorg AnvändareVarukorg { get; set; }
        public bool IsAdmin { get; set; }
        public int VarukorgsId { get; set; }

        public Användare()
        {
            AnvändareVarukorg = new Varukorg();
        }
    }
}
