using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransGr8_DD_Test.Services
{
    internal class UserService
    {
        public static List<User> GetUsers()
        {
            try
            {
                Log.Information(Directory.GetCurrentDirectory());
                StreamReader r = new StreamReader(@"Data\\users.json");
                string json = r.ReadToEnd();
                List<User> users = JsonConvert.DeserializeObject<List<User>>(json);
                return users;
            }
            catch (DirectoryNotFoundException dfe)
            {
                Log.Error(dfe.Message);
            }
            return null;
        }
    }
}
