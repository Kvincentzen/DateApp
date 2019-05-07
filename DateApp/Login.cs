using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateApp
{
    class Login
    {
        public static void valgMenu(string u, string p) {
            Console.WriteLine("1.Check Matches");
            Console.WriteLine("2.Rediger i din Profil");
            Console.WriteLine("3.Rediger i din SøgeProfil");
            int i = Convert.ToInt32(Console.ReadLine());
        }
    }
}
