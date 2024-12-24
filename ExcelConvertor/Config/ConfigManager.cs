using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;


namespace Bass.Tools.Config
{
    public static class ConfigManager
    {
        private const string CONFIG_FILE_NAME = "config.json";

        public static ConfigData Setting = new ConfigData();




        /// <summary>
        /// Save Setting Data to Config File
        /// </summary>
        /// <returns></returns>
        public static bool Save()
        {
            string saveJson = JsonConvert.SerializeObject(Setting);

            try
            {
                File.WriteAllText(CONFIG_FILE_NAME, saveJson);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }
        public static bool Load()
        {
            if(!File.Exists(CONFIG_FILE_NAME))
                return false;

            string loadJson = string.Empty;

            Setting = JsonConvert.DeserializeObject<ConfigData>(loadJson);


            return true;
        }

        public static void SetDefault()
        {
            Setting.SetDefault();
        }




    }
}
