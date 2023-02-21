using EntitiesAbstraction.Entities;
using JRIEAssignment.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace JRIEAssignment
{
    public partial class UserProfileForm : Form
    {

        private IEnumerable<LocalSystem> localSystemRepostoryData;
        private IEnumerable<Branch> branchRepostoryData;
        private IEnumerable<UserLevelCategory> userLevelCategoryRepositoryData;
        private UserProfile currentUser;
        public UserProfileForm()
        {
            InitializeComponent();
        }

        private void UserProfile_Load(object sender, EventArgs e)
        {         
            InitialUsersList();
            
            CreateNewUser();
        }

        private void InitialUsersList()
        {
            lstUsers.Clear();
            var usersList = ServicesRegistery.UserProfileManager.GetAll();
            foreach (var user in usersList)
            { 
                ListViewItem userItem = new ListViewItem();
                userItem.Tag = user;
                userItem.Text = user.UserProfileName;
                lstUsers.Items.Add(userItem);
            }
        }

            private void InitialGridStructure()
        {
            
            var localSystemRepostory = ServicesRegistery.LocalSystemRepository;
            var branchRepostory = ServicesRegistery.BranchRepository;
            var userLevelCategoryRepository = ServicesRegistery.UserLevelCategoryRepository;

            localSystemRepostoryData = localSystemRepostory.GetAll();
            branchRepostoryData = branchRepostory.GetAll();
            userLevelCategoryRepositoryData = userLevelCategoryRepository.GetAll();

            dataGridView1.Columns.Clear();

            DataTable table = new DataTable();

            table.Columns.Add(new DataColumn("LocalSystemId", typeof(string)));
            table.Columns.Add(new DataColumn("LocalSystem", typeof(string)));

            foreach (var column in branchRepostoryData)
            {
                if (column.BranchCode != null)
                    table.Columns.Add(new DataColumn(column.BranchCode, typeof(bool)));
            }


            foreach (var row in localSystemRepostoryData)
            {
                if (row.LocalSystemName != null)
                {
                    var dataRow = table.NewRow();
                    dataRow[0] = row.LocalSystemId;
                    dataRow[1] = row.LocalSystemName;
                    table.Rows.Add(dataRow);
                }
            }

            dataGridView1.DataSource = table;

            DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
            comboBoxColumn.HeaderText = "Level Category";
            comboBoxColumn.Width = 200;
            comboBoxColumn.Name = "LevelCategory";
            dataGridView1.Columns.Add(comboBoxColumn);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var systemId = int.Parse((row.Cells[0].Value??-1).ToString());

                DataGridViewComboBoxCell comboBoxCell = (row.Cells[row.Cells.Count - 1] as DataGridViewComboBoxCell);

                foreach (var userLevelCategory in userLevelCategoryRepositoryData.Where(x => x.UserLevelCategoryLocalSystemId == systemId))
                {
                    if (userLevelCategory.UserLevelCategoryName == null)
                        userLevelCategory.UserLevelCategoryName = "";
                    
                    comboBoxCell.Items.Add(userLevelCategory.UserLevelCategoryName);
                }
            }

            dataGridView1.Columns[0].Visible= false;
        }

        private void LoadUserProfile(UserProfile userProfile)
        {
            lblID.Text = userProfile.UserProfileId==-1?"": userProfile.UserProfileId.ToString();
            txtEmail.Text = userProfile.UserProfileMailAddress;
            txtDomain.Text = userProfile.UserProfileDomainName;
            txtFullName.Text = userProfile.UserProfileAccount;
            chkAdmin.Checked = userProfile.UserProfileUserLevelToUserAdmin == "Y" ? true : false;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var systemId = int.Parse((row.Cells[0].Value ?? -1).ToString());

                DataGridViewComboBoxCell comboBoxCell = (row.Cells[row.Cells.Count - 1] as DataGridViewComboBoxCell);

                var userLevelCatagoryToSelect = from userLevelCategory in userLevelCategoryRepositoryData.Where(x => x.UserLevelCategoryLocalSystemId == systemId)
                                                join UserAccess in userProfile.UserAccessList
                                                on userLevelCategory.UserLevelCategoryId equals UserAccess.UserAccessUserLevelCategoryId
                                                select userLevelCategory.UserLevelCategoryName ?? "";

                if (userLevelCatagoryToSelect.Count() != 0)
                    comboBoxCell.Value = userLevelCatagoryToSelect.FirstOrDefault();

                var branchCodesToCheck = userProfile.LocalSystemBranchList.Where(x => x.LocalSystemBranchLocalSystemId == systemId);
                if (branchCodesToCheck.Count() != 0)
                {
                    foreach (var branchCode in branchCodesToCheck)
                    {                        
                        foreach (DataGridViewCell dataGridCell in row.Cells)
                        {
                            if (dataGridView1.Columns[dataGridCell.ColumnIndex].Name == branchCode.LocalSystemBranchCode)
                            {
                                row.Cells[dataGridCell.ColumnIndex].Value = true;
                            }
                        }
                    }

                }
            }
        }

        private void CreateNewUser()
        {            
            currentUser = ServicesRegistery.UserProfileManager.GetNewUser();
            InitialGridStructure();
            LoadUserProfile(currentUser);
            btnSaveUpdate.Text = "Save";
            btnDelete.Visible = false;
        }
        private void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {            
        }

        private void lstUsers_BeforeLabelEdit(object sender, LabelEditEventArgs e)
        {

        }

        private void lstUsers_Click(object sender, EventArgs e)
        {
            currentUser = ServicesRegistery.UserProfileManager.Get(((UserProfile)lstUsers.SelectedItems[0].Tag).UserProfileId);
            btnSaveUpdate.Text = "Update";
            btnDelete.Visible = true;
            InitialGridStructure();
            LoadUserProfile(currentUser);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateNewUser();
        }

        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            if (currentUser.UserProfileId == -1)
                ServicesRegistery.UserProfileManager.Insert(currentUser);
            else
                ServicesRegistery.UserProfileManager.Update(currentUser);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ServicesRegistery.UserProfileManager.Delete(currentUser);
        }

        private void chkAdmin_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Visible= chkAdmin.Checked;
        }
    }
}
