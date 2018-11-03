using System;
using System.Net;
using StackExchange.Exceptional;

namespace VisualizerExamples.DebuggerVisualizer.ViewModels
{
    [Serializable]
    public class WebExceptionViewModel: ExceptionViewModel<System.Net.WebException>
    {
        private readonly ResponseViewModel _response;

        
        public WebExceptionViewModel(System.Net.WebException ex): base(ex)
        {            
            if (ex.Response != null)
            {
                if (ex.Response is HttpWebResponse response)
                {
                    _response = new ResponseViewModel(response);
                }
                else
                {
                    _response = new ResponseViewModel(ex.Response);
                }
            }
        }

        public bool HasResponse => _response != null;

        public ResponseViewModel Response => _response;
        
        public string Status => Exception.Status.ToString();


    }
}