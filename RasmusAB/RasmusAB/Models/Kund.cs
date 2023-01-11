namespace RasmusAB.Models
{
    public class Kund : Användare
    {
        public int Id { get; set; }
        //public int varukorgsId { get; set; }
        public Kund(string name, string password)
        {
            name = Username;
            password = Password;
        }
        private Kund()
        {

        }

    }
}
