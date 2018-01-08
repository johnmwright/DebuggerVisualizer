using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Diagnostics;
using System.Net;
using SimpleExample;
using SimpleExample.DebuggerVisualizer;
using SimpleExample.DebuggerVisualizer.ReadOnlyWithViewModel;
using NetStandard = SimpleExample.NetStandard;
using ReadOnly =SimpleExample.DebuggerVisualizer.ReadOnly;
using ReadWrite = SimpleExample.DebuggerVisualizer.ReadWrite;
using VisualizerExamples.DebuggerVisualizer.Exception;
using VisualizerExamples.DebuggerVisualizer.WebException.Simple;
using VisualizerExamples.DebuggerVisualizer.WebException.WPF;


namespace DebuggerVisualizer.TestHarness
{
    
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            Web();

            TestShowObjectVisualizer(new SomeType() { Foo = "Foo bar" });

            TestShowObjectVisualizerWithObjectSource(new SomeType() {Foo = "Foo bar"});

            TestShowEditableObjectVisualizer(new SomeType() { Foo = "Foo bar" });

            TestShowExceptionVisualizer(new WebException("this broke"));

            TestShowWpfExceptionVisualizer(new WebException("this broke"));

            SomeTypeVisualizerWriteBackTest(new SomeType() {Foo = "Foo bar"});

            TestShowNetStandardObjectVisualizer(new NetStandard.SomeType() {Foo = "Foo bar"});

            TestShowNetStandardNonSerializableObjectVisualizer(new NetStandard.SomeNonSerializableType { Foo = "Foo bar" });
        }

        private static void SomeTypeVisualizerWriteBackTest(SomeType someType)
        {
            while (someType.Foo != "done")
            {
                Debugger.Break();
                System.Windows.MessageBox.Show(someType.Foo);
            }
        }

        private static void Web()
        {

            try
            {
                using (var client = new WebClient())
                {                
                    var jsonUrl = "https://jsonplaceholder.typicode.com/posts";

                    var xmlUrl = "http://api.wordnik.com/v4/words.xml/randomWords?hasDictionaryDef=false&minCorpusCount=0&maxCorpusCount=-1&minDictionaryCount=1&maxDictionaryCount=-1&minLength=5&maxLength=-1&limit=10&api_key=a2a73e7b926c924fad7001ca3111acd55af2ffabf50eb4ae5";
                    
                    var error404Url = "https://wrightfully.com/notreal";

                    var response = client.DownloadString(error404Url);               
                    Debugger.Break();                        
                }                
            }
            catch (WebException ex)
            {
                VisualizerDevelopmentHost visualizerHost = new VisualizerDevelopmentHost(ex, typeof(WpfWebExceptionVisualizer), typeof(WebExceptionVisualObjectSource));
                visualizerHost.ShowVisualizer();             
            }
            catch (Exception ex)
            {
                Debugger.Break();
                Console.WriteLine(ex.ToString());
            }

        }
        
        public static void TestShowObjectVisualizer(object objectToVisualize)
        {
            var visualizerHost = new VisualizerDevelopmentHost(objectToVisualize: objectToVisualize, 
                                                               visualizer: typeof(ReadOnly.SomeTypeVisualizer));
            visualizerHost.ShowVisualizer();
        }


        public static void TestShowObjectVisualizerWithObjectSource(object objectToVisualize)
        {
            var visualizerHost = new VisualizerDevelopmentHost(objectToVisualize: objectToVisualize,
                                                               visualizer: typeof(SomeNonSerializableTypeVisualizer),
                                                               visualizerObjectSource: typeof(SomeNonSerializableTypeVisualObjectSource));
            visualizerHost.ShowVisualizer();
        }



        public static void TestShowEditableObjectVisualizer(object objectToVisualize)
        {
            var visualizerHost = new VisualizerDevelopmentHost(objectToVisualize: objectToVisualize, 
                                                               visualizer: typeof(ReadWrite.SomeTypeVisualizer), 
                                                               visualizerObjectSource: typeof(ReadWrite.SomeTypeVisualizerObjectSource),
                                                               replacementOK: true);
            visualizerHost.ShowVisualizer();
        }

        public static void TestShowNetStandardObjectVisualizer(object objectToVisualize)
        {
            Debugger.Break();
            var visualizerHost = new VisualizerDevelopmentHost(objectToVisualize: objectToVisualize,
                visualizer: typeof(NetStandard.DebuggerVisualizer.ReadOnly.SomeTypeVisualizer));
            visualizerHost.ShowVisualizer();
        }


        public static void TestShowNetStandardNonSerializableObjectVisualizer(object objectToVisualize)
        {
            Debugger.Break();
            var visualizerHost = new VisualizerDevelopmentHost(objectToVisualize: objectToVisualize,
                visualizer: typeof(NetStandard.DebuggerVisualizer.ReadOnlyWithViewModel.SomeNonSerializableTypeVisualizer),
                visualizerObjectSource: typeof(NetStandard.DebuggerVisualizer.ReadOnlyWithViewModel.SomeNonSerializableTypeVisualObjectSource));
            visualizerHost.ShowVisualizer();
        }

        public static void TestShowExceptionVisualizer(object objectToVisualize)
        {
            VisualizerDevelopmentHost visualizerHost = new VisualizerDevelopmentHost(objectToVisualize, typeof(SimpleExceptionVisualizer));
            visualizerHost.ShowVisualizer();
        }


        public static void TestShowWpfExceptionVisualizer(object objectToVisualize)
        {
            VisualizerDevelopmentHost visualizerHost = new VisualizerDevelopmentHost(objectToVisualize, 
                typeof(WpfWebExceptionVisualizer), 
                typeof(WebExceptionVisualObjectSource));
            visualizerHost.ShowVisualizer();
        }
        
    }
}



