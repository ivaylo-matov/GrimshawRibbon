using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;


namespace Kipple
{
    [Transaction(TransactionMode.Manual)]
    public class PurgeCADImports : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // get the uidoc and doc
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            // collect all import instances
            var allImportInstances = new FilteredElementCollector(doc)
                                .OfClass(typeof(ImportInstance))
                                .ToElements();

            using (Transaction trans = new Transaction(doc, "Purge fill patterns"))
            {
                trans.Start();
                int countDel = 0;
                foreach (ImportInstance i in allImportInstances)
                {
                    if (i.IsLinked == false)
                    {
                        try
                        {
                            doc.Delete(i.Id);
                            countDel += 1;
                        }
                        catch (Exception e)
                        {
                            message = e.Message;
                            return Result.Failed;
                        }
                    }
                }
                trans.Commit();
                if (countDel == 0)
                {
                    TaskDialog.Show("Purge CAD Imports", "Excellent! No CAD imports in the model, nothing was deleted.");
                }
                else if (countDel == 1)
                {
                    TaskDialog.Show("Purge CAD Imports", "One CAD import was deleted.");
                }
                else
                {
                    TaskDialog.Show("Purge CAD Imports", string.Format("{0} CAD imports were deleted.", countDel));
                }
            }
            return Result.Succeeded;
        }
    }
}
