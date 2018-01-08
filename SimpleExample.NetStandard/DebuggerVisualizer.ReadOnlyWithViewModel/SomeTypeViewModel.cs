using System;

namespace SimpleExample.NetStandard.DebuggerVisualizer.ReadOnlyWithViewModel
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
