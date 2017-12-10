using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace TotallyRealApp.DebuggerVisualizer.SomeType
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
            var data = objectProvider.GetObject() as Types.SomeType;

            void OnChangeDelegate(Types.SomeType newValue)
            {
                var result = objectProvider.TransferObject(newValue);   
            }

            // Display your view of the object.
            //       Replace displayForm with your own custom Form or Control.
            using (var displayForm = new SomeTypeVisualizerForm(data, OnChangeDelegate))
            {                
                windowService.ShowDialog(displayForm);
            }
        }
        
    }
}
