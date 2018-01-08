using System;
using System.Net;
using StackExchange.Exceptional;

namespace VisualizerExamples.DebuggerVisualizer.ViewModels
{
    [Serializable]
    public class WebExceptionViewModel
    {
        private readonly ResponseViewModel _response;


        /// <summary>
        /// The original Exception
        /// </summary>
        private readonly System.Net.WebException _exception;

        public WebExceptionViewModel(System.Net.WebException ex)
        {
            _exception = ex;
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

        public string Message => _exception.Message;

        public string StackTrace => _exception.ToString();

        public string Status => _exception.Status.ToString();

        public string StackTraceFormatted
        {
            get
            {
                var html = "<html><body> <div class=\"error-info\"><pre class=\"stack\"><code>" +
                           ExceptionalUtils.StackTrace.HtmlPrettify(StackTrace, new StackTraceSettings())
                           +"</code></pre></div></body></html>";
                return html;
            }
        }

    }
}