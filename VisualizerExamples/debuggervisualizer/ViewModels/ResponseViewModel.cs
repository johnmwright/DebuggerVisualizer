using System;
using System.IO;
using System.Text;

namespace VisualizerExamples.DebuggerVisualizer.ViewModels
{
    [Serializable]
    public class ResponseViewModel
    {
        
        public ResponseViewModel(System.Net.WebResponse response)
        {
            
            ContentLength = response.ContentLength;
            ContentType = response.ContentType;
            ResponseUri = response.ResponseUri.ToString();

            var stream = response.GetResponseStream();
            if (stream != null)
            {
                // save position before reading
                long position = stream.Position;
                stream.Seek(0, SeekOrigin.Begin);

                using (var readStream = new StreamReader(stream: stream, 
                                                         encoding: Encoding.UTF8, 
                                                         detectEncodingFromByteOrderMarks: true, 
                                                         bufferSize: 1024, 
                                                         leaveOpen: true))
                {
                    RawResponse = readStream.ReadToEnd();                    
                }

                // reset seek position so we don't have side effects on the app
                stream.Seek(position, SeekOrigin.Begin);
            }
            
        }


        public long ContentLength { get; } 
        public string ContentType { get; } 
        public string ResponseUri { get; } 
        public string RawResponse { get; }
        

    }
}