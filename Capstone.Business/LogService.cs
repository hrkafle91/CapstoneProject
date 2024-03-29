﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Business
{
    public static class LogService
    {
        static string file = System.Web.HttpContext.Current.Server.MapPath("~/Content/log.txt");

        public static void Write(string text)
        {
            try
            {
                string sentence = System.IO.File.ReadAllText(file);
                sentence += "\n[ " + DateTime.Now + " ] " + text;
                System.IO.File.WriteAllText(file, sentence);
            }
            catch
            {

            }
        }

        public static void NextLine()
        {
            try
            {
                string sentence = System.IO.File.ReadAllText(file);
                sentence += "";
                System.IO.File.WriteAllText(file, sentence);
            }
            catch
            {

            }
        }

        public static void Clear()
        {
            try
            {
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