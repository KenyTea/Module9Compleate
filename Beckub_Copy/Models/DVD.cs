using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Beckub_Copy.Models
{
    /*Каждый носитель информации является объектом соответствующего класса: 
●	Flash-память — класс «Flash»;
●	класс DVD-диск — класс «DVD»;
●	класс съемный HDD — класс «HDD».
Все три класса являются производными от абстрактного класса «Носитель информации» — класс «Storage». Базовый класс («Storage») содержит следующие закрытые поля:
*/
    public enum TypeDVD { Oneside, TwoSide }
    public class DVD : Storage
    {
        public DVD() : this(0)
        {

        }
        public DVD(int SpeedWrite) : this(SpeedWrite, TypeDVD.Oneside)
        {

        }
        public DVD(int SpeedWrite, TypeDVD typeDVD) : base()
        {
            this.SpeedWrite = SpeedWrite;
            this.typeDVD = typeDVD;
        }
        public int SpeedWrite { get; set; }
        public int SpeedRead { get; set; }
        public TypeDVD typeDVD { get; set; }

        public DVD(string name)
        {
            base.Name = name;
            base.Model = "gfdkfl;k";
        }

        public override double GetMemory()
        {
            if (TypeDVD.Oneside == typeDVD)
                return 4.7;
            else
                return 9.4;
        }

        public sealed override void Copy()   // sealed - запечатываем метод и никто из наследников  ни кто не может изменить его
        {
            int sum = (int)GetMemory() / SpeedWrite;

            for (int i = 0; i < sum; i++)
            {
                Console.WriteLine(".");
                Thread.Sleep(500); // засыпание на 500 мили сек.
            }
        }

        public override void PrintInfo()
        {
            base.PrintInfo(); // вызываем то, что есть в Printinfo в базовом классе

            Console.WriteLine("Speed Write -" + SpeedWrite);
            Console.WriteLine("Speed Read -" + SpeedRead);
            Console.WriteLine("Type DVD -" + typeDVD);
        }
    }

}
