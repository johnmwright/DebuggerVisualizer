using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace SimpleExample.DebuggerVisualizer.ReadWrite
{
    public class SomeTypeVisualizerObjectSource : VisualizerObjectSource
    {
        public override void GetData(object target, Stream outgoingData)
        {
            base.GetData(target, outgoingData);
        }

        public override void TransferData(object target, Stream incomingData, Stream outgoingData)
        {
            Debugger.Launch();

            var originalObject = target as SimpleExample.SomeType;
           
            var incomingChangedObject = Deserialize(incomingData) as SimpleExample.SomeType;

            // any changes to the object must be applied to the incoming target object instance
            originalObject.Foo = incomingChangedObject.Foo;
            Debugger.Break();
                
            //(optional) send a response message back to the Visualizer
            Serialize(outgoingData, "It worked!");            
        }

        public override object CreateReplacementObject(object target, Stream incomingData)
        {
            Debugger.Launch();

            var originalObject = target as SimpleExample.SomeType;

            var incomingChangedObject = Deserialize(incomingData) as SimpleExample.SomeType;
            // if this is a ViewModel, you'll need to map the value into either a new instance of 
            // the visualized type, or modify the originalObject with the ViewModel's values and return
            // the originalObject as the new instance.

            // Beware object pointers! If you have an object graph or other data types which will result in
            // cloned objects being created during the serialization/deserialization process, you'll need to
            // handle that here.

            //returns a instance of the object, which VS will substitute for the original object in memory
            return incomingChangedObject;           
        }
    }
}