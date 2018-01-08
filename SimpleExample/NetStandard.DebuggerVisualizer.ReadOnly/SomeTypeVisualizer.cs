using System;
using System.Diagnostics;
using Microsoft.VisualStudio.DebuggerVisualizers;

[assembly:DebuggerVisualizer(typeof(SimpleExample.NetStandard.DebuggerVisualizer.ReadOnly.SomeTypeVisualizer),
    //typeof(SomeTypeVisualizerObjectSource), 
    Target = typeof(SimpleExample.NetStandard.SomeType),
    Description = "ReadOnly NetCore.SomeType Visualizer")]

namespace SimpleExample.NetStandard.DebuggerVisualizer.ReadOnly
{
  

    /// <summary>
    /// A Visualizer for SomeType.  
    /// </summary>
    public class SomeTypeVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, 
                                     IVisualizerObjectProvider objectProvider)
        {
            if (windowService == null)
                throw new ArgumentNullException(nameof(windowService));

            if (objectProvider == null)
                throw new ArgumentNullException(nameof(objectProvider));

            // Get the object to display a visualizer for.
            //       Cast the result of objectProvider.GetObject() 
            //       to the type of the object being visualized.
            var data = objectProvider.GetObject() as SimpleExample.NetStandard.SomeType;
            
            // Display your view of the object.       
            using (var displayForm = new SomeTypeVisualizerForm())
            {
                displayForm.Load += (sender, args) => displayForm.txtFoo.Text = data.Foo;                
                windowService.ShowDialog(displayForm);
            }
        }        
    }
}

