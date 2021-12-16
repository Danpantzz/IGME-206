using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web;
using System.Net;
using System.IO;

namespace Final_Exam___Question_4
{
    //Class: Program
    //Author: Daniel McErlean
    //Purpose: Read and Write settings to a JSON file
    //Restrictions: None
    class Program
    {
        public interface IPlayerSettings
        {
            void SavePlayerSettings(string fileName, PlayerSettings settings);
            PlayerSettings LoadPlayerSettings(string fileName);
        }

        public class PlayerSettings
        {
            public string player_name;
            public int level;
            public int hp;
            public string[] inventory;
            public string license_key;
        }

        // eager loading singleton
        public class SettingsClass : IPlayerSettings
        {
            private static SettingsClass instance = new SettingsClass();

            private SettingsClass()
            {

            }

            public static SettingsClass GetInstance()
            {
                return instance;
            }

            //Method: SavePlayerSettings
            //Purpose: Write the player settings to the file location
            //Restrictions: None
            public void SavePlayerSettings(string fileName, PlayerSettings settings)
            {
                string sSettings;

                sSettings = JsonConvert.SerializeObject(settings);

                // write sSettings to fileName
                StreamWriter writer = new StreamWriter(fileName);
                writer.Write(sSettings);
                writer.Close();
            }

            //Method: LoadPlayerSettings
            //Purpose: Read the player settings from the file location
            //Restrictions: None
            public PlayerSettings LoadPlayerSettings(string fileName)
            {
                string sSettings = null;

                // read fileName to sSettings
                PlayerSettings settings;

                StreamReader reader = new StreamReader(fileName);
                sSettings = reader.ReadToEnd();
                reader.Close();

                settings = JsonConvert.DeserializeObject<PlayerSettings>(sSettings);

                return settings;
            }
        }

        //Method: Q4
        //Purpose: Send file location and retrieved player settings to the corresponding read and write methods
        //Restrictions: None
        static void Q4()
        {
            PlayerSettings settings = new PlayerSettings();

            SettingsClass settingsFunctions = SettingsClass.GetInstance();

            settings = settingsFunctions.LoadPlayerSettings("c:/settings.json");
            settingsFunctions.SavePlayerSettings("c:/settings.json", settings);

        }

        //Method: Main
        //Purpose: Invoke Q4() method
        //Restrictions: None
        static void Main(string[] args)
        {
            Q4();
        }
    }
}