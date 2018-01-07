using System;

namespace SimpleExample.DebuggerVisualizer.ReadOnlyWithViewModel
{
    [Serializable]
    public class SomeTypeViewModel
    {
        public SomeTypeViewModel(SomeNonSerializableType original)
        {
            Foo = original.Foo;
        }

        public string Foo { get; set; }
    }
}
