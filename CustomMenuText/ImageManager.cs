﻿using IPA.Utilities;
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
        public static List<String> ChunkPaths = new List<String>();
        public static List<CustomTypes.LogoImages> ImageChunks = new List<CustomTypes.LogoImages>();

        public static void ImgInit()
        {
            FindOGLogo();
            PathToChunks(Plugin.IMG_PATH);
        }

        public static void FindOGLogo()
        {
            CustomTypes.LogoImages li = new CustomTypes.LogoImages
            {
                BatLogo = Tools.GetTexture(CustomTypes.logo.bat),
                E = Tools.GetTexture(CustomTypes.logo.a),
                SaberLogo = Tools.GetTexture(CustomTypes.logo.saber),
                name = "Default"
            };
            ImageChunks.Add(li);
        }

        public static void PathToChunks(string path)
        {
            foreach(var pah in FileUtils.GetFileChunks(path))
            {
                try
                {
                    ImageChunks.Add(FileUtils.LoadImagesFromChunk(pah));
                }
                catch (NullReferenceException)
                {
                    Plugin.Log.Notice("[ImageManager] No Image Chunks To Load!");
                    ImageChunks.Add(new CustomTypes.LogoImages(null, null, null, null));
                }
            }
        }
        
    }
}
