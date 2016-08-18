﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace Loggly.Utility
{
    public static class Configuration
    {
        static Configuration()
        {
            _useSettings = null;
            _baseSettings = new Settings
            {
                ApiKey = GetConfigSetting("apiKey"),
                LogKey = GetConfigSetting("logKey"),
                Server = GetConfigSetting("server", "post.Loggly.net"),
                Version = GetConfigSetting("version", "1"),
                Tags = GetConfigSetting("tags"),
                Source = GetConfigSetting("source"),
                User = GetConfigSetting("user"),
                Secure = GetConfigSettingAsBool("secure"),
            };
        }

        static Settings _baseSettings;
        static Settings _useSettings;

        public static void UseSettings(Settings settings)
        {
            if (settings == null)
                throw new ArgumentNullException("settings");

            _useSettings = settings;
        }

        public static string ApiKey
        {
            get
            {
                if (_useSettings != null && !string.IsNullOrEmpty(_useSettings.ApiKey))
                    return _useSettings.ApiKey;
                return _baseSettings.ApiKey;
            }
        }

        public static string LogKey
        {
            get
            {
                if (_useSettings != null && !string.IsNullOrEmpty(_useSettings.LogKey))
                    return _useSettings.LogKey;
                return _baseSettings.LogKey;
            }
        }

        public static string Server
        {
            get
            {
                if (_useSettings != null && !string.IsNullOrEmpty(_useSettings.Server))
                    return _useSettings.Server;
                return _baseSettings.Server;
            }
        }

        public static string Version
        {
            get
            {
                if (_useSettings != null && !string.IsNullOrEmpty(_useSettings.Version))
                    return _useSettings.Version;
                return _baseSettings.Version;
            }
        }

        public static string Tags
        {
            get
            {
                if (_useSettings != null && !string.IsNullOrEmpty(_useSettings.Tags))
                    return _useSettings.Tags;
                return _baseSettings.Tags;
            }
        }

        public static string Source
        {
            get
            {
                if (_useSettings != null && !string.IsNullOrEmpty(_useSettings.Source))
                    return _useSettings.Source;
                return _baseSettings.Source;
            }
        }

        public static string User
        {
            get
            {
                if (_useSettings != null && !string.IsNullOrEmpty(_useSettings.User))
                    return _useSettings.User;
                return _baseSettings.User;
            }
        }

        public static bool Secure
        {
            get
            {
                if (_useSettings != null && _useSettings.Secure.HasValue)
                    return _useSettings.Secure.Value;
                return _baseSettings.Secure.Value;
            }
        }

        static string GetConfigSetting(string key, string defValue = "")
        {
            return defValue;
        }

        static bool GetConfigSettingAsBool(string key, bool defValue = false)
        {
            string val = GetConfigSetting(key, defValue.ToString());
            return (val.ToLower() == "true");
        }
    }
}
