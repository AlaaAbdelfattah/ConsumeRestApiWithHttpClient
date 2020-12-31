using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MulesoftConsoleApp
{
    class Program
    {
        #region Main

        /// <summary>
        /// Main 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                #region QueryDependentsById

                if (bool.Parse(ConfigurationManager.AppSettings["Test_QueryDependentsById"]))
                {
                    QueryDependentsByIdAsync().Wait();
                }

                #endregion

                #region  GetCurrentDomesticSponsereeInfo

                if (bool.Parse(ConfigurationManager.AppSettings["Test_GetCurrentDomesticSponsereeInfo"]))
                {
                    GetCurrentDomesticSponsereeInfoAsync().Wait();
                }

                #endregion

                #region GetPersonInfo

                if (bool.Parse(ConfigurationManager.AppSettings["Test_GetPersonInfo"]))
                {
                    GetPersonInfoAsync().Wait();
                }

                #endregion

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        #region Helpers

        static async Task QueryDependentsByIdAsync()
        {
            //StopWatch
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            using (var client = new HttpClient())
            {
                //Clean log file 
                File.WriteAllText("D:\\Projects\\Alaa\\git\\stcpay\\MusandSolution\\TestPath\\NICMulesoftConsoleApp\\Logs.txt", "");
                //Response List
                var DependentsDataList = new List<QueryDependentsByIdResponse.QueryDependentsByIdResponse>();
                //Read From Config File
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["Stcpay-Base-Url"]);
                client.DefaultRequestHeaders.Add("client_id", ConfigurationManager.AppSettings["client_id"]);
                client.DefaultRequestHeaders.Add("client_secret", ConfigurationManager.AppSettings["client_secret"]);
                //Preparing the request
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Console.WriteLine("Get");
                //Send the Request
                //Q1: we have Limitiation for IdNo?
                //Q2: what about the Null objects returned from stc-pay app?
                var response = await client.GetAsync(string.Format(ConfigurationManager.AppSettings["Stcpay-Base-Url"] + "dependents?idNo={0}", ConfigurationManager.AppSettings["IdNo"]));
                //Check the response
                if (response.IsSuccessStatusCode)
                {
                    //Casting the response 
                    var result = await response.Content.ReadAsStreamAsync();
                    var reader = new StreamReader(result);
                    string responseFromServer = reader.ReadToEnd();
                    //Check Content Response.
                    if (string.IsNullOrWhiteSpace(responseFromServer) || responseFromServer == "[]")
                        Console.WriteLine("Empty");
                    //Conver Stream Response To Jobject
                    var jObject = JObject.Parse(responseFromServer);
                    //read first element
                    if (jObject != null && jObject.First != null)
                    {
                        var counts = ((JContainer)jObject.First).First.Count();
                        if (counts > 0)
                        {
                            for (int i = 0; i < counts; i++)
                            {
                                if (((JContainer)jObject.First).First[i] != null)
                                {
                                    var obj2 = ((JContainer)jObject.First).First[i].First;
                                    if (obj2 != null)
                                    {
                                        if (obj2.First != null && obj2.First.Count() > 0)
                                        {
                                            var queryDependentsByIdResponse = obj2.First.ToObject<QueryDependentsByIdResponse.QueryDependentsByIdResponse>();
                                            if (queryDependentsByIdResponse != null)
                                            {
                                                DependentsDataList.Add(queryDependentsByIdResponse);
                                                var logVar = "FullName: " + queryDependentsByIdResponse.Name.FullName + "\n IdNo: " + queryDependentsByIdResponse.Residency.IdNo
                                                    + "\n Nationality: " + queryDependentsByIdResponse.Nationality.Name + "\n Occupation: " + queryDependentsByIdResponse.Occupation.Name;
                                                File.AppendAllText("D:\\Projects\\Alaa\\git\\stcpay\\MusandSolution\\TestPath\\NICMulesoftConsoleApp\\Logs.txt", logVar + Environment.NewLine + Environment.NewLine);
                                                Console.WriteLine(DependentsDataList.Last().Residency.IdNo + " Index:  " + (i + 1));
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            File.AppendAllText("D:\\Projects\\Alaa\\git\\stcpay\\MusandSolution\\TestPath\\NICMulesoftConsoleApp\\Logs.txt", "Round-Trip time:  " + stopWatch.ElapsedMilliseconds + Environment.NewLine + Environment.NewLine);
            Console.WriteLine();
        }

        static async Task GetCurrentDomesticSponsereeInfoAsync()
        {
            try
            {
                //StopWatch
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                using (var client = new HttpClient())
                {
                    //Clean log file 
                    File.WriteAllText("D:\\Projects\\Alaa\\git\\stcpay\\MusandSolution\\TestPath\\NICMulesoftConsoleApp\\Logs.txt", "");
                    //Response List
                    var nicResponse = new List<GetCurrentDomesticSponsereeInfoResponse.Root>();
                    //Read From Config File
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["Stcpay-Base-Url"]);
                    client.DefaultRequestHeaders.Add("client_id", ConfigurationManager.AppSettings["client_id"]);
                    client.DefaultRequestHeaders.Add("client_secret", ConfigurationManager.AppSettings["client_secret"]);
                    //Preparing the request
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //Send the Request
                    var response = await client.GetAsync(string.Format(ConfigurationManager.AppSettings["Stcpay-Base-Url"] + "sponsorees/{0}/date/{1}",
                        ConfigurationManager.AppSettings["GetCurrentDomesticSponseree_SponserId"], ConfigurationManager.AppSettings["GetCurrentDomesticSponseree_SponserDate"]));
                    //Check the response 
                    if (response.IsSuccessStatusCode)
                    {
                        //Casting the response 
                        var result = await response.Content.ReadAsStreamAsync();
                        var reader = new StreamReader(result);
                        string responseFromServer = reader.ReadToEnd();
                        //Check Content Response.
                        if (string.IsNullOrWhiteSpace(responseFromServer) || responseFromServer == "[]")
                            Console.WriteLine("Empty");
                        //Conver Stream Response To Jobject
                        var jObject = JObject.Parse(responseFromServer);
                        //read first element
                        if (jObject != null && jObject.First != null)
                        {
                            if (jObject.First != null)
                            {
                                Console.WriteLine("The Response Arrived Successfully");
                            }
                        }
                    }
                }
                File.AppendAllText("D:\\Projects\\Alaa\\git\\stcpay\\MusandSolution\\TestPath\\NICMulesoftConsoleApp\\Logs.txt", "Round-Trip time:  " + stopWatch.ElapsedMilliseconds + Environment.NewLine + Environment.NewLine);
                Console.WriteLine("Round-Trip time:  " + stopWatch.ElapsedMilliseconds);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        static async Task GetPersonInfoAsync()
        {
            try
            {
                //StopWatch
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                using (var client = new HttpClient())
                {
                    //Clean log file 
                    File.WriteAllText("D:\\Projects\\Alaa\\git\\stcpay\\MusandSolution\\TestPath\\NICMulesoftConsoleApp\\Logs.txt", "");

                    //Read From Config File
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["Stcpay-Base-Url"]);
                    client.DefaultRequestHeaders.Add("client_id", ConfigurationManager.AppSettings["client_id"]);
                    client.DefaultRequestHeaders.Add("client_secret", ConfigurationManager.AppSettings["client_secret"]);
                    //Preparing the request
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //Send the Request
                    var response = await client.GetAsync(string.Format(ConfigurationManager.AppSettings["Stcpay-Base-Url"] + "users/{0}/date/{1}",
                        ConfigurationManager.AppSettings["GetPersonInfo_SponserId"], ConfigurationManager.AppSettings["GetPersonInfo_SponserDate"]));
                    //Check the response 
                    if (response.IsSuccessStatusCode)
                    {
                        //Casting the response 
                        var result = await response.Content.ReadAsStreamAsync();
                        var reader = new StreamReader(result);
                        string responseFromServer = reader.ReadToEnd();
                        //Check Content Response.
                        if (string.IsNullOrWhiteSpace(responseFromServer) || responseFromServer == "[]")
                            Console.WriteLine("Empty");
                        //Conver Stream Response To Jobject
                        var jObject = JObject.Parse(responseFromServer);
                        //read first element
                        if (jObject != null && jObject.First != null)
                        {
                            if (jObject.First != null)
                            {
                                Console.WriteLine("The Response Arrived Successfully");
                            }
                        }
                    }
                }
                File.AppendAllText("D:\\Projects\\Alaa\\git\\stcpay\\MusandSolution\\TestPath\\NICMulesoftConsoleApp\\Logs.txt", "Round-Trip time:  " + stopWatch.ElapsedMilliseconds + Environment.NewLine + Environment.NewLine);
                Console.WriteLine("Round-Trip time:  " + stopWatch.ElapsedMilliseconds);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        #endregion

    }
}
