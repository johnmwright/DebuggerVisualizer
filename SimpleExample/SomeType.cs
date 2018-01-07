using System;
using System.Diagnostics;

namespace SimpleExample
{
    [DebuggerVisualizer(typeof(DebuggerVisualizer.ReadWrite.SomeTypeVisualizer), 
                        typeof(DebuggerVisualizer.ReadWrite.SomeTypeVisualizerObjectSource), 
                        Description = "Editable SomeType Visualizer")]
    [DebuggerVisualizer(typeof(DebuggerVisualizer.ReadOnly.SomeTypeVisualizer), 
                        Description = "ReadOnly SomeType Visualizer")]
    
    [Serializable]
    public class SomeType
    {
        public string Foo { get; set; }
    }    
}
