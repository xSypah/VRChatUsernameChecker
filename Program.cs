using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using VRChat_NameChecker.Utils;

namespace VRChat_NameChecker
{
    internal class Program
    {
        private static List<string> userNames = File.ReadAllLines("usernames.txt").ToList();
        private static WebClient webClient = new WebClient();
        private static bool isAvailable(string username)
        {
            webClient.Headers.Set("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/101.0.4951.41 Safari/537.36");
            dynamic response = JsonConvert.DeserializeObject(webClient.DownloadString($"https://vrchat.com/api/1/auth/exists?apiKey=JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26&username={username}"));
            return response.userExists;
        }

        private static void Main(string[] args)
        {
            Console.Title = $"KΛRMΛ | VRChat Username Checker | Checking {userNames.Count} Usernames | By Sypherr#3000" ;
            Logger.Log("Thanks for using our software! discord.gg/karmavrc", Logger.Type.Info);
            foreach (var username in userNames)
            {
                bool userExists = isAvailable(username);
                if (userExists)
                {
                    Logger.Log($"{username} has already been taken!", Logger.Type.Error);
                    Logger.WriteToFile(username, "unavailable.txt");
                }
                else
                {
                    Logger.Log($"{username} is available!", Logger.Type.Success);
                    Logger.WriteToFile(username, "available.txt");
                }
                Task.Delay(500).Wait(); // 429
            }
            Logger.Log($"Successfully checked all {userNames.Count} usernames! :)");
            Task.Delay(-1).Wait();
        }
    }
}