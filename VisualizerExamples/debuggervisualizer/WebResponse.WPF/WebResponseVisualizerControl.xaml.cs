using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Highlighting;
using VisualizerExamples.DebuggerVisualizer.ViewModels;

namespace VisualizerExamples.DebuggerVisualizer.WebResponse.WPF
{
    /// <summary>
    /// Interaction logic for WebResponseVisualizerControl.xaml
    /// </summary>
    public partial class WebResponseVisualizerControl : UserControl
    {
        public WebResponseVisualizerControl()
        {
            InitializeComponent();
            DataContextChanged += OnDataContextChanged;
        }

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            if (DataContext is ResponseViewModel responseVM)
            {
                var highlightType = GetHighlightingType(responseVM.ContentType);               
                txtResponse.SyntaxHighlighting = highlightType;
                txtResponse.Text = responseVM.RawResponse;
            }
            else
            {
                txtResponse.Document = null;
            }
        }

        public IHighlightingDefinition GetHighlightingType(string contentType)
        {
  
            var contextType = contentType?.Split(';').FirstOrDefault() ?? "";

            string typeName = null;

            if (contextType.EndsWith("html", StringComparison.OrdinalIgnoreCase))
                typeName = "HTML";

            if (contextType.EndsWith("json", StringComparison.OrdinalIgnoreCase))
                typeName = "JavaScript";


            if (contextType.EndsWith("xml", StringComparison.OrdinalIgnoreCase))
                typeName = "XML";

            if (contextType.EndsWith("svg", StringComparison.OrdinalIgnoreCase))
                typeName = "XML";


            if (contextType.EndsWith("css", StringComparison.OrdinalIgnoreCase))
                typeName = "CSS";

            return typeName == null
                ? null
                : HighlightingManager.Instance.GetDefinition(typeName);
        }
    
        
        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tabControl = sender as TabControl;
            var selected = tabControl.SelectedItem as TabItem;
            if (selected == tabBrowser)
            {
                var responseVM = DataContext as ResponseViewModel;

                webResposne.NavigateToString(responseVM?.RawResponse ?? "");
            }
        }
    }
}
