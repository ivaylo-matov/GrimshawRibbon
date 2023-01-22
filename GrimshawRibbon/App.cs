using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Media.Imaging;

namespace GrimshawRibbon
{
    class App : IExternalApplication
    {
        // define a method that will create our tab and button
        static void AddRibbonPanel(UIControlledApplication application)
        {
            // Create a custom ribbon tab
            string tabName = "ACG Tools_C";
            application.CreateRibbonTab(tabName);

            // Add a new ribbon panel
            RibbonPanel ribbonPanel = application.CreateRibbonPanel(tabName, "Purge +");

            // Get dll assembly path
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            // create push buttons for PurgeCADImport
            PulldownButtonData pbg1Data = new PulldownButtonData("DropdownGrouop1", "Purge +");
            PulldownButton pbg1 = ribbonPanel.AddItem(pbg1Data) as PulldownButton;

            //BitmapImage pbg1Image = new BitmapImage(new Uri("pack://application:,,,/GrimshawRibbon;component/Resources/PurgePlusPushdown.png"));
            //pbg1.Image = pbg1Image;


            PushButtonData b1Data = new PushButtonData("cmdPurgeCADImport1", "Purge CAD Imports1", thisAssemblyPath, "Kipple.PurgeCADImports");
            PushButton pb1 = pbg1.AddPushButton(b1Data) as PushButton;
            pb1.ToolTip = "This is tool 1.";
            BitmapImage pb1Image = new BitmapImage(new Uri("pack://application:,,,/GrimshawRibbon;component/Resources/PurgePlus1.png"));
            pb1.LargeImage = pb1Image;

            PushButtonData b2Data = new PushButtonData("cmdPurgeCADImport2", "Purge CAD Imports2", thisAssemblyPath, "Kipple.PurgeCADImports");
            PushButton pb2 = pbg1.AddPushButton(b2Data) as PushButton;
            pb1.ToolTip = "This is tool 2.";
            BitmapImage pb2Image = new BitmapImage(new Uri("pack://application:,,,/GrimshawRibbon;component/Resources/PurgePlus2.png"));
            pb1.LargeImage = pb1Image;

            PushButtonData b3Data = new PushButtonData("cmdPurgeCADImport3", "Purge CAD Imports3", thisAssemblyPath, "Kipple.PurgeCADImports");
            PushButton pb3 = pbg1.AddPushButton(b3Data) as PushButton;
            pb1.ToolTip = "This is tool 3.";
            BitmapImage pb3Image = new BitmapImage(new Uri("pack://application:,,,/GrimshawRibbon;component/Resources/PurgePlus3.png"));
            pb1.LargeImage = pb1Image;

            PushButtonData b4Data = new PushButtonData("cmdPurgeCADImport4", "Purge CAD Imports4", thisAssemblyPath, "Kipple.PurgeCADImports");
            PushButton pb4 = pbg1.AddPushButton(b4Data) as PushButton;
            pb1.ToolTip = "This is tool 4.";
            BitmapImage pb4Image = new BitmapImage(new Uri("pack://application:,,,/GrimshawRibbon;component/Resources/PurgePlus4.png"));
            pb1.LargeImage = pb1Image;

            //pbg1.CurrentButton = pb1;
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
