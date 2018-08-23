using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiBaoHelper
{
    public class JsonConfig
    {
        public static string ConfigFileName = "yibaoconfig.json";

        public static string Path = string.Empty;

        public static Config config = new Config();

        static JsonConfig()
        {
            Path = Environment.GetFolderPath(Environment.SpecialFolder.Personal, Environment.SpecialFolderOption.DoNotVerify);
            ReadConfig();
        }

        public static string GetConfigFilePath()
        {
            return Path + "\\" + ConfigFileName;
        }


        public static bool AddConfigAndSave(string name, string value)
        {
            config.AddConfig(name, value);
            return SaveConfig();

        }

        public static bool SaveConfig()
        {
            return SaveConfig(config);
        }

        public static bool SaveConfig(Config config)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(config);
                string filePath = GetConfigFilePath();
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                File.WriteAllText(filePath, json);
                return true;
            }
            catch (Exception)
            {

            }

            return false;

        }

        public static string ReadConfigByName(string name)
        {
            return config.GetConfigKeyByName(name).value ?? "";
        }

        public static Config ReadConfig()
        {
            try
            {
                string filePath = GetConfigFilePath();

                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    config = (Config)Newtonsoft.Json.JsonConvert.DeserializeObject(json, typeof(Config));
                    return config;
                }
                return null;
            }
            catch (Exception)
            {

            }

            return null;

        }


    }

    public class Config
    {
        public bool AddConfig(string name, string vlaue)
        {
            try
            {
                GetConfigKeyByName(name).value = vlaue;
                return true;
            }
            catch (Exception)
            {


            }
            return false;
        }



        public ConfigKey GetConfigKeyByName(string name)
        {
            for (int i = 0; i < configKeys.Count; i++)
            {
                if (string.Equals(configKeys[i].name, name, StringComparison.CurrentCultureIgnoreCase))
                {
                    return configKeys[i];
                }
            }
            ConfigKey config = new ConfigKey();
            config.name = name;
            configKeys.Add(config);
            return config;

        }

        public List<ConfigKey> configKeys = new List<ConfigKey>();
    }

    public class ConfigKey
    {

        public string name;
        public string value;


    }
}
