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
                //matchMenu(uID);
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
                //SqlCommands.Matches(uID);
            }
            else { }
        }
        public static void userProfil(int uID)
        {
            SqlCommands.pullData(uID);
            Console.WriteLine("1. Opret Userprofil");
            Console.WriteLine("2. Rediger Højde");
            Console.WriteLine("3. Rediger Vægt");
            int v = Convert.ToInt32(Console.ReadLine());
            if (v == 1) {
                int loop = 0;
                bool up = true;
                string fname, lname = "", height, kilo;
                int age, sex = 0;
                Console.WriteLine("Skriv dit fornavn");
                fname = Console.ReadLine();
                do
                {
                    Console.Clear();
                    Console.WriteLine("Vil ud have dit efternavn med ?\n1. ja \n2. nej");
                    int v2 = Convert.ToInt32(Console.ReadLine());
                    if (v2 == 2)
                    {
                        up = false;
                        loop++;
                    }
                    if (v2 == 1)
                    {
                        Console.WriteLine("Skriv dit efternavn");
                        lname = Console.ReadLine();
                        up = true;
                        loop++;
                    }
                } while (loop == 0);
                Console.WriteLine("Hvad er din højde");
                height = Console.ReadLine();
                Console.WriteLine("Hvad er din vægt");
                kilo = Console.ReadLine();
                Console.WriteLine("Hvad er din alder");
                age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Er du: \n1.Mand \n2.Dame");
                int v3 = Convert.ToInt32(Console.ReadLine());
                if (v3 == 1)
                {
                    Console.WriteLine("er du til\n1.Mænd\n2.kvinder");
                    int v4 = Convert.ToInt32(Console.ReadLine());
                    if (v4 == 1)
                    {
                        sex = 1;
                    }
                    if (v4 == 2)
                    {
                        sex = 2;
                    }
                }
                if (v3 ==2)
                {
                    Console.WriteLine("er du til\n1.Mænd\n2.kvinder");
                    int v4 = Convert.ToInt32(Console.ReadLine());
                    if (v4 == 1)
                    {
                        sex = 3;
                    }
                    if (v4 == 2)
                    {
                        sex = 4;
                    }
                }
                if (up == true)
                {
                    SqlCommands.createUProfil(fname, lname, age, height, kilo, sex, uID);
                }
                if (up == false)
                {
                    SqlCommands.createUProfil(fname, age, height, kilo, sex, uID);
                }
                valgMenu(uID);
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
