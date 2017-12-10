using System;
using System.Diagnostics;
using TotallyRealApp.DebuggerVisualizer.SomeType;

namespace TotallyRealApp.Types
{

    [DebuggerVisualizer(typeof(SomeTypeVisualizer), typeof(SomeTypeVisualizerObjectSource), Target=typeof(SomeType))]
    [Serializable]
    public class SomeType
    {
        public string Foo { get; set; }
    }


}
