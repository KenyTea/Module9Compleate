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
    public class HDD : Storage
    {
        private TypeDevice uSB2;

        public HDD() : this(0) { }

        public HDD(int SpeedHDD) : this(SpeedHDD, TypeDevice.USB2) { }
       
        public HDD(int SpeedHDD, TypeDevice typeDevice) : base() // -  вызавет констрруктор Storage
        {
            this.SpeedHDD = SpeedHDD;
            this.typeDevice = typeDevice;
        }

        //public HDD(int SpeedHDD, TypeDevice uSB2) : this(SpeedHDD)
        //{
        //    this.uSB2 = uSB2;
        //}

        public int SpeedHDD { get; set; }
        public TypeDevice typeDevice { get; set; }
        public int  Claster { get; set; }
        public int ClasterMomory { get; set; }

        public override double GetMemory()
        {
            return ClasterMomory;
        }

        public override void PrintInfo()
        {
            base.PrintInfo(); // вызываем то, что есть в Printinfo в базовом классе

            Console.WriteLine("Speed HDD -" + SpeedHDD);
            Console.WriteLine("Type device -" + typeDevice);
            Console.WriteLine("Claster -" + typeDevice);
            Console.WriteLine("Claster Momory - " + ClasterMomory);
        }

        public override void Copy() //●	копирование информации на устройства;
        {
            int sum = ClasterMomory / SpeedHDD;

            for (int i = 0; i < sum; i++)
            {
                Console.WriteLine(".");
                Thread.Sleep(500); // засыпание на 500 мили сек.
            }
        }
    }
}
