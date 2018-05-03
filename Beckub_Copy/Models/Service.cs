using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beckub_Copy.Models
{
    /*
     Приложение должно предоставлять следующие возможности:
●	расчет общего количества памяти всех устройств;
●	копирование информации на устройства;
●	расчет времени необходимого для копирования;
●	расчет необходимого количества носителей информации представленных типов для переноса информации.

         */
    public class Service
    {
       

        public double CalculateTotalMemory(List<HDD> hdds, List<Flash> flashs, List<DVD> dvds) //●	расчет общего количества памяти всех устройств;
        {
            double result = 0;
            foreach (HDD item in hdds)

                result += item.GetMemory();

            foreach (Flash item in flashs)

                result += item.GetMemory();

            foreach (DVD item in dvds)

                result += item.GetMemory();

            return result;
        }

        public TimeSpan CalculateTotalTime(List<HDD> hdds)
        {
            double sum = 0;

            foreach (HDD item in hdds)
            {
                sum += item.ClasterMomory * item.SpeedHDD;
            }
            return TimeSpan.FromMilliseconds(sum);
        } //●	расчет времени необходимого для копирования;

        public TimeSpan CalculateTotalTime(List<Flash> flashs)
        {
            double sum = 0;

            foreach (Flash item in flashs)
            {
                sum += item.MemoryFlash * item.SpeedFlash;
            }
            return TimeSpan.FromMilliseconds(sum);
        } //●	расчет времени необходимого для копирования;

        public TimeSpan CalculateTotalTime(List<DVD> dvds)
        {
            double sum = 0;

            foreach (DVD item in dvds)
            {
                sum += item.GetMemory() * item.SpeedRead;
            }
            return TimeSpan.FromMilliseconds(sum);
        } //●	расчет времени необходимого для копирования;

        //private int DevoceCounter(Flash flash, double MemirtData, out int count) // out int count -  возвращает в переменную
        //{
        //    count = Int32.Parse(Math.Ceiling((MemirtData / flash.MemoryFlash)).ToString()); // конвертор БЛЯ + округлитель
        //}
        //----------------------------------------------------------------------------------------------------------------------------
        private int DevoceCounter( Flash flash, double MemirtData) // out int count -  возвращает в переменную
        {
              return Int32.Parse( Math.Ceiling((MemirtData / flash.MemoryFlash)).ToString()); // конвертор БЛЯ + округлитель
        }

         public void GetCount(List<Flash> flash, double MemoriData)
        {

            foreach (Flash item in flash)
            {
               item.Count =  DevoceCounter( item, MemoriData);
            }
        }
//------------------------------------------------------------------------------------------------------------------------------------
        private int DevoceCounter( DVD dvd, double MemirtData) // ref ссылка !!!!!!!!!!!!!!!!!!!
        {
            return  Int32.Parse(Math.Ceiling((MemirtData / dvd.GetMemory())).ToString()); // конвертор БЛЯ + округлитель   
        }

        public void GetCount(List<DVD> dvd, double MemoriData)
        {

            foreach (DVD item in dvd)
            {
                item.Count = DevoceCounter(item, MemoriData);
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------
        private int DevoceCounter( HDD hdd, double MemirtData) // ref ссылка !!!!!!!!!!!!!!!!!!!
        {
            return  Int32.Parse(Math.Ceiling((MemirtData / hdd.GetMemory())).ToString()); // конвертор БЛЯ + округлитель
        }

        public void GetCount(List<HDD> hdd, double MemoriData)
        {

            foreach (HDD item in hdd)
            {
                item.Count = DevoceCounter(item, MemoriData);
            }
        }
    }
}
