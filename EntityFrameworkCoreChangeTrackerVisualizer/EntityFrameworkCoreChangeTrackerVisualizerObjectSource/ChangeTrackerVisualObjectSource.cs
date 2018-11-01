using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace EntityFrameworkCoreChangeTrackerVisualizerObjectSource
{
    public class ChangeTrackerVisualObjectSource: VisualizerObjectSource
    {
        public override void GetData(object target, Stream outgoingData)
        {
            // `target` is the object being visualized.
            // Convert it to the ViewModel
            var originalObj = (ChangeTracker)target;
            var viewModel = new ChangeTrackerViewModel(originalObj); 

            // Send the ViewModel to the Visualizer via the outgoingData stream.
            base.GetData(viewModel, outgoingData);
        }
    }
}
