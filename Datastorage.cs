using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ChatappdesigncapgDay7
{
    public class Datastorage
    {

        public void storeChat(string k)
        {
            System.IO.File.AppendAllText(@"E:\New folder\ChatHistory.txt", k);


        }
        public string ChatHistory()
        {
            string text1 = File.ReadAllText(@"E:\New folder\ChatHistory.txt");
            return text1;


        }
        public void Clients(Server f)
        {


            string listusers = "";

            int l = 0;

            foreach (Client s in f.Clients)
            {
                l++;
                listusers = "\n"+l + "." + s.Username + " " + s.Phnumber + " ";
                File.AppendAllText(@"E:\New folder\Registredclients.txt", listusers);


            }
        }

    }
}

