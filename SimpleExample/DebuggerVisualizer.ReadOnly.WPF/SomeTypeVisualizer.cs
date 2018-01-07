using System;
using System.Windows;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace SimpleExample.DebuggerVisualizer.ReadOnly.WPF
{
    /// <summary>
    /// A WPF Visualizer for SomeType.  
    /// </summary>
    public class SomeTypeVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, 
                                     IVisualizerObjectProvider objectProvider)
        {
            if (objectProvider == null) throw new ArgumentNullException(nameof(objectProvider));

            // Get the object to display a visualizer for.          
            var data = (SomeType)objectProvider.GetObject();

            // Load the WPF Window
            var vizControl = new SomeTypeVisualizerControl { DataContext = data };

            // set the attributes of WPF window
            var win = new Window
            {
                Title = $"WPF {typeof(SomeType)} Visualizer",
                Width = 150, Height = 30,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Content = vizControl
            };

            win.ShowDialog();
        }        
    }
}

