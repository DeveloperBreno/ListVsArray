using ListVsArray.MyModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ListVsArray
{
    class Program
    {
        static void Main(string[] args)
        {

            var monitor = "RAM_S\tRAM_e\tStopwatch\n";
            {
                Process currentProcess = Process.GetCurrentProcess();
                long usedMemory = currentProcess.PrivateMemorySize64;
                monitor += usedMemory.ToString() + "\t";
            }

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            Console.WriteLine("List:");
            RunTestWithList();

            //Console.WriteLine("Array:");
            //RunTestWithArray();

            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            {
                Process currentProcess = Process.GetCurrentProcess();
                long usedMemory = currentProcess.PrivateMemorySize64;
                monitor += usedMemory.ToString() + "\t";
            }

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            monitor += elapsedTime;
            Console.WriteLine(monitor);

            Console.ReadLine();
        }

        private static void RunTestWithArray()
        {
            var myArrayPersonAndTheirPhones = new PersonArrayPhones[] {
            new PersonArrayPhones {
                    Id = 1,
                    PhoneNumbers = new PhoneNumber[]{  new PhoneNumber() { CountryCode = "+55" , Number = "11978300117" , PhoneCodeByState = "011"} },
                    CPF = "455.170.015-05",
                    RG = "30.342.923-9",
                    Name = "Arthur Manuel Raul Alves"
                },
                new PersonArrayPhones
                {
                    Id = 2,
                    PhoneNumbers = new PhoneNumber[]{ new PhoneNumber() { CountryCode = "+55" , Number = "119327830017" , PhoneCodeByState = "011"},
                                                            new PhoneNumber() { CountryCode = "+55" , Number = "119756830011" , PhoneCodeByState = "011"}},
                    Name = "Juliana Tânia Sônia Pinto",
                    RG = "12.516.228-5",
                    CPF = "684.353.799-57"
                }
            };

            foreach (var person in myArrayPersonAndTheirPhones)
            {
                var jsonPeson = JsonConvert.SerializeObject(person);
                var x = jsonPeson.Replace(",", ",\n");
                x = x + " it's a test";
            }
        }

        private static void RunTestWithList()
        {
            var myListPersonAndTheirPhones = new List<PersonListPhone>()
            {
                new PersonListPhone {
                    Id = 1,
                    PhoneNumbers = new List<PhoneNumber>(){ new PhoneNumber() { CountryCode = "+55" , Number = "11978300117" , PhoneCodeByState = "011"} },
                    CPF = "455.170.015-05",
                    RG = "30.342.923-9",
                    Name = "Arthur Manuel Raul Alves"
                },
                new PersonListPhone
                {
                    Id = 2,
                    PhoneNumbers = new List<PhoneNumber>(){ new PhoneNumber() { CountryCode = "+55" , Number = "119327830017" , PhoneCodeByState = "011"},
                                                            new PhoneNumber() { CountryCode = "+55" , Number = "119756830011" , PhoneCodeByState = "011"}},
                    Name = "Juliana Tânia Sônia Pinto",
                    RG = "12.516.228-5",
                    CPF = "684.353.799-57"
                }
            };

            foreach (var person in myListPersonAndTheirPhones)
            {
                var jsonPeson = JsonConvert.SerializeObject(person);
                var x = jsonPeson.Replace(",", ",\n");
                x = x + " it's a test";
            }
        }
    }
}
