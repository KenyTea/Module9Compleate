using Beckub_Copy;
using Beckub_Copy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module9 // Наследование
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Введите объём данных");
            double temp = double.Parse(Console.ReadLine());

            GenerateDevice gener = new GenerateDevice();
            gener.GenarateFlash();

            Service serv = new Service();
            double totalmemory =  serv.CalculateTotalMemory(new List<HDD>(), gener.flash, new List<DVD>()); // new List<HDD>() -  пустой объёкт клвсса
            Console.WriteLine("Общий объём флэшак = {0} ({1}) ", totalmemory , gener.flash.Count); ;
            TimeSpan time = serv.CalculateTotalTime(gener.flash);
            Console.WriteLine(time.TotalMinutes);
            serv.GetCount(gener.flash, temp);
            foreach (Flash item in gener.flash)
            {
                item.PrintInfo();
            }
        }
    }
}
