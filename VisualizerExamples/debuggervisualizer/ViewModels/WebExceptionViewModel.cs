using System;

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
                _response = new ResponseViewModel(ex.Response);
            }
        }

        public bool HasResponse => _response != null;

        public ResponseViewModel Response => _response;

        public string Message => _exception.Message;

        public string StackTrace => _exception.ToString();

        public string Status => _exception.Status.ToString();
       
    }
}