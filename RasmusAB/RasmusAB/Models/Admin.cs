namespace RasmusAB.Models
{
    public class Admin : Användare
    {
        public int Id { get; set; }
        public Admin(string name, string password)
        {

        }
        private Admin()
        {

        }

    }
}
