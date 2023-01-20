using RasmusAB.Models;

namespace RasmusAB
{
    public class Program
    {
        public static int AnvändarId { get; set; }
        public static bool IsAdmin { get; set; }
        public static Varukorg TempVarukorg { get; set; }

        static void Main(string[] args)
        {
            //Methods.LäggTillTestKategorier();
            //Methods.SkapaLeverantör();
            //Methods.LäggTillAnvändare();
            //Methods.LäggTillTestprodukter();

            bool quit = false;
            AnvändarId = 0;

            while (quit != true)
            {
                if (AnvändarId == 0)
                {
                    quit = Methods.StartMeny();

                }
                else if (IsAdmin == true)
                {
                    Methods.AdminMeny();
                }

                else
                {
                    Methods.KundMeny();
                }

            }
        }



        //    //Methods.ÄndraProdukt();
        //    //Methods.LäggTillAnvändare();
        //    //Methods.LäggTillKategori();
        //    //Methods.LäggTillTestprodukter();
        //    //Methods.RensaTabell("Varukorgar");
        //    //Methods.RensaTabell("Användare");
        //    //Methods.LäggProduktIVarukorg(2);
    }


}