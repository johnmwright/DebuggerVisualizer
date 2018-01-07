using System;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace SimpleExample.DebuggerVisualizer.ReadOnlyWithViewModel
{
    /// <summary>
    /// A Visualizer for SomeNonSerializableType that uses a ViewModel.  
    /// </summary>
    public class SomeNonSerializableTypeVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, 
                                     IVisualizerObjectProvider objectProvider)
        {
            if (windowService == null) throw new ArgumentNullException(nameof(windowService));
            if (objectProvider == null) throw new ArgumentNullException(nameof(objectProvider));

            // Get the object to display a visualizer for.            
            var data = objectProvider.GetObject() as SomeTypeViewModel;
           
            // Display your view of the object.        
            using (var displayForm = new SomeTypeVisualizerWithViewModelForm())
            {
                displayForm.Load += (sender, args) => displayForm.txtFoo.Text = data.Foo;
                windowService.ShowDialog(displayForm);
            }
        }        
    }
}
