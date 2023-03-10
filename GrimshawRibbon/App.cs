using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Media.Imaging;
using System.IO;

namespace KippleRibbon
{
    class App : IExternalApplication
    {
        // define a method that will create our tab and button
        static void AddRibbonPanel(UIControlledApplication application)
        {
            // Create a custom ribbon tab
            string tabName = "Kipple_WIP";
            application.CreateRibbonTab(tabName);

            // Add a new ribbon panel
            RibbonPanel ribbonPanel = application.CreateRibbonPanel(tabName, "Purge Plus");

            // Get dll assembly path
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            // create pushdown button for Purge +
            PulldownButtonData pbg1Data = new PulldownButtonData("DropdownGrouop1", "Purge +");
            PulldownButton pbg1 = ribbonPanel.AddItem(pbg1Data) as PulldownButton;
            pbg1.ToolTip = "Collection of tools to purge various elements that cannot be purged by the OOTB purge tool.";

            // create image for all icons
            BitmapImage purgeIcon = new BitmapImage(new Uri("pack://application:,,,/KippleRibbon;component/Resources/PurgePlus.png"));
            pbg1.LargeImage = purgeIcon;

            // create the push buttons below
            PushButtonData b1Data = new PushButtonData("cmdPurgeCADImport1", "Purge CAD Imports1", thisAssemblyPath, "Kipple.PurgeCADImports");
            PushButton pb1 = pbg1.AddPushButton(b1Data) as PushButton;
            pb1.ToolTip = "This is tool 1.";
            pb1.LargeImage = purgeIcon;

            PushButtonData b2Data = new PushButtonData("cmdPurgeCADImport2", "Purge CAD Imports2", thisAssemblyPath, "Kipple.PurgeCADImports");
            PushButton pb2 = pbg1.AddPushButton(b2Data) as PushButton;
            pb2.ToolTip = "This is tool 2.";
            pb2.LargeImage = purgeIcon;

            PushButtonData b3Data = new PushButtonData("cmdPurgeCADImport3", "Purge CAD Imports3", thisAssemblyPath, "Kipple.PurgeCADImports");
            PushButton pb3 = pbg1.AddPushButton(b3Data) as PushButton;
            pb3.ToolTip = "This is tool 3.";
            pb3.LargeImage = purgeIcon;

            PushButtonData b4Data = new PushButtonData("cmdPurgeCADImport4", "Purge CAD Imports4", thisAssemblyPath, "Kipple.PurgeCADImports");
            PushButton pb4 = pbg1.AddPushButton(b4Data) as PushButton;
            pb4.ToolTip = "This is tool 4.";
            pb4.LargeImage = purgeIcon;

        }

        public Result OnShutdown(UIControlledApplication application)
        {
            // do nothing just a simple return
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            // call our method that will load up our toolbar
            AddRibbonPanel(application);
            return Result.Succeeded;
        }
    }
}
