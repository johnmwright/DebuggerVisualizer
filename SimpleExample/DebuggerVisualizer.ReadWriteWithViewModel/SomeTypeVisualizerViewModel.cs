using System;

namespace SimpleExample.DebuggerVisualizer.ReadWriteWithViewModel
{
    [Serializable]
    public class SomeTypeVisualizerViewModel
    {
        public SomeTypeVisualizerViewModel(SomeType original)
        {
            Foo = original.Foo;
        }

        public string Foo { get; set; }
    }
}
