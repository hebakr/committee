using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Configuration;
using Committes.Models;
using System.Web.Hosting;
using Newtonsoft.Json;

namespace Committes.Web.Helpers
{
    public static class Util
    {

        static Regex _htmlRegex = new Regex("<.*?>", RegexOptions.Compiled);

        public static ApplicationSettings AppSettings {

            get
            {
                var filePath = ConfigurationManager.AppSettings["AppSettingsFile"];

                var strSettings = Util.GetFileContent(HostingEnvironment.MapPath(filePath));

                var settings = (string.IsNullOrWhiteSpace(strSettings)) ? new ApplicationSettings() : JsonConvert.DeserializeObject<ApplicationSettings>(strSettings);

                return settings;
            }
        }

        internal static string BuildEmailFromTemplate(string filename, Dictionary<string, string> parameters)
        {
            StreamReader reader = File.OpenText(filename);
            string line = "";
            System.Text.StringBuilder mailText = new System.Text.StringBuilder(); ;
            while ((line = reader.ReadLine()) != null)
                mailText.Append(line);

            reader.Close();

            foreach (var item in parameters)
            {
                mailText.Replace(item.Key, item.Value);
                
            }

            return mailText.ToString();
        }
       
        public static string GetContentType(string path)
        {
            string ext = System.IO.Path.GetExtension(path).ToLower().Remove(0, 1);

            string contentType = "application/octet-stream";
            
            switch (ext)
            {
                case "asf":
                    contentType = "video/x-ms-asf";
                    break;
                case "avi":
                    contentType = "video/avi";
                    break;
                case "doc":
                    contentType = "application/msword";
                    break;
                case "zip":
                    contentType = "application/zip";
                    break;
                case "xls":
                    contentType = "application/vnd.ms-excel";
                    break;
                case "gif":
                    contentType = "image/gif";
                    break;
                case "jpg":
                case "jpeg":
                    contentType = "image/jpeg";
                    break;
                case "png":
                    contentType = "image/png";
                    break;
                case "wav":
                    contentType = "audio/wav";
                    break;
                case "mp3":
                    contentType = "audio/mpeg3";
                    break;
                case "mpg":
                case "mpeg":
                    contentType = "video/mpeg";
                    break;
                case "rtf":
                    contentType = "application/rtf";
                    break;
                case "dwg":
                    contentType = "application/acad";
                    break;
                case "pdf":
                    contentType = "application/pdf";
                    break;

            }

            return contentType;
        }

        public static void DeleteDirectory(string target_dir)
        {
            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }

            Directory.Delete(target_dir, false);
        }

        public static MvcHtmlString NewLineToHtmlBreak(string text)
        {
            return MvcHtmlString.Create(text.Replace("\r\n", "<br />"));
        }

        internal static string GetFileContent(string file)
        {
            StreamReader reader = File.OpenText(file);
            string line = "";
            StringBuilder mailText = new System.Text.StringBuilder(); ;
            while ((line = reader.ReadLine()) != null)
                mailText.Append(line + Environment.NewLine);

            reader.Close();


            return mailText.ToString();
        }

        public static string SubString(string text, int numberOfWords) 
        {
            var ss = text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Take(numberOfWords);

            //if (ss.Count() <= numberOfWords) return text;

            return string.Join(" ", ss.ToArray());
        }

        public static DateTime GetLocalDate(DateTime date)
        {
            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("Arabic Standard Time");
            // May 7, 08:04:00
            DateTime utcDateTime = date.ToUniversalTime().Add(tzi.BaseUtcOffset);

            return utcDateTime;
        }

        public static string FormatFileSize(long filesize)
        { 
            const Decimal OneKiloByte = 1024M;
            const Decimal OneMegaByte = OneKiloByte * 1024M;
            const Decimal OneGigaByte = OneMegaByte * 1024M;

            decimal size = (decimal)filesize;

            string suffix = "";
            string precision = "2";

            if (size > OneGigaByte) {
                size /= OneGigaByte;
                suffix = "GB";
            } else if (size > OneMegaByte) {
                size /= OneMegaByte;
                suffix = "MB";
            } else if (size > OneKiloByte) {
                size /= OneKiloByte;
                suffix = "KB";
                precision = "0";
            } else {
                suffix = "B";
                precision = "0";
            }

            return String.Format("{0:N" + precision + "} {1}", size, suffix);
        }

        internal static void SaveContentToFile(string strSettings, string filePath)
        {
            using (StreamWriter file = new StreamWriter(filePath, false))
            {
                file.Write(strSettings);
            }
        }
    }
}