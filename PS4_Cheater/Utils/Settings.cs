﻿using System.Configuration;
using System.Windows.Forms;

namespace PS4_Cheater {
    public class Config {
        public static string fileName = System.IO.Path.GetFileName(Application.ExecutablePath);
        public static bool addSetting(string key, string value) {
            try {
                Configuration config = ConfigurationManager.OpenExeConfiguration(fileName);
                config.AppSettings.Settings.Add(key, value);
                config.Save();
                return true;
            }
            catch {

            }
            return false;
        }

        public static string getSetting(string key) {
            try {
                Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(fileName);
                string value = config.AppSettings.Settings[key].Value;
                return value;
            }
            catch {

            }
            return "";
        }
        public static bool updateSetting(string key, string newValue) {
            try {
                Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(fileName);
                string value = config.AppSettings.Settings[key].Value = newValue;
                config.Save();
                return true;
            }
            catch {
                addSetting(key, newValue);
            }
            return false;
        }
    }

}
