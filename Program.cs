using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatappdesigncapgDay7

{
    public class Program
    {
       static ConsoleKeyInfo cki;
        public  static void Main(string[] args)
        {
            Server n = new Server();
            Client z = new Client();
            Datastorage d = new Datastorage();


            Client cons = new Client("Vimal", 9875632455, n);
            Client cons1 = new Client("Arjun", 9884056987, n);


            Console.WriteLine("Press 1 if Existing user \nPress 2 if New user ");
           int cw= Convert.ToInt32(Console.ReadLine());
            if (cw == 2)
            {
                Console.WriteLine("hi register now!");
                Console.WriteLine("enter your username");
                String a = Console.ReadLine();
                Console.WriteLine("enter your mobile number");
                long b = Convert.ToInt64(Console.ReadLine());



               Console.WriteLine( z.Clientregisteration(a, b, n,d));
            }
            Userlogin();
            void Userlogin()
            {
                Console.WriteLine("enter your phone number  For validation");

                string m = Console.ReadLine();
                long h = Convert.ToInt64(m);
                Console.WriteLine("enter your username number  For validation");
                string q = Console.ReadLine();
                if(n.UserValidation(h, q) == true)
                {
                    Console.WriteLine("Login sucessfull !");
                    Features(h, q);
                }
                else
                {
                    Console.WriteLine("Validation Unsucessfull ! Either Username or Phonenumber is Incorrect");
                    Console.ReadKey();
                }
            }
            void Features(long h,string q) {
                
                Console.WriteLine();
                Console.WriteLine("Select an option :");
                Console.WriteLine();
                Console.WriteLine("1. To add an contact press 1");
                Console.WriteLine("2. To view Your contacts press 2");
                Console.WriteLine("3. To delete your contacts press 3");
                Console.WriteLine("4. To edit your details press 4");
                Console.WriteLine("5. To Chat  press 5");
                Console.WriteLine("6. To View your Chat history press 6");

                Console.WriteLine();
                string l = Console.ReadLine();
                int w = Convert.ToInt32(l);

                switch (w)
                {

                    case 1:
                        Console.WriteLine(z.addContacts(h, n));
                        Features( h,q);
                        break;
                    case 2:
                        Console.WriteLine("Your Conatct List:");
                        Console.WriteLine(z.ViewContact(h));
                        Features(h,q);
                        break;
                    case 3:
                        Console.WriteLine("enter the username the contact to delete");
                       Console.WriteLine( z.ViewContact(h));
                        string j = Console.ReadLine();
                        Console.WriteLine(z.DeleteContact(j,n));
                        Features( h,q);
                        break;
                    case 4:
                        Console.WriteLine("Choose the option you want to edit :");
                        Console.WriteLine("Press 1 to edit Username");
                        Console.WriteLine("Press 2 to edit Ph-number");
                        int c = Convert.ToInt32(Console.ReadLine());
                        if (c == 1)
                        {
                            Console.WriteLine("Enter the new username to be edited");
                            string p = Console.ReadLine();
                            Console.WriteLine(n.EditUsername(q,p));
                        }
                        else
                        {
                            Console.WriteLine("Enter the new ph-number to be edited");
                             long p = Convert.ToInt64(Console.ReadLine());
                           Console.WriteLine(n.EditPhnumber(h, p));
                        }
                        Features(h, q);
                        break;
                    case 5:
                        z.Chat(h, q,n,d,cki);
                        break;
                    case 6:
                        Console.WriteLine("your Chat history");
                        Console.WriteLine(d.ChatHistory());
                        Features(h, q);
                        break;

                    default:
                        Console.WriteLine("invalid option");
                        Features( h,q);
                        break;


                }
            }
            


        }



    }


}

