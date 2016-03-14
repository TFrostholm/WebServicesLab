﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebServiceLab;

namespace WSClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.Write("1.List hotels\n2.Select a hotel\n3.List all hotels in Roskilde\n4.List all single rooms for hotels in Roskilde\n5.Update holtel_No 3\n6.Insert a new hotel");
            Console.Write("\n7.Delete a hotel\n8.Update Room prices\n0.End\nPlease enter your choice:");
            int choice = int.Parse(Console.ReadLine());
            Console.Clear();
            while (choice != 0)
            {
                switch (choice)
                {
                    case 1:
                        Exercise1();
                        break;
                    case 2:
                        Exercise2();
                        break;
                    case 3:
                        Exercise3();
                        break;
                    case 4:
                        Exercise4();
                        break;
                    case 5:
                        Exercise5();
                        break;
                    case 6:
                        Exercise6();
                        break;
                    case 7:
                        Exercise7();
                        break;
                    case 8:
                        Exercise8();
                        break;
                }
                Console.Write("1.List hotels\n2.Select a hotel\n3.List all hotels in Roskilde\n4.List all single rooms for hotels in Roskilde\n5.Update holtel_No 3\n6.Insert a new hotel");
                Console.Write("\n7.Delete a hotel\n8.Update Room prices\n0.End\nPlease enter your choice:");
                choice = int.Parse(Console.ReadLine());
                Console.Clear();
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

            Console.ReadLine();
        }

        const string ServerUrl = "http://localhost:50000";

        private static void Exercise1()
        {
            HttpClientHandler handler = new HttpClientHandler();
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/Hotels").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        IEnumerable<Hotel> hotelData = response.Content.ReadAsAsync<IEnumerable<Hotel>>().Result;
                        foreach (var hotel in hotelData)
                        {
                            Console.WriteLine(hotel);
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Error");
                }
            }
        }

        private static void Exercise2()
        {
            HttpClientHandler handler = new HttpClientHandler();
            using (var client = new HttpClient(handler))
            {


                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    Console.WriteLine("Please enter a hotel number: ");
                    int input = int.Parse(Console.ReadLine());

                    var response = client.GetAsync("api/Hotels/" + input).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var hotel = response.Content.ReadAsAsync<Hotel>().Result;
                            Console.WriteLine(hotel);

                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Error");
                }
            }
        }

        private static void Exercise3()
        {
            throw new NotImplementedException();
        }

        private static void Exercise4()
        {
            throw new NotImplementedException();
        }

        private static void Exercise5()
        {
            throw new NotImplementedException();
        }

        private static void Exercise6()
        {
            throw new NotImplementedException();
        }

        private static void Exercise7()
        {
            throw new NotImplementedException();
        }

        private static void Exercise8()
        {
            throw new NotImplementedException();
        }
    }
}

