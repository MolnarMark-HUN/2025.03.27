using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using System.Net.Http;

namespace _2025._03._27
{
    class serverconnection
    {
        HttpClient client = new HttpClient();
        string serverurl = "";
        public serverconnection(string serverurl)
        {
            this.serverurl = serverurl;
        }
        public async Task<bool> createkolbasz(string name,int price,double rating)
        {
            string url = serverurl + "/createkolbasz";
            try
            {
                var jsonInfo = new {

                    kolbaszName = name,
                    KolbaszRate = rating,
                    KolbaszPrice=price

                };
                string jsonStringified = JsonConvert.SerializeObject(jsonInfo);
                HttpContent sendThis = new StringContent(jsonStringified, Encoding.UTF8, "Application/json");
                HttpResponseMessage response = await client.PostAsync(url, sendThis);
                response.EnsureSuccessStatusCode();
                string result = await response.Content.ReadAsStringAsync();
                JsonData data = JsonConvert.DeserializeObject<JsonData>(result);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }
        public async Task<List<string>> listallkolbaszes()
        {
            List<string> all = new List<string>();
            string url = serverurl + "/kolbaszok";
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string result = await response.Content.ReadAsStringAsync();
                JsonData data = JsonConvert.DeserializeObject<JsonData>(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return all;
        }
        public async Task<bool> DeletePerson(string name)
        {
            string url = serverurl + "/deletekolbasz";
            var jsonInfo = new
            {
                kolbaszName = name
            };
            try
            {
                string jsonStringified = JsonConvert.SerializeObject(jsonInfo);
                HttpContent sendThis = new StringContent(jsonStringified, Encoding.UTF8, "Application/json");
                HttpResponseMessage response = await client.PostAsync(url, sendThis);
                response.EnsureSuccessStatusCode();
                string resault = await response.Content.ReadAsStringAsync();
                JsonData data = JsonConvert.DeserializeObject<JsonData>(resault);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }
    }
}
