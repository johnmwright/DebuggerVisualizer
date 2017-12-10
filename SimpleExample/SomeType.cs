using System;
using System.Diagnostics;
using ReadOnly = SimpleExample.DebuggerVisualizer.ReadOnly;
using ReadWrite = SimpleExample.DebuggerVisualizer.ReadWrite;

namespace SimpleExample
{

    [DebuggerVisualizer(typeof(ReadOnly.SomeTypeVisualizer), Description = "ReadOnly SomeType Visualizer")]
    [DebuggerVisualizer(typeof(ReadWrite.SomeTypeVisualizer), typeof(ReadWrite.SomeTypeVisualizerObjectSource), Description = "Editable SomeType Visualizer")]
    [Serializable]
    public class SomeType
    {
        public string Foo { get; set; }
    }
    
}
