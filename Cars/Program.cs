﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = ProcessFile("fuel.csv");

            var query =
                from car in cars
                where car.Manufacturer =="BMW" && car.Year ==2016
                orderby car.Combined descending, car.Name ascending
                select car;

            foreach (var car in query.Take(10))
            {
                Console.WriteLine($"{car.Name} : {car.Combined}" );
            }

        }

        private static List<Car> ProcessFile(string path)
        {
            return
                (from line in File.ReadAllLines(path).Skip(1)
                 where line.Length > 1
                 select Car.ParseFromCsv(line)).ToList();
        }

    }
}
