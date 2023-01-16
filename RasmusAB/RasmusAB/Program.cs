namespace RasmusAB
{
    public class Program
    {
        public static int AnvändarId { get; set; }
        public static bool IsAdmin { get; set; }

        static void Main(string[] args)
        {
            bool quit = false;
            while (quit != true)
            {
                  quit = Methods.RunMe();
                //Methods.LäggTillAnvändare();
                //Methods.LäggTillKategori();
                //Methods.LäggTillTestprodukter();
                //Methods.RensaTabell("Varukorgar");
                //Methods.RensaTabell("Användare");
                //Methods.LäggProduktIVarukorg(2);
            }

        }

    }
}