using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



namespace ChatappdesigncapgDay7
{
    public class Server
    {
        


        public IList<Client> Clients = new List<Client>();

        public bool UserValidation(long m,string n)
        {
            foreach (Client s in Clients)
            {
                if(s.Username==n && s.Phnumber == m)
                {
                    return true;
                }
            }
            return false;

        }

        public string Displayusers()
        {
            string temp = "";
            string listusers = "";

            int l = 0;

            foreach (Client s in Clients)
            {
                l++;
                temp = l + "." + s.Username + " " + s.Phnumber + " ";
                listusers += "\n" +temp;


            }

            return listusers;
        }

        public bool Ispresent(string h)
        {
            foreach(Client j in Clients)
            {
                if(j.Username==(h))
                {

                    return true;
                }
            }
            return false;
        }


        public int IndexOf(string h)
        {
            for (int i = 0; i < Clients.Count; i++)
            {
              
                if (Clients[i].Username == h)
                {
                    return i;
                }
            }
            return -1;
        }
        public string EditUsername(string g,string p)
        {
            for (int i = 0; i < Clients.Count; i++)
            {
                if (Clients[i].Username == g)
                {
                    Clients[i].Username = p;
                    return "Username has been updated sucessfully";
                }
                
            }
            
           
                return "updation failed";
            

        }

        public string EditPhnumber(long g, long p)
        {
            for (int i = 0; i < Clients.Count; i++)
            {
                if (Clients[i].Phnumber == g)
                {
                    Clients[i].Phnumber = p;
                    return "Ph-number has been updated sucessfully";
                }

            }


            return "updation failed";


        }
        public string Sendmessage(string sender, string receiver, string message,Datastorage d)
        {
            int h = IndexOf(receiver);
            if (h == -1)
            {

                return "no contacts found";
            }
            else
            {


                string g = ToReciver(sender, receiver, message,d);
                Console.WriteLine("Message Sending....please wat...");
                Thread.Sleep(4000);
                Console.WriteLine("Message sent sucessfully");
                Console.WriteLine();
                return g;

            }

        }

        public string ToReciver(string sender, string receviver, string message,Datastorage d)
        {
            string k = "\n"+sender + ":\n" + message;
            d.storeChat(k);
            
            return k;

        }
      

        

    }
} 