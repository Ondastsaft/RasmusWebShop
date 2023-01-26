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
            Methods.LäggTillTestKategorier();
            Methods.SkapaLeverantör();
            Methods.LäggTillTestAnvändare();
            Methods.LäggTillTestprodukter();

            bool quit = false;

            while (quit != true)
            {
                if (AnvändarId == 0 && IsAdmin != true)
                {
                    quit = Methods.StartMeny();

                }
                else if (IsAdmin == true)
                {
                    Methods.AdminMeny();
                }
                else if (IsAdmin != true)
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