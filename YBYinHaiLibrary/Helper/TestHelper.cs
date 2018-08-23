using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace YBYinHaiLibrary
{
   internal static class TestHelper
    {
        static string DirName = "mock";

        public static string GetTestFile(string fileName)
        {
            string filePath = DirName + "\\" + fileName + ".xml";
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath,Encoding.Default);
            }
            return "";
        }
    }
}
