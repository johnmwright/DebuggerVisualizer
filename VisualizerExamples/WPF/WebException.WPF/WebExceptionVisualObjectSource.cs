using System.IO;
using Microsoft.VisualStudio.DebuggerVisualizers;
using VisualizerExamples.DebuggerVisualizer.ViewModels;

namespace VisualizerExamples.DebuggerVisualizer.WebException.WPF
{
    public class WebExceptionVisualObjectSource : VisualizerObjectSource
    {
        public override void GetData(object target, Stream outgoingData)
        {
            var originalObj = target as System.Net.WebException;
            var viewModel = new WebExceptionViewModel(originalObj);
       
            base.GetData(viewModel, outgoingData);
        }
    }
}