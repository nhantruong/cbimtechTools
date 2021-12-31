using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cbimtechTools.Models;
using cbimtechTools.com.cbimtech.GetProjectServices;
using cbimtechTools.com.cbimtech.GetClashList;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace cbimtechTools.Forms
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public partial class RFI_Manager : System.Windows.Forms.Form
    {
        private List<DuAnOutput> Projects = new List<DuAnOutput>();
        private List<ClashDetailOutput> Clashs = new List<ClashDetailOutput>();

        //public static ExternalCommandData commandData;
        /// <summary>
        /// External Command Data lấy từ RFImanage qua
        /// </summary>
        internal ExternalCommandData commandData;

        public Document doc { get; internal set; }

        public RFI_Manager()
        {
            InitializeComponent();
            cmbSelectProject.Enabled = true;
            treeView_ClashList.NodeMouseClick += TreeView_ClashList_NodeMouseClick;
            //LoadLevelandGrid();
        }

        private void TreeView_ClashList_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                rfiRightClickAction.Show(treeView_ClashList, e.Location);
            }
        }


        private void RFI_Manager_Load(object sender, EventArgs e)
        {
            try
            {
                //commandData = new ExternalCommandData();
                ////Revit
                //UIApplication uiapp = commandData.Application;
                //Document doc = uiapp.ActiveUIDocument.Document;

                //cbimtech
                Projects = new ProjectService().GetProjectList().ToList();
                cmbSelectProject.Items.AddRange(Projects.Where(s => s.ProjectState == "Ongoing" && s.TenDuAn != "BIM team").Select(s => s.TenDuAn).ToArray());
                lblStatus.Text = "Load thông tin từ server thành công";

                using (ClashService cs = new ClashService())
                {
                    var itm = cs.GetClashMatrixDefault();
                    cmbMatrix1.Items.AddRange(itm);
                    cmbMatrix2.Items.AddRange(itm);

                    cmbErrorType.Items.AddRange(cs.GetClashErrorType());
                    cmbStatus.Items.AddRange(cs.GetClashStatus());
                }
                cmbPriority.Items.AddRange((object[])LoadPriority());

                //NỘi dung bên trong MÔ hình
                cmbLevel.Items.AddRange(GetLevels());
            }
            catch (Exception ex)
            {
                cmbSelectProject.Items.Add("Không có dự án");
                lblStatus.Text = $"Có lỗi do {ex.Message}";
            }
        }

        private string[] GetLevels()
        {
            // Use ElementLevel filter to find elements by their associated level in the document
            string[] levelItem;
            // Find the level whose Name is "Level 1"
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            ICollection<Element> collection = collector.OfClass(typeof(Level)).ToElements();
            if (collection.Count() == 0) return null;
            levelItem = new string[collection.Count()];
            for (int i = 0; i < collection.Count(); i++)
            {
                Level level = collection.ToArray()[i] as Level;
                levelItem[i] = level.Name;
            }
            return levelItem;
        }

        private void AddClashToTreeView(bool v)
        {
            if (v)
            {
                Clashs = new ClashService().GetClashDetailList().Where(s => s.ProjectName == cmbSelectProject.Text).ToList();
                TreeNode root = new TreeNode($"{cmbSelectProject.Text}")
                {
                    NodeFont = new Font(treeView_ClashList.Font, FontStyle.Bold)
                };
                treeView_ClashList.Nodes.Add(root);
                ProgressBar.Maximum = Clashs.Count();
                ProgressBar.Value = 0;
                foreach (string item in Clashs.OrderByDescending(s => s.ID).Select(s => s.IssueCode))
                {
                    TreeNode rfiCode = new TreeNode(item)
                    {
                        NodeFont = new Font(treeView_ClashList.Font, FontStyle.Bold)
                    };
                    root.Nodes.Add(rfiCode);
                    ProgressBar.Value++;
                }
                treeView_ClashList.ShowRootLines = true;
                treeView_ClashList.ExpandAll();
                lblStatus.Text = $"Load thông tin Clash của dự án {cmbSelectProject.Text} thành công ";
                Task.Delay(9000);
                lblStatus.Text = "Ready";
            }

        }

        private void cmbSelectProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            treeView_ClashList.Nodes.Clear();
            if (MessageBox.Show("Bạn sẽ làm RFI cho dự án này chứ?", "Choose Project", MessageBoxButtons.OKCancel, MessageBoxIcon.Question).Equals(DialogResult.OK))
            {
                AddClashToTreeView(true);
            }
            else
            {
                // cmbSelectProject.Enabled = true;
            }
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //_ = MessageBox.Show($"View detail {treeView_ClashList.SelectedNode.Text}", "Details");
            if (treeView_ClashList.SelectedNode.Level != 0) return;
            string pro = treeView_ClashList.SelectedNode.Parent.Text;
            try
            {
                ClashDetailOutput itm = Clashs.Where(s => s.ProjectName == pro && s.IssueCode == treeView_ClashList.SelectedNode.Text).FirstOrDefault();
                ShowClash(itm);
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Không tìm thấy {treeView_ClashList.SelectedNode.Text} trong {pro} do {ex.Message}";

            }

        }

        private void ShowClash(ClashDetailOutput itm)
        {
            try
            {
                lblProjectID.Text = itm.ProjectID;
                lblProjectName.Text = itm.ProjectName;
                issueCode.Text = itm.IssueCode;
                issueDate.Value = itm.IssueDate;
                issueDate.Format = DateTimePickerFormat.Short;
                cmbStatus.Text = itm.IssueStatus;
                Revision.Value = itm.Revision;
                txtFrom.Text = itm.From;
                txtIssueDescription.Text = itm.IssueDescription;
                cmbMatrix1.Text = itm.Matrix1;
                cmbMatrix2.Text = itm.Matrix2;
                //cmbPriority.Text = itm.Priority;
                cmbErrorType.Text = itm.ErrorType;

            }
            catch (Exception)
            {

                throw;
            }
        }

        private Array LoadPriority()
        {
            string[] item = new string[4];
            item[0] = "EH";
            item[1] = "H";
            item[2] = "L";
            item[3] = "N/A";
            return item;
        }



        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Change status to 'Open' of: {treeView_ClashList.SelectedNode.Text}", "Change status");
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Change status to 'Close' of:{treeView_ClashList.SelectedNode.Text}", "Change status");
        }

        private void editContentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Edit contain detail {treeView_ClashList.SelectedNode.Text}", "Edit Details");
        }

        private void archiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Archive {treeView_ClashList.SelectedNode.Text} ?", "Archive RFI");
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Delete {treeView_ClashList.SelectedNode.Text}?", "Delete RFI");
        }

        private void treeView_ClashList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (treeView_ClashList.SelectedNode.Level != 0) return;
            string pro = treeView_ClashList.SelectedNode.Parent.Text;
            try
            {

                ClashDetailOutput itm = Clashs.Where(s => s.ProjectName == pro && s.IssueCode == treeView_ClashList.SelectedNode.Text).FirstOrDefault();
                ShowClash(itm);
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Không tìm thấy {treeView_ClashList.SelectedNode.Text} trong {pro} do {ex.Message}";

            }

        }
    }
}
