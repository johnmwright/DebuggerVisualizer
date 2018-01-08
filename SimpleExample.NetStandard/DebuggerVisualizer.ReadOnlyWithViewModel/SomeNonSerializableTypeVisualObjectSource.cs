using System.IO;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace SimpleExample.NetStandard.DebuggerVisualizer.ReadOnlyWithViewModel
{
    public class SomeNonSerializableTypeVisualObjectSource : VisualizerObjectSource
    {
        public override void GetData(object target, Stream outgoingData)
        {
            // `target` is the object being visualized.
            // Convert it to the ViewModel
            var originalObj = (SomeNonSerializableType)target;
            var viewModel = new SomeTypeViewModel(originalObj);
            
            // Send the ViewModel to the Visualizer via the outgoingData stream.
            base.GetData(viewModel, outgoingData);
        }
    }
}

