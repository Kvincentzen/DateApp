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
                int uID = SqlCommands.findUserID(u);
                valgMenu(uID);
            }
            else
            {
                Console.WriteLine("Forkert tastning, du kan kun vælge imellem 1 og 2");
            }

            Console.ReadKey();

        }
        public static void valgMenu(int uID)
        {
            Console.Clear();
            Console.WriteLine("1.Check Matches");
            Console.WriteLine("2.Opret/Rediger i din UserProfil");
            Console.WriteLine("3.Rediger i din SøgeProfil");
            int v = Convert.ToInt32(Console.ReadLine());
            if (v == 1)
            {
                matchMenu(uID);
            }
            if (v == 2)
            {
                userProfil(uID);
            }
            if (v == 3)
            {
                searchProfil(uID);
            }
            else
            {
                valgMenu(uID);
            }
        }
        public static void matchMenu(int uID)
        {
            Console.Clear();
            Console.WriteLine("1.Find matches");
            int v = Convert.ToInt32(Console.ReadLine());
            if (v == 1)
            {

            }
            else { }
        }
        public static void userProfil(int uID)
        {
            
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
            if (v == 3)
            {

            }
            else
            {

            }
        }
        public static void searchProfil(int uID)
        {

        }
    }
}
