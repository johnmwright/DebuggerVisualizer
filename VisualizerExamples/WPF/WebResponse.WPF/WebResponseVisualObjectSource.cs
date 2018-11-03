using System.IO;
using Microsoft.VisualStudio.DebuggerVisualizers;
using VisualizerExamples.DebuggerVisualizer.ViewModels;

namespace VisualizerExamples.DebuggerVisualizer.WebResponse.WPF
{
    public class WebResponseVisualObjectSource : VisualizerObjectSource
    {
        public override void GetData(object target, Stream outgoingData)
        {
            ResponseViewModel viewModel;

            if (target is System.Net.HttpWebResponse) 
            {
                 viewModel = new ResponseViewModel((System.Net.HttpWebResponse)target);
            }
            else
            {
                var originalObj = target as System.Net.WebResponse;
                viewModel = new ResponseViewModel(originalObj);
            }

            base.GetData(viewModel, outgoingData);
        }
    }
}