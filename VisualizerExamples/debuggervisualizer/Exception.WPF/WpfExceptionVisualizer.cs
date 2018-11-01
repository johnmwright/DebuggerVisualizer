using System;
using System.Windows;
using Microsoft.VisualStudio.DebuggerVisualizers;
using VisualizerExamples.DebuggerVisualizer.Exception.WPF;
using VisualizerExamples.DebuggerVisualizer.ViewModels;

[assembly: System.Diagnostics.DebuggerVisualizer(
    typeof(WpfExceptionVisualizer), //Your VS-side type
    typeof(ExceptionVisualObjectSource), // the incoming type's provider -- default is ok if Type is serializable (typeof(Microsoft.VisualStudio.Debugger.VisualizerObjectProvider))
    Target = typeof(Exception), //the type you want to visualize
    Description = "WPF Exception Visualizer")] //name shown in visualizer picker

namespace VisualizerExamples.DebuggerVisualizer.Exception.WPF
{

    public class WpfExceptionVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {

            if (objectProvider == null)
                throw new ArgumentNullException(nameof(objectProvider));

            // Get the object to display a visualizer for.
            //       Cast the result of objectProvider.GetObject() 
            //       to the type of the object being visualized.
            var data = objectProvider.GetObject() as ExceptionViewModel;


            // Display your view of the object.                       
            var vizControl = new ExceptionVisualizerControl { DataContext = data };


            // set the attributes of WPF window
            var win = new Window
            {
                Title = "WPF Exception Visualizer",              
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
