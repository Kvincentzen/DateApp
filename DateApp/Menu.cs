using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateApp
{
    class Menu
    {
        public static void startMenu()
        {
            int d=0;
            string u, p;
            Console.WriteLine("1.Opretbruger");
            Console.WriteLine("2.Login");
            int i = Convert.ToInt32(Console.ReadLine());
            if (i == 1)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Skriv Brugernavn");
                    u = Console.ReadLine().ToUpper();
                    Console.Clear();
                    Console.WriteLine("Skriv Password");
                    p = Console.ReadLine().ToUpper();
                    Console.Clear();
                    Console.WriteLine("Skriv Password igen");
                    string p2 = Console.ReadLine().ToUpper();
                    if (p == p2)
                    {
                        d++;
                    }
                    else
                    {
                        Console.WriteLine("Password matcher ikke");
                        Console.ReadKey();
                    }
                } while (d == 0);
                SqlCommands.createUser(u, p);

            }
            if (i == 2)
            {
                Console.Clear();
                Console.WriteLine("Skriv Brugernavn");
                u = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Skriv Password");
                p = Console.ReadLine();
                SqlCommands.loginUser(u,p);
            }
            else
            {
                Console.WriteLine("Forkert tastning, du kan kun vælge imellem 1 og 2");
            }

            Console.ReadKey();

        }
        public static void matchMenu()
        {

        }
        public static void userProfil(string user)
        {
            
            Console.WriteLine("");
            Console.WriteLine("Hvad vil du redigere ?");
            Console.WriteLine("1. Person Info");
            Console.WriteLine("2.Interesser");
            Console.WriteLine("3.");
            int v = Convert.ToInt32(Console.ReadLine());
            if (v == 1) {

            }
            if (v == 2)
            {

            }
            else
            {

            }
        }
    }
}
