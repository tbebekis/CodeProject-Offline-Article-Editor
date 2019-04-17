using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

using Newtonsoft.Json;

namespace CPArticleEditor
{
    static public class App
    {
        /* private */
        const int FEATURE_DISABLE_NAVIGATION_SOUNDS = 21;
        const int SET_FEATURE_ON_PROCESS = 0x00000002;

        [DllImport("urlmon.dll")]
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Error)]
        static extern int CoInternetSetFeatureEnabled(int FeatureEntry, [MarshalAs(UnmanagedType.U4)] int dwFlags, bool fEnable);

        /* construction */
        static App()
        {
            try
            {
                CoInternetSetFeatureEnabled(FEATURE_DISABLE_NAVIGATION_SOUNDS, SET_FEATURE_ON_PROCESS, true);
            }
            catch
            {
            }

            BaseFolder = Path.GetDirectoryName(typeof(App).Assembly.Location);
            EditorFilePath = Path.Combine(BaseFolder, "RequiredFiles\\Editor.htm");

            /* global JsonSerializerSettings */
            JsonSerializerSettings = new Newtonsoft.Json.JsonSerializerSettings();
            JsonSerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            JsonSerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            Settings.Load();
        }

        /// <summary>
        /// Loads an object's properties from a specified json text.
        /// <para>If no settings specified then it uses the default JsonSerializerSettings</para> 
        /// </summary>
        static public void FromJson(object Instance, string JsonText, JsonSerializerSettings Settings = null)
        {
            if (!string.IsNullOrWhiteSpace(JsonText))
            {
                Settings = Settings == null ? JsonSerializerSettings : Settings;
                JsonConvert.PopulateObject(JsonText, Instance, Settings);
            }
        }
        /// <summary>
        /// Converts Instance to a json string using the NewtonSoft json serializer.
        /// <para>If no settings specified then it uses the default JsonSerializerSettings</para> 
        /// </summary>
        static public string ToJson(object Instance, JsonSerializerSettings Settings = null)
        {
            Settings = Settings == null ? JsonSerializerSettings : Settings;
            return Instance == null ? string.Empty : JsonConvert.SerializeObject(Instance, Settings);
        }

        /* properties */
        static public Settings Settings { get; private set; } = new Settings();
        static public string BaseFolder { get; } 
        static public JsonSerializerSettings JsonSerializerSettings { get; }

        static public string LastArticleFolder { get { return !string.IsNullOrWhiteSpace(Settings.ArticleFolder) ? Settings.ArticleFolder : BaseFolder; } }
        static public string EditorFilePath { get; }
    }
}
