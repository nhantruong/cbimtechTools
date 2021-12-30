using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cbimtechTools.Forms;

namespace cbimtechTools
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    class RFImanage : IExternalCommand
    {
        public Result Execute(ExternalCommandData revit, ref string message, ElementSet elements)
        {
            //TaskDialog.Show("RFImanage", "Test first command!!!!!!!!!!!!!!!!!!!!");
            RFI_Manager rfI_Manager = new RFI_Manager();
            rfI_Manager.Show();
            return Result.Succeeded;
        }


    }
}
