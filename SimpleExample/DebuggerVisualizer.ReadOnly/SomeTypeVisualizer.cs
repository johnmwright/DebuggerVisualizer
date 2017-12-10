﻿using System;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace SimpleExample.DebuggerVisualizer.ReadOnly
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
            using (var displayForm = new SomeTypeVisualizerForm())
            {
                displayForm.Load += (sender, args) => displayForm.txtFoo.Text = data.Foo;
                displayForm.txtFoo.Text = data.Foo;
                windowService.ShowDialog(displayForm);
            }
        }
        
    }
}
