using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //SqlCommands.createUser("Kristian", "Password");
            //Menu.startMenu();
            //Menu.valgMenu("Kristian","Password");
            //var UID = SqlCommands.findUserID("Kristian3");
            //Console.WriteLine(UID);
            SqlCommands.pullData(1);
            Console.ReadKey();
        }
    }
}
