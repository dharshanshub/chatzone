using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatappdesigncapgDay7
{
    public class Client
    {
        
        #region fields

        public string Username { get; set; }
        public long Phnumber { get; set; }
        #endregion
        IList<Client> contact_list = new List<Client>();

        #region public methods
        public Client()
        {

        }
        public Client(string username, long number, Server s)
        {
            s.Clients.Add(new Client { Username = username, Phnumber = number });
       }


      

        public string Clientregisteration(String name, long number, Server s,Datastorage d)
        {
            s.Clients.Add(new Client { Username = name, Phnumber = number });
            d.Clients(s);
         
            return "registartion sucessfull";



        }
        public string addContacts(long ph,  Server s)
        {
            Console.WriteLine("enter  the name you want to add to your contact list");

            Console.WriteLine(s.Displayusers());



            string h = Console.ReadLine();

            if (s.Ispresent(h) == true)
            {


                return Contact_ListCreation(h, ph,s);

            }
            else
            {
                return "user does not exsist";
            }

        }

        public string Contact_ListCreation(string h, long ph,Server s)
        {

            int k = s.IndexOf(h);

            contact_list.Add((Client)s.Clients[k]);
            
            return "contacts added sucessfully";

           
        }

        public string ViewContact(long v)
        {
            string temp = "";
            string listusers = "";

            int l = 0;

            foreach (Client s1 in contact_list)
            {
                l++;
                temp = l + "." + s1.Username + " " + s1.Phnumber + " ";
                listusers += "\n"+temp;


            }
           return listusers;
        }

        public string DeleteContact(string j, Server s)
        {
            int h = s.IndexOf(j);
                if (h == -1)
                {
                   
                return "no contacts found";
            }
            else
            {
                contact_list.Remove((Client)s.Clients[h]);
                return "Contact deleted sucessfully";
            }
            
           
        }
        public void Chat(long h,string q,Server n,Datastorage d,ConsoleKeyInfo cki)
        {
            Console.WriteLine("Enter the username you want to chat");
            Console.WriteLine(ViewContact(h));
            string ch = Console.ReadLine();
            Console.WriteLine("Enter the message");
            string message = Console.ReadLine();
            string mess=n.Sendmessage(q, ch, message,d);
            Console.WriteLine("hi " + ch + " you have recevied a message");
            Console.WriteLine("click enter to view");
            Console.ReadKey();
           Console.WriteLine( mess);
            Console.WriteLine("click enter to reply");

            cki=Console.ReadKey();
            if (cki.Key == ConsoleKey.Enter) {
                reply(q, ch, n, d,cki);
            }
            else { Console.Clear(); }
           
        }
     
        public void reply( string q, string ch,Server n,Datastorage d, ConsoleKeyInfo cki)
        {
            Console.WriteLine("Enter the message");
            string message = Console.ReadLine();
            string mess=n.Sendmessage(ch, q, message, d);
            Console.WriteLine("hi " + q + " you have recevied a message");
            Console.WriteLine("click enter to view");
            Console.ReadKey();
            Console.WriteLine(mess);
            Console.WriteLine("click enter to reply or else press esc");
            Console.ReadKey();
            cki = Console.ReadKey();
            if (cki.Key == ConsoleKey.Enter)
            {
                reply(ch, q, n, d,cki);
            }
            else
            {
                Console.Clear();
            }
        }


    }
    #endregion
}