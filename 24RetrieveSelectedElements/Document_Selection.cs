using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;

namespace _24RetrieveSelectedElements
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.ReadOnly)]
    public class Document_Selection: IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, 
            ref string message, 
            ElementSet elements)
        {
            try
            {
                //Select some elements in Revit before invoking this command

                //Get the handle of current document.
                UIDocument uidoc = commandData.Application.ActiveUIDocument;
                Document doc = uidoc.Document;
                //Get the element selection of current document
                Selection sel = uidoc.Selection;
                string info = "";
                if (0 == sel.GetElementIds().Count())
                {
                    info = "You haven't selected any elements.";
                }
                else
                {
                    info = "Ids of the selected elements in the document are: \n";
                    foreach (ElementId eleId in sel.GetElementIds())
                    {
                        Element ele = doc.GetElement(eleId);
                        info += "\n\t" + ele.Id.IntegerValue;
                    }
                }
                TaskDialog.Show("Revit", info);
            }

            catch(Exception e)
            {
                message = e.Message;
                return Result.Failed;
            }
            return Result.Succeeded;
        }
    }
}
