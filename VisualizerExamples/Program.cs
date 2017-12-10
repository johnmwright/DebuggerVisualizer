using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;

namespace VisualizerExamples
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                using (var client = new WebClient())
                {
                    var jsonUrl = "https://jsonplaceholder.typicode.com/posts";
                    var error404Url = "http://wrightfully.com/notreal";
                    var result = client.DownloadString(jsonUrl);
                    Debugger.Break();
                }
                throw new Exception("Test");
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.ToString());
                
                var stream = ex.Response.GetResponseStream();
                if (stream != null)
                {
                    using (var readStream = new StreamReader(stream, Encoding.UTF8))
                    {
                        var _rawResponse = readStream.ReadToEnd();                      
                        Debugger.Break();
                    }
                }
            
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());                
            }
            
        }
    }
}
