using System;
using Microsoft.VisualStudio.DebuggerVisualizers;
using VisualizerExamples.DebuggerVisualizer.Exception;

[assembly: System.Diagnostics.DebuggerVisualizer(
    typeof(SimpleExceptionVisualizer), //Your VS-side type
    // typeof(Microsoft.VisualStudio.Debugger.VisualizerObjectProvider), //the incoming type's provider -- default is ok if Type is serializable
    Target = typeof(Exception), //the type you want to visualize
    Description = "Simple Exception Visualizer")] //name shown in visualizer picker

namespace VisualizerExamples.DebuggerVisualizer.Exception
{

    public class SimpleExceptionVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            if (windowService == null)
                throw new ArgumentNullException(nameof(windowService));

            if (objectProvider == null)
                throw new ArgumentNullException(nameof(objectProvider));

            // Get the object to display a visualizer for.
            //       Cast the result of objectProvider.GetObject() 
            //       to the type of the object being visualized.
            var data = objectProvider.GetObject() as System.Exception;

            // Display your view of the object.            
            using (var displayForm = new SimpleExceptionWinForm())
            {
                if (data == null)
                {
                    displayForm.txtMessage.Text = "<null>";
                }
                else
                {
                    displayForm.txtMessage.Text = data.Message; 
                    displayForm.txtStackTrace.Text = data.StackTrace;
                }

                windowService.ShowDialog(displayForm);
            }
        }
        

    }
}
