using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;

namespace _38ApplictionDialogShowing
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class Application_DialogShowing: IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            application.DialogBoxShowing += 
                new EventHandler<Autodesk.Revit.UI.Events.DialogBoxShowingEventArgs>(AppDialogShowing);
            return Result.Succeeded;
        }

        //void application_DialogBoxShowing(object sender, Autodesk.Revit.UI.Events.DialogBoxShowingEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        public Result OnShutdown(UIControlledApplication application)
        {
            application.DialogBoxShowing -=
                new EventHandler<Autodesk.Revit.UI.Events.DialogBoxShowingEventArgs>(AppDialogShowing);
            return Result.Succeeded;
        }

        public void AppDialogShowing(object sender, Autodesk.Revit.UI.Events.DialogBoxShowingEventArgs arg)
        {
            //get the help id of the showing dialog
            int dialogId = arg.HelpId;

            //Format the prompt information string
            string promptInfo = "lalala";
            promptInfo += "HelpId : " + dialogId.ToString();

            //Show the prompt information and allow the user close the dialog directly
            TaskDialog td = new TaskDialog("taskDialog1");
            td.MainContent = promptInfo;
            TaskDialogCommonButtons buttons = TaskDialogCommonButtons.Ok| TaskDialogCommonButtons.Cancel;
            td.CommonButtons = buttons;
            //??liuzbkuv mjhglku
            TaskDialogResult tdr = td.Show();
            if (TaskDialogResult.Cancel == tdr)
            {
                //Do not show the Revit dialog
                arg.OverrideResult(1);
            }
            else
            {
                //Continue to show the Revit dialog
                arg.OverrideResult(0);
            }
        }
    }
}
