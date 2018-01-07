using System.Windows;
using System.Windows.Controls;
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
            
        }

        private void BtnResponseRaw_OnClick(object sender, RoutedEventArgs e)
        {
            btnResponseRaw.IsEnabled = false;
            btnResponseWeb.IsEnabled = true;
            txtResponse.Visibility = Visibility.Visible;
            webResposne.Visibility = Visibility.Collapsed;
        }

        private void BtnResponseWeb_OnClick(object sender, RoutedEventArgs e)
        {
            btnResponseRaw.IsEnabled = true;
            btnResponseWeb.IsEnabled = false;
            txtResponse.Visibility = Visibility.Collapsed;
            webResposne.Visibility = Visibility.Visible;

            var responseVM = DataContext as ResponseViewModel;
            
            webResposne.NavigateToString(responseVM?.RawResponse ?? "");
        }
    }
}
