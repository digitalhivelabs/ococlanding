using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using API.Interfaces;

namespace API.Helpers
{
    public class LogApi: ILogApi
    {
        public void Record(string error, string path, string method, string inputs)
        {
            string filename = String.Format("{0}_{1:yyyyMMdd}.txt", "Log", DateTime.Now);
            string hour =  String.Format("{0:yyyyMMdd_HHmmss}", DateTime.Now);
            string msg = string.Empty;
            
            string root_path =  Path.Combine(Environment.CurrentDirectory, @"Log\");            
            filename = string.Format("{0}{1}", root_path, filename);

            if (!File.Exists(filename))
                File.WriteAllText(filename, "- - Log ERROR - -" + Environment.NewLine);//will overwrite the text in the existing file. If the file doesn't exist, it will create it.

            msg = string.Format("{0} - {1} {2}{3}", hour, "Error on:", method, Environment.NewLine);
            File.AppendAllText(filename, msg);//add text to existing file

            msg = string.Format("{0} - {1} {2}{3}", hour, "Inputs:", inputs, Environment.NewLine);
            File.AppendAllText(filename, msg);//add text to existing file

            msg = string.Format("{0} - {1} {2}{3}", hour, "Message error:", error, Environment.NewLine);
            File.AppendAllText(filename, msg);//add text to existing file

            msg = string.Format("{0} - {1} {2}{3}", hour, "Path:", path, Environment.NewLine);
            File.AppendAllText(filename, msg);//add text to existing file

            File.AppendAllText(filename, "----------------------------------" + Environment.NewLine);//add text to existing file
        }
    }
}