using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEvents
{   
    class Program
    {        
        delegate int Operation(int x, int y);

        static void Main(string[] args)
        {
            //Exmpl01();

            Exmpl02(7);
        }

        public static void Exmpl02(int num)
        {
            CityEvents city = new CityEvents();
            FireService fireService = new FireService();
            Ambulance ambulance = new Ambulance();
            Police police = new Police();

            city.OnEvent += police.Message;
            city.OnEvent += fireService.Message;
            city.OnEvent += ambulance.Message;

            for (int i = 0; i < num; i++)
            {
                city.EventSignal();
            }
        }

        public static void Exmpl01()
        {
            Operation operations = Plus;
            operations += Minus;
            operations += Mult;
            operations += Div;

            Random rnd = new Random();

            for (int j = 0; j < 5; j++)
            {
                int x = rnd.Next(-2, 3);
                int y = rnd.Next(-2, 3);
                Console.WriteLine($"x = {x}, y = {y}");
                foreach (Operation i in operations.GetInvocationList())
                {
                    try
                    {
                        int res = i.Invoke(x, y);
                        Console.WriteLine(i.Method.Name + ": " + res);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(i.Method.Name + ": " + ex.Message);
                    }
                }
                Console.WriteLine("-----------------------------");
            }
        }
        

        static int Plus(int x, int y)
        {
            return x + y;
        }
        static int Mult(int x, int y)
        {
            return x * y;
        }
        static int Minus(int x, int y)
        {
            return x - y;
        }
        static int Div(int x, int y)
        {
            return x / y;
        }

    }
}
