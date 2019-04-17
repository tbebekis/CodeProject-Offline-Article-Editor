using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CPArticleEditor
{
    [Serializable]
    public class Settings
    {
        /* private */ 
        const string SFileName = "Settings.json";
         

        /* construction */
        /// <summary>
        /// Constructor
        /// </summary>
        public Settings()
        {            
        }

        /* public */
        public void Load()
        {
            string FilePath = Path.Combine(App.BaseFolder, SFileName);

            if (File.Exists(FilePath))
            {
                string XmlText = File.ReadAllText(FilePath);
                App.FromJson(this, XmlText);
            }
            else
            {
                // Save();
            }
        }
        public void Save()
        {
            string FilePath = Path.Combine(App.BaseFolder, SFileName);
            string XmlText = App.ToJson(this);
            File.WriteAllText(FilePath, XmlText);
        }

        /* properties */
        public string Email { get; set; }
        public string Password { get; set; }
        public string ArticleFolder { get; set; } 
    }
}
