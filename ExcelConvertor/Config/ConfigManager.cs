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
                // Setting Save Failed
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Load Setting Data from Config File
        /// </summary>
        /// <returns></returns>
        public static bool Load()
        {
            if (!File.Exists(CONFIG_FILE_NAME))
            {
                // File Not Exists.
                SetDefault();
                return Save();
            }

            try
            {
                string loadJson = File.ReadAllText(CONFIG_FILE_NAME);
                Setting = JsonConvert.DeserializeObject<ConfigData>(loadJson);
            }
            catch (Exception ex)
            {
                // Setting Load Failed
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Set Default Setting
        /// </summary>
        public static void SetDefault()
        {
            Setting.SetDefault();
        }




    }
}
