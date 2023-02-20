using EntitiesAbstraction.Entities;
using JRIEAssignment.Services;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace JRIEAssignment
{
    public partial class UserProfile : Form
    {
        public UserProfile()
        {
            InitializeComponent();
        }

        private void UserProfile_Load(object sender, EventArgs e)
        {
            LoadGridStructure();
        }

        private void LoadGridStructure()
        {

            var localSystemRepostory = ServicesRegistery.LocalSystemRepository;
            var branchRepostory = ServicesRegistery.BranchRepository;
            var userLevelCategoryRepository = ServicesRegistery.UserLevelCategoryRepository;

            var localSystemRepostoryData = localSystemRepostory.GetAll();
            var branchRepostoryData = branchRepostory.GetAll();
            var userLevelCategoryRepositoryData = userLevelCategoryRepository.GetAll();

            DataTable table = new DataTable();

            table.Columns.Add(new DataColumn("LocalSystemId", typeof(string)));
            table.Columns.Add(new DataColumn("LocalSystem", typeof(string)));
            foreach (var column in branchRepostoryData)
            {
                if (column.BranchName != null)
                    table.Columns.Add(new DataColumn(column.BranchName, typeof(bool)));
            }


            foreach (var row in localSystemRepostoryData)
            {
                if (row.LocalSystemName != null)
                {
                    var dataRow = table.NewRow();
                    dataRow[0] = row.LocalSystemId;
                    dataRow[1] = row.LocalSystemName;
                    table.Rows.Add(dataRow);

                    //DataGridViewComboBoxColumn dgvCmb = new DataGridViewComboBoxColumn();
                    //dataRow[5] = dgvCmb;
                }

            }

            dataGridView1.DataSource = table;

            DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
            comboBoxColumn.HeaderText = "Level Category";
            comboBoxColumn.Width = 100;
            comboBoxColumn.Name = "LevelCategory";
            dataGridView1.Columns.Add(comboBoxColumn);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var systemId = int.Parse(row.Cells[0].Value.ToString());                 

                DataGridViewComboBoxCell comboBoxCell = (row.Cells[6] as DataGridViewComboBoxCell);

                foreach (var userLevelCategory in userLevelCategoryRepositoryData.Where(x=>x.UserLevelCategoryLocalSystemId == systemId))
                {
                    comboBoxCell.Items.Add(userLevelCategory.UserLevelCategoryName==null?"": userLevelCategory.UserLevelCategoryName);
                }
            }
        }
    }
}
