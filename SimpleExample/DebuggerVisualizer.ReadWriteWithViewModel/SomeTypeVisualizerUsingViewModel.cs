using System;
using System.Windows.Forms;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace SimpleExample.DebuggerVisualizer.ReadWriteWithViewModel
{
    /// <summary>
    /// A Visualizer for SomeType that uses a ViewModel.  
    /// </summary>
    public class SomeTypeVisualizerUsingViewModel : DialogDebuggerVisualizer
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
            var data = objectProvider.GetObject() as SimpleExample.SomeType;
            
            // Display your view of the object.        
            using (var displayForm = new SomeTypeVisualizerWithViewModelForm(data))
            {
                displayForm.txtFoo.Text = data.Foo;


                // Read-Write Approach 1: Using ReplaceObject
                //displayForm.OnChange += (sender, newObject) => objectProvider.ReplaceObject(newObject);

                // Read-Write Approach 2: Using TransferData
                displayForm.OnChange += (sender, newObject) =>
                {
                    var response = objectProvider.TransferObject(newObject) as string;
                    if (!string.IsNullOrEmpty(response))
                    {
                        MessageBox.Show(response, "Response", MessageBoxButtons.OK);
                    }

                };
                
                windowService.ShowDialog(displayForm);
            }
        }
        
    }
}
