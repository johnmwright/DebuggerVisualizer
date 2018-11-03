using System;
using System.Net;
using StackExchange.Exceptional;

namespace VisualizerExamples.DebuggerVisualizer.ViewModels
{
    [Serializable]
    public class ExceptionViewModel : ExceptionViewModel<System.Exception>
    {
        public ExceptionViewModel(System.Exception ex):base(ex) { }
    }

    [Serializable]
    public class ExceptionViewModel<T> where T: System.Exception
    {
        
        /// <summary>
        /// The original Exception
        /// </summary>
        protected readonly T Exception;

        public ExceptionViewModel(T ex)
        {
            Exception = ex;
        }
        public string Message => Exception.Message;

        public string StackTrace => Exception.ToString();

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