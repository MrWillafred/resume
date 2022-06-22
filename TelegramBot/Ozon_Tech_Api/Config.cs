using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozon_Tech_Api
{
    public class Config
    {
        public string Token;
        public string Host;
        public string Port;
        public string Database;
        public string Username;
        public string Password;

        public Config()
        {
            string path = @"./config.json";

            if (!File.Exists(path))
            {
                Console.WriteLine("Configuration file not found");
                Console.ReadLine();


                 throw new Exception("Configuration file not found");
            }

            string jsonConfig = File.ReadAllText(path);

            InitialConfig config = JsonConvert.DeserializeObject<InitialConfig>(jsonConfig);

            Token = config.Token;
            Host = config.Host;
            Port = config.Port;
            Database = config.Database;
            Username = config.Username;
            Password = config.Password;
        }
    }

    class InitialConfig 
    {
        public string Token;
        public string Host;
        public string Port;
        public string Database;
        public string Username;
        public string Password;
        public InitialConfig(string Token, string Host, string Port, string Database, string Username, string Password)
        {
            this.Token = Token;
            this.Host = Host;
            this.Port = Port;
            this.Database = Database;
            this.Username = Username;
            this.Password = Password;
        }
    }
}
