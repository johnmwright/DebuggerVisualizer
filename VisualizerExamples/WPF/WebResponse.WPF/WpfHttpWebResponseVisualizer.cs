using System;
using System.Net;
using System.Windows;
using Microsoft.VisualStudio.DebuggerVisualizers;
using VisualizerExamples.DebuggerVisualizer.ViewModels;
using VisualizerExamples.DebuggerVisualizer.WebResponse.WPF;

[assembly: System.Diagnostics.DebuggerVisualizer(
    typeof(WpfWebResponseVisualizer), //Your VS-side type
    typeof(WebResponseVisualObjectSource),   //the incoming type's provider -- default is ok if Type is serializable
    Target = typeof(WebResponse), //the type you want to visualize
    Description = "WPF WebResponse Visualizer")] //name shown in visualizer picker

namespace VisualizerExamples.DebuggerVisualizer.WebResponse.WPF
{

    public class WpfWebResponseVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            if (objectProvider == null)
                throw new ArgumentNullException(nameof(objectProvider));

            // Get the object to display a visualizer for.
            //       Cast the result of objectProvider.GetObject() 
            //       to the type of the object being visualized.
            var data = objectProvider.GetObject();
            var typedData = data as ResponseViewModel;

            // Display your view of the object.                       
            InitWpfWindow(typedData);

        }

        private void InitWpfWindow(ResponseViewModel dataContextObject)
        {

            var vizControl = new WebResponseVisualizerControl { DataContext = dataContextObject };

            // set the attributes of WPF window
            var win = new Window
            {
                Title = $"WPF {typeof(ResponseViewModel)} Visualizer",
                Width = 500,
                Height = 500,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Content = vizControl
            };

            win.ShowDialog();
        }

    }
}
