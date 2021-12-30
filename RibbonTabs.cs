using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace cbimtechTools
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class RibbonTabs : IExternalApplication
    {
        //public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        //{
        //    UIApplication uiapp = commandData.Application;
        //    Document doc = uiapp.ActiveUIDocument.Document;

        //    return Result.Succeeded;
        //}
        public void Init(UIControlledApplication application)
        {
            this.ThemRibbonBar(application);
        }

        private void ThemRibbonBar(UIControlledApplication application)
        {
            string TenRibbon = "cbimtech";
            application.CreateRibbonTab(TenRibbon);
            string myAppLoc = System.Reflection.Assembly.GetExecutingAssembly().Location;

            RibbonPanel qaqc = application.CreateRibbonPanel(TenRibbon, "QA/QC");

            PushButtonData clashBtnData = new PushButtonData("RFI","RFi report", myAppLoc, "cbimtechTools.RFImanage");
            PushButton rfibtn = qaqc.AddItem(clashBtnData) as PushButton;         
            rfibtn.LargeImage = new BitmapImage(new Uri("C:\\Users\\truon\\OneDrive\\MyApp\\CTC\\cbimtechTools\\Resources\\RFIimage.jpg"));
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            ThemRibbonBar(application);
            return Result.Succeeded;
        }
    }
}
