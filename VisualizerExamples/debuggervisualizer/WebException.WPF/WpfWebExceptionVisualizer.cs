using System;
using System.Net;
using System.Windows;
using Microsoft.VisualStudio.DebuggerVisualizers;
using VisualizerExamples.DebuggerVisualizer.ViewModels;
using VisualizerExamples.DebuggerVisualizer.WebException.WPF;

[assembly: System.Diagnostics.DebuggerVisualizer(
    typeof(WpfWebExceptionVisualizer), //Your VS-side type
    typeof(WebExceptionVisualObjectSource), // the incoming type's provider -- default is ok if Type is serializable (typeof(Microsoft.VisualStudio.Debugger.VisualizerObjectProvider))
    Target = typeof(WebException), //the type you want to visualize
    Description = "WPF WebException Visualizer")] //name shown in visualizer picker

namespace VisualizerExamples.DebuggerVisualizer.WebException.WPF
{

    public class WpfWebExceptionVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {

            if (objectProvider == null)
                throw new ArgumentNullException(nameof(objectProvider));

            // Get the object to display a visualizer for.
            //       Cast the result of objectProvider.GetObject() 
            //       to the type of the object being visualized.
            var data = objectProvider.GetObject() as WebExceptionViewModel;


            // Display your view of the object.                       
            var vizControl = new WebExceptionVisualizerControl { DataContext = data };


            // set the attributes of WPF window
            var win = new Window
            {
                Title = "WPF Web Exception Visualizer",              
                Width = 900,
                Height = 700,
                Padding = new Thickness(5),
                Margin = new Thickness(5),
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Content = vizControl,
                VerticalContentAlignment = VerticalAlignment.Stretch,
                HorizontalContentAlignment = HorizontalAlignment.Stretch
            };

            win.ShowDialog();

        }

        


    }
}
