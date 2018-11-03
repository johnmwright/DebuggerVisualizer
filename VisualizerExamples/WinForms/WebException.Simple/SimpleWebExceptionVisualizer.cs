using System;
using System.Diagnostics;
using System.Net;
using Microsoft.VisualStudio.DebuggerVisualizers;
using VisualizerExamples.DebuggerVisualizer.ViewModels;
using VisualizerExamples.DebuggerVisualizer.WebException.Simple;
using VisualizerExamples.DebuggerVisualizer.WebException.WPF;

[assembly: DebuggerVisualizer(
    typeof(SimpleWebExceptionVisualizer), //Your VS-side type
    typeof(WebExceptionVisualObjectSource), //the incoming type's provider -- default is ok if Type is serializable
    Target = typeof(WebException), //the type you want to visualize
    Description = "Simple WebException Visualizer")] //name shown in visualizer picker

namespace VisualizerExamples.DebuggerVisualizer.WebException.Simple
{

    public class SimpleWebExceptionVisualizer : DialogDebuggerVisualizer
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
            var data = objectProvider.GetObject() as WebExceptionViewModel;

            // Display your view of the object.           
            using (var displayForm = new SimpleWebExceptionWinForm())
            {
                if (data == null)
                {
                    displayForm.txtMessage.Text = "<null>";                    
                }
                else
                {
                    displayForm.Text = objectProvider.GetType().FullName; // TitleBar
                    displayForm.txtMessage.Text = data.Message; 
                    displayForm.txtStackTrace.Text = data.StackTrace;
                    displayForm.txtResponse.Text = data.HasResponse ? data.Response.RawResponse : "<null>";
                }

                windowService.ShowDialog(displayForm);
            }
        }
        

    }
}
