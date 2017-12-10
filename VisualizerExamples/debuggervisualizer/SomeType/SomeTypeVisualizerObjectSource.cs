using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace TotallyRealApp.DebuggerVisualizer.SomeType
{
    public class SomeTypeVisualizerObjectSource : VisualizerObjectSource
    {
        //public override void GetData(object target, Stream outgoingData)
        //{
        //    base.GetData(target, outgoingData);
        //}

        public override void TransferData(object target, Stream incomingData, Stream outgoingData)
        {
            Debugger.Launch();
            var originalObject = target as Types.SomeType;

            
            var incomingChangedObject = Deserialize(incomingData) as Types.SomeType;
            originalObject.Foo = incomingChangedObject.Foo;
            Debugger.Break();
                
            Serialize(outgoingData, true);
            
        }

        public override object CreateReplacementObject(object target, Stream incomingData)
        {
            //returns a new instance of the object, which VS will substitute for the original object in memory
            // Beware object pointers!
            return base.CreateReplacementObject(target, incomingData);
        }
    }
}