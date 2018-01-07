using System.Diagnostics;
using SimpleExample.DebuggerVisualizer.ReadOnlyWithViewModel;

namespace SimpleExample
{
    [DebuggerVisualizer(visualizer: typeof(SomeNonSerializableTypeVisualizer),
            visualizerObjectSource: typeof(SomeNonSerializableTypeVisualObjectSource),
                      Description = "ReadOnly SomeNonSerializableType Visualizer")]        
    public class SomeNonSerializableType
    {
        public string Foo { get; set; }
    }    
}

