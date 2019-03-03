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

        /// <summary>
        /// Проект "Город и его службы"
        /// </summary>
        /// <param name="num"></param>
        public static void Exmpl02(int num)
        {
            //Наша главная цель в данном проекте - еще раз показать, как возникающее событие, в данном случае - пожар в одном из домов города, 
            //обрабатывается по-разному городскими службами - пожарными, милицией, скорой помощью. Конечно, все упрощено, в реальном городе 
            //событиями являются не только пожары и преступления, но и более приятные ситуации: день города, открытие фестивалей и выставок, 
            //строительство новых театров и институтов.
            //Написать приложение, которое будет имитировать события в городе и в зависимости от вида событий вызывать те или иные события.  

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

        /// <summary>
        /// Пример "Плохая служба"
        /// </summary>
        public static void Exmpl01()
        {
            //Как быть, если в списке вызовов есть "плохой" экземпляр, при вызове которого возникает ошибка, приводящая к выбрасыванию исключительной ситуации? 
            //Тогда стоящие за ним в очереди экземпляры не будут вызваны, хотя они вполне могли бы выполнить свою часть работы. 
            //В этом случае полезно использовать метод GetInvocationList и в цикле поочередно вызывать делегатов. 
            //Вызов делегата следует поместить в охраняемый блок, тогда при возникновении исключительной ситуации в обработчике ситуации можно получить 
            //и выдать пользователю всю информацию о нарушителе, а цикл продолжит выполнение очередных делегатов из списка вызова.
            //Написать приложение которое отлавливает всевозможные ошибки и транслирует их с помощью делегатов.

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
