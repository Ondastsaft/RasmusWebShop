﻿using RasmusAB.Models;

namespace RasmusAB
{
    public class Program
    {
        public static int AnvändarId { get; set; }
        public static bool IsAdmin { get; set; }
        public static Varukorg TempVarukorg { get; set; }

        static void Main(string[] args)
        {
            //Methods.LäggTillKategori();
            Methods.LäggTillAnvändare();
            Methods.LäggTillTestprodukter();
            Methods.SkapaLeverantör();
            bool quit = false;
            AnvändarId = 1;

            //while (quit != true)
            //{
            //    //Methods.ÄndraProdukt();
            //    quit = Methods.RunMe();
            //    //Methods.LäggTillAnvändare();
            //    //Methods.LäggTillKategori();
            //    //Methods.LäggTillTestprodukter();
            //    //Methods.RensaTabell("Varukorgar");
            //    //Methods.RensaTabell("Användare");
            //    //Methods.LäggProduktIVarukorg(2);
            //}

        }

    }
}