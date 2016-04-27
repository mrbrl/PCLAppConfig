using System;
using System.Collections.Generic;
using System.Text;
using Foundation;

namespace PCLAppConfig.App.iOS.Infrastructure
{
    public class iOSSettingsManagerpublic
    {
        public static string ApiPath { get; private set; }

        const string API_PATH_KEY = "serverAddress"; //this needs to be the Identifier of the field in the Root.plist

        public static void SetUpByPreferences()
        {
            var testVal = NSUserDefaults.StandardUserDefaults.StringForKey(API_PATH_KEY);

            if (testVal == null)
                LoadDefaultValues();
            else
                LoadEditedValues();

            SavePreferences();
        }

        static void LoadDefaultValues()
        {
            var settingsDict = new NSDictionary(NSBundle.MainBundle.PathForResource("Settings.bundle/Root.plist", null));

            if (settingsDict != null)
            {
                var prefSpecifierArray = settingsDict[(NSString) "PreferenceSpecifiers"] as NSArray;

                if (prefSpecifierArray != null)
                {
                    foreach (var prefItem in NSArray.FromArray<NSDictionary>(prefSpecifierArray))
                    {
                        var key = prefItem[(NSString) "Key"] as NSString;

                        if (key == null)
                            continue;

                        var value = prefItem[(NSString) "DefaultValue"];

                        if (value == null)
                            continue;

                        switch (key.ToString())
                        {
                            case API_PATH_KEY:
                                ApiPath = value.ToString();
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        static void LoadEditedValues()
        {
            ApiPath = NSUserDefaults.StandardUserDefaults.StringForKey(API_PATH_KEY);
        }

        //Save new preferences to Settings
        static void SavePreferences()
        {
            var appDefaults = NSDictionary.FromObjectsAndKeys(new object[]
            {
                new NSString(ApiPath)
            }, new object[]
            {
                API_PATH_KEY
            });

            NSUserDefaults.StandardUserDefaults.RegisterDefaults(appDefaults);
            NSUserDefaults.StandardUserDefaults.Synchronize();
        }
    }
}
