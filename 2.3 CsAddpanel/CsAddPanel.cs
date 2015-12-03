using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.Windows.Media.Imaging;

namespace _2._3_AddPanel
{
    public class CsAddPanel:Autodesk.Revit.UI.IExternalApplication
    {

        public Autodesk.Revit.UI.Result OnShutdown(Autodesk.Revit.UI.UIControlledApplication application)
        {
            return Autodesk.Revit.UI.Result.Succeeded;
        }

        public Autodesk.Revit.UI.Result OnStartup(Autodesk.Revit.UI.UIControlledApplication application)
        {

            RibbonPanel ribbonPanel = application.CreateRibbonPanel("NewRibbonPanel");
            //PushButtonData pbd = new PushButtonData("name", "text", @"C:\Users\einst\Desktop\Danqing\GitRepo\RevitLab\2.2 HelloWorld\bin\Debug\2.2 HelloWorld.dll", "HelloWorld");
            PushButton pushBotton = ribbonPanel.AddItem(new PushButtonData("HelloWorld", "HelloWorld", @"C:\Users\einst\AppData\Roaming\Autodesk\Revit\Addins\2016\HelloWorld.dll", "_2._2_HelloWorld.HelloWorld")) as PushButton;
            
            Uri urlImage = new Uri(@"C:\Users\einst\Desktop\Danqing\UrlImage\01.jpg");
            BitmapImage largeImage = new BitmapImage(urlImage);
            pushBotton.LargeImage = largeImage;

            return Result.Succeeded;
        }
    }
}
