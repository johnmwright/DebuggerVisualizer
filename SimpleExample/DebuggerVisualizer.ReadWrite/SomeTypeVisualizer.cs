using System;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace SimpleExample.DebuggerVisualizer.ReadWrite
{
    
    /// <summary>
    /// A Visualizer for SomeType.  
    /// </summary>
    public class SomeTypeVisualizer : DialogDebuggerVisualizer
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
            var data = objectProvider.GetObject() as SimpleExample.SomeType;

           
            // Display your view of the object.
            //       Replace displayForm with your own custom Form or Control.
            using (var displayForm = new SomeTypeVisualizerForm(data))
            {
                //displayForm.OnChange += (object sender, SimpleExample.SomeType newObject) => objectProvider.TransferObject(newObject);
                displayForm.OnChange += (object sender, SimpleExample.SomeType newObject) => objectProvider.ReplaceObject(newObject);

                displayForm.txtFoo.Text = data.Foo;
                windowService.ShowDialog(displayForm);
            }
        }
        
    }
}
