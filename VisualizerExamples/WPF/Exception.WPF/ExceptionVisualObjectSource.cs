using System.IO;
using Microsoft.VisualStudio.DebuggerVisualizers;
using VisualizerExamples.DebuggerVisualizer.ViewModels;

namespace VisualizerExamples.DebuggerVisualizer.Exception.WPF
{
    public class ExceptionVisualObjectSource : VisualizerObjectSource
    {
        public override void GetData(object target, Stream outgoingData)
        {
            var originalObj = target as System.Exception;
            var viewModel = new ExceptionViewModel(originalObj);
       
            base.GetData(viewModel, outgoingData);
        }
    }
}