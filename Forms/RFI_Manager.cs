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



namespace cbimtechTools.Forms
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public partial class RFI_Manager : Form
    {
        private List<DuAnOutput> Projects = new List<DuAnOutput>();
        private List<ClashOutput> Clashs = new List<ClashOutput>();
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
                Projects = new ProjectService().GetProjectList().ToList();
                cmbSelectProject.Items.AddRange(Projects.Where(s => s.ProjectState == "Ongoing" && s.TenDuAn != "BIM team").Select(s => s.TenDuAn).ToArray());
                lblStatus.Text = "Load thông tin từ server thành công";
                LoadMatrix(cmbMatrix1);
                LoadMatrix(cmbMatrix2);
                LoadPriority(cmbPriority);
            }
            catch (Exception ex)
            {
                cmbSelectProject.Items.Add("Không có dự án");
                lblStatus.Text = ex.Message;
            }
        }

        private void AddClashToTreeView(bool v)
        {
            if (v)
            {
                Clashs = new ClashService().GetClashList().Where(s => s.ProjectName == cmbSelectProject.Text).ToList();
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
            string pro = treeView_ClashList.SelectedNode.Parent.Text;
            try
            {
                ClashOutput itm = Clashs.Where(s => s.ProjectName == pro && s.IssueCode == treeView_ClashList.SelectedNode.Text).FirstOrDefault();
                ShowClash(itm);
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Không tìm thấy {treeView_ClashList.SelectedNode.Text} trong {pro} do {ex.Message}";

            }

        }

        private void ShowClash(ClashOutput itm)
        {
            try
            {
                lblProjectID.Text = itm.ProjectID;
                lblProjectName.Text = itm.ProjectName;
                issueCode.Text = itm.IssueCode;
                issueDate.Value = itm.IssueDate;
                cmbStatus.Text = itm.IssueStatus;
                Revision.Value = itm.Revision;

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void LoadPriority(ComboBox cmbPriority)
        {
            try
            {
                cmbPriority.Items.Add("EH");
                cmbPriority.Items.Add("H");
                cmbPriority.Items.Add("L");
                cmbPriority.Items.Add("N/A");
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }
        }

        private void LoadMatrix(ComboBox cmbMatrix1)
        {
            try
            {
                using (ClashService cs = new ClashService())
                {
                    cmbMatrix1.Items.AddRange(cs.GetClashMatrix().ToArray());
                }

            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }
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
            string pro = treeView_ClashList.SelectedNode.Parent.Text;
            try
            {

                ClashOutput itm = Clashs.Where(s => s.ProjectName == pro && s.IssueCode == treeView_ClashList.SelectedNode.Text).FirstOrDefault();
                ShowClash(itm);
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Không tìm thấy {treeView_ClashList.SelectedNode.Text} trong {pro} do {ex.Message}";

            }
        }
    }
}
