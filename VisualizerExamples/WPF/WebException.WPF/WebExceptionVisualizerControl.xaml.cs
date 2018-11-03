using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using VisualizerExamples.DebuggerVisualizer.ViewModels;
using mshtml;

namespace VisualizerExamples.DebuggerVisualizer.WebException.WPF
{
    /// <summary>
    /// Interaction logic for WebExceptionVisualizerControl.xaml
    /// </summary>
    public partial class WebExceptionVisualizerControl : UserControl
    {
        public WebExceptionVisualizerControl()
        {
            InitializeComponent();
            DataContextChanged += OnDataContextChanged;            
        }

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var responseVM = DataContext as WebExceptionViewModel;
            stacktraceBrowser.NavigateToString(responseVM?.StackTraceFormatted ?? "");
            
        }

        private void StacktraceBrowser_OnLoadCompleted(object sender, NavigationEventArgs e)
        {
            //inspired by http://www.codewrecks.com/blog/index.php/2009/03/11/hilite-words-in-webbrowser-now-for-wpf-control/

            IHTMLDocument2 doc2 = stacktraceBrowser.Document as IHTMLDocument2;
            IHTMLStyleSheet style = doc2.createStyleSheet("", 0);
            style.cssText = ReadCss();
            
        }

        private string ReadCss()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "VisualizerExamples.DebuggerVisualizer.WebResponse.WPF.Stylesheet.css";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
