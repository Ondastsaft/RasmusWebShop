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
            Methods.LäggTillAnvändare();
            Methods.LäggTillTestprodukter();

            bool quit = false;
            //AnvändarId = 1;

            while (quit != true)
            {

                quit = Methods.RunMe();

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