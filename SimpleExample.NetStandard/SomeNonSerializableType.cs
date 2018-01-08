using System.Diagnostics;

namespace SimpleExample.NetStandard
{
    //[DebuggerVisualizer(visualizer: typeof(SomeNonSerializableTypeVisualizer),
    //        visualizerObjectSource: typeof(SomeNonSerializableTypeVisualObjectSource),
    //                  Description = "ReadOnly SomeNonSerializableType Visualizer")]        
    public class SomeNonSerializableType
    {
        public string Foo { get; set; }
    }    
}

