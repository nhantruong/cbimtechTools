using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;

namespace cbimtechTools
{
    class cbimtechFunctionRegister : IExternalApplication
    {
        public RibbonTabs ribbonTabs = new RibbonTabs();
        public Result OnShutdown(UIControlledApplication application)
        {
            TaskDialog.Show("cbimtech", "Thanks for comming!");
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            try
            {
                ribbonTabs.Init(application);
                TaskDialog.Show("cbimtech", "Welcome to Coteccons BIM team!");
                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                TaskDialog.Show("cbimtech", ex.Message);
                return Result.Failed;
            }
        }
    }
}
