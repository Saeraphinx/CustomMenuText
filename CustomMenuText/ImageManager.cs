using CustomMenuText.CustomTypes;
using IPA.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomMenuText
{
    class ImageManager
    {
        public static void LoadImages()
        {
            PathToChunks(Plugin.IMG_PATH);
        }

        public static void PathToChunks(string path)
        {
            foreach(var pah in Directory.GetDirectories(path).ToList())
            {
                try
                {
                    LogoImages logoImage = new LogoImages(FileUtils.LoadPNG(pah), pah.Substring(pah.LastIndexOf('\\')));
                    Plugin.allImageEntries.Add(logoImage);
                }
                catch (NullReferenceException)
                {
                    Plugin.Log.Notice("[ImageManager] failed to load "+pah);
                    Plugin.allImageEntries.Add(new LogoImages(null, null));
                }
            }
        }
        
    }
}
