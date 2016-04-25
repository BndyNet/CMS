using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common
{
    public static class FileHelper
    {
        public static string[] ImageExtensionNames = new string[] { ".jpg", ".png", ".gif", ".bmp" };
        public static bool IsImageFile(string fileName)
        {
            foreach (var ext in ImageExtensionNames)
            {
                if (fileName.ToLower().IndexOf(ext) > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
