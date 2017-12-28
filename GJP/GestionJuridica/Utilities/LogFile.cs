using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace GestionJuridica.Utilities
{
    public static class LogFile
    {
        public static void Save(string controller, string method, string message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Log\\" as string;
            string pathFile = path + controller + "_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

            if (!File.Exists(pathFile))
            {
                File.Create(pathFile);
            }

            using (StreamWriter wt = new StreamWriter(pathFile, true))
            {
                wt.WriteLine(method.ToUpper() + "  -  " + DateTime.Now.ToString());
                wt.WriteLine(message);
                wt.WriteLine("====================================================");
            }
        }
    }
}