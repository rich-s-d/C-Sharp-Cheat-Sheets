﻿// note: this program was downloaded from Pluralsight and uses .NET Framework 4.5, which can only be run on Windows.

using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var buffer = new Buffer<double>();

            foreach (var item in buffer)
            {
                System.Console.WriteLine("Do something");
            }

            ProcessInput(buffer);
            ProcessBuffer(buffer);
        }

        private static void ProcessBuffer(IBuffer<double> buffer)
        {
            var sum = 0.0;
            Console.WriteLine("Buffer: ");
            while (!buffer.IsEmpty)
            {
                sum += buffer.Read();
            }
            Console.WriteLine(sum);
        }

        private static void ProcessInput(IBuffer<double> buffer)
        {
            while (true)
            {
                var value = 0.0;
                var input = Console.ReadLine();

                if (double.TryParse(input, out value))
                {
                    buffer.Write(value);
                    continue;
                }
                break;
            }
        }
    }
}
