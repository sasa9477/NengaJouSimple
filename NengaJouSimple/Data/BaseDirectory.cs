using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NengaJouSimple.Data
{
    public static class BaseDirectory
    {
        public static string BaseDirectoryPath
        {
            get
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                return path;
            }
        }
    }
}
