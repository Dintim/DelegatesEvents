using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEvents
{
    public enum Occasion {fire, flood, blast, robbery, assault, parade, marathon }
    public delegate void DEvent(Occasion occasion);    

    public class CityEvents
    {
        Random rnd = new Random();
        public event DEvent OnEvent;
        public void EventSignal()
        {            
            Occasion tmp = (Occasion)rnd.Next(Enum.GetNames(typeof(Occasion)).Length);
            Console.WriteLine(tmp);
            OnEvent(tmp);            
        }
    }

    public class FireService
    {
        public void Message(Occasion occasion)
        {
            if (occasion==Occasion.fire)
                Console.WriteLine("Пожарные едут тушить пожар");
            else if (occasion==Occasion.flood)
                Console.WriteLine("Пожарные находятся в части");
            else if (occasion==Occasion.blast)
                Console.WriteLine("Пожарные едут погасить огонь от взрыва");
            else if (occasion == Occasion.robbery)
                Console.WriteLine("Пожарные находятся в части");
            else if (occasion == Occasion.assault)
                Console.WriteLine("Пожарные находятся в части");
            else if (occasion == Occasion.parade)
                Console.WriteLine("Пожарные дежурят на параде");
            else if (occasion == Occasion.marathon)
                Console.WriteLine("Пожарные дежурят на марафоне");
        }
    }

    public class Ambulance
    {
        public void Message(Occasion occasion)
        {
            if (occasion == Occasion.fire)
                Console.WriteLine("Скорая помощь едет помогать пострадавшим от пожара");
            else if (occasion == Occasion.flood)
                Console.WriteLine("Скорая помощь едет помогать пострадавшим от наводнения");
            else if (occasion == Occasion.blast)
                Console.WriteLine("Скорая помощь едет помогать пострадавшим от взрыва");
            else if (occasion == Occasion.robbery)
                Console.WriteLine("Скорая помощь находится в больнице");
            else if (occasion == Occasion.assault)
                Console.WriteLine("Скорая помощь едет помогать пострадавшим от нападения");
            else if (occasion == Occasion.parade)
                Console.WriteLine("Скорая помощь дежурит на параде");
            else if (occasion == Occasion.marathon)
                Console.WriteLine("Скорая помощь дежурит на марафоне");
        }
    }

    public class Police
    {
        public void Message(Occasion occasion)
        {
            if (occasion == Occasion.fire)
                Console.WriteLine("Полиция едет оградить зону пожара");
            else if (occasion == Occasion.flood)
                Console.WriteLine("Полиция едет патрулировать зону наводнения от мародеров");
            else if (occasion == Occasion.blast)
                Console.WriteLine("Полиция едет расследовать причину взрыва");
            else if (occasion == Occasion.robbery)
                Console.WriteLine("Полиция едет на поимку грабителя");
            else if (occasion == Occasion.assault)
                Console.WriteLine("Полиция едет на поимку нападавшего");
            else if (occasion == Occasion.parade)
                Console.WriteLine("Полиция дежурит на параде");
            else if (occasion == Occasion.marathon)
                Console.WriteLine("Полиция дежурит на марафоне");
        }
    }
}
