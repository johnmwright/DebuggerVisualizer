using System.IO;
using Microsoft.VisualStudio.DebuggerVisualizers;
using VisualizerExamples.DebuggerVisualizer.ViewModels;

namespace VisualizerExamples.DebuggerVisualizer.WebResponse.WPF
{
    public class WebResponseVisualObjectSource : VisualizerObjectSource
    {
        public override void GetData(object target, Stream outgoingData)
        {
            var originalObj = target as System.Net.WebResponse;
            var viewModel = new ResponseViewModel(originalObj);
       
            base.GetData(viewModel, outgoingData);
        }
    }
}