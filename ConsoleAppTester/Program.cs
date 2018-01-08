using System;
using System.Diagnostics;
using Microsoft.VisualStudio.DebuggerVisualizers;
using SimpleExample.NetStandard;

namespace ConsoleAppTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var objectToVisualize = new SomeType(){Foo = "test"};

            Debugger.Break();

            var objectToVisualize2 = new SomeNonSerializableType() { Foo = "test" };

            Debugger.Break();

        }
    }
}
