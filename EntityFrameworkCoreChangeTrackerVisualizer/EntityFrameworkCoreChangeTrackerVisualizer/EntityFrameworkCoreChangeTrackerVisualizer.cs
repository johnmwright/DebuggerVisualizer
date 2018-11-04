using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EntityFrameworkCoreChangeTrackerVisualizerObjectSource;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.VisualStudio.DebuggerVisualizers;


[assembly: DebuggerVisualizer(typeof(EntityFrameworkCoreChangeTrackerVisualizer.EntityFrameworkCoreChangeTrackerVisualizer),
    visualizerObjectSource: typeof(ChangeTrackerVisualObjectSource), 
    Target = typeof(ChangeTracker),
    Description = "EntityFramework ChangeTracker Visualizer")]



[assembly: DebuggerVisualizer(typeof(EntityFrameworkCoreChangeTrackerVisualizer.EntityFrameworkCoreChangeTrackerVisualizer),
    visualizerObjectSource: typeof(DbContextChangeTrackerVisualObjectSource),
    Target = typeof(DbContext),
    Description = "EntityFramework ChangeTracker Visualizer")]

//inspired from https://twitter.com/nick_craver/status/1039222872114384897?s=21

namespace EntityFrameworkCoreChangeTrackerVisualizer
{
    public class EntityFrameworkCoreChangeTrackerVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            if (windowService == null) throw new ArgumentNullException(nameof(windowService));
            if (objectProvider == null) throw new ArgumentNullException(nameof(objectProvider));

            // Get the object to display a visualizer for.            
            var data = objectProvider.GetObject() as ChangeTrackerViewModel;


            // Load the WPF Window
            var vizControl = new ChangeTrackerControl() { DataContext = data };
            
            // set the attributes of WPF window
            var win = new Window
            {
                Title = $"EntityFramework ChangeTracker Visualizer",
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Content = vizControl,
                ResizeMode = ResizeMode.CanResizeWithGrip,
                Topmost = true,
                SizeToContent = SizeToContent.WidthAndHeight,
                ShowInTaskbar = true
            };
            
            win.ShowDialog();
        }
    }
}
