using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace _2025._03._27
{
    class Program
    {
        static int price;
        static string name;
        static double rating;
        static serverconnection connection;
        static void Main(string[] args)
        {
            connection = connection;
            start();
        }
        async static void start()
        {
            
            Console.WriteLine("Mit szeretnél csinálni?  (v) vásárolni or (n) nézelődni or (d) törölni" );
            string purpose = Console.ReadLine();

            if (purpose=="v")
            {
                Console.WriteLine("Írd le a kolbászod adatait.   vel elválasztva");
                string[] kolbaszthings= Console.ReadLine().Split(' ');
                name = kolbaszthings[0];
                price =Convert.ToInt32(kolbaszthings[1]);
                rating =Convert.ToDouble(kolbaszthings[2]);

                bool resault = await connection.createkolbasz(name,price,rating);



            }
            if (purpose == "n")
            {
                Console.WriteLine("Itt vannak a kolbászok");





            }
            Console.ReadKey();
        } 
    }
}
