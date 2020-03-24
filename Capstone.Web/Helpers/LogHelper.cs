using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Helpers
{
    public class LogHelper
    {
        public static void WriteLog(string text)
        {
            try
            {
                string file = System.Web.HttpContext.Current.Server.MapPath("~/Content/data/log.txt");
                string sentence = System.IO.File.ReadAllText(file);
                sentence += "\n[ " + DateTime.Now + " ] " + text;
                System.IO.File.WriteAllText(file, sentence);
            }
            catch
            {

            }
        }

        public static void ClearLog()
        {
            try
            {
                string file = System.Web.HttpContext.Current.Server.MapPath("~/Content/data/log.txt");
                string sentence = System.IO.File.ReadAllText(file);
                sentence = "";
                System.IO.File.WriteAllText(file, sentence);
            }
            catch
            {

            }
        }
    }
}