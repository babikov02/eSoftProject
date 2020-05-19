using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSoftProject
{
    public partial class FormAgentSet : Form
    {
        public FormAgentSet()
        {
            InitializeComponent();
            ShowAgent();
        }

        void ShowAgent()
        {
            listViewAgentSet.Items.Clear();
            foreach (AgentSet agentSet in Program.wftDb.AgentSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                        agentSet.FirstName, agentSet.LastName, agentSet.MiddleName, agentSet.DealShare.ToString()
                });

                item.Tag = agentSet;

                listViewAgentSet.Items.Add(item);
            }
            listViewAgentSet.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void FormAgentSet_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AgentSet agentSet = new AgentSet();
            agentSet.FirstName = textBoxFirstName.Text;
            agentSet.LastName = textBoxLastName.Text;
            agentSet.MiddleName = textBoxMiddleName.Text;
            agentSet.DealShare = Convert.ToDouble(textBoxShare.Text);
            Program.wftDb.AgentSet.Add(agentSet);
            Program.wftDb.SaveChanges();
            ShowAgent();

        }

        private void textBoxShare_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewAgentSet.SelectedItems.Count == 1)
            {
                AgentSet agentSet = listViewAgentSet.SelectedItems[0].Tag as AgentSet;
                agentSet.FirstName = textBoxFirstName.Text;
                agentSet.LastName = textBoxLastName.Text;
                agentSet.MiddleName = textBoxMiddleName.Text;
                agentSet.DealShare = Convert.ToDouble(textBoxShare.Text);
                Program.wftDb.SaveChanges();
                ShowAgent();
            }
        }

        private void listViewAgentSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewAgentSet.SelectedItems.Count == 1)
            {
                AgentSet agentSet = listViewAgentSet.SelectedItems[0].Tag as AgentSet;
                textBoxFirstName.Text = agentSet.FirstName;
                textBoxLastName.Text = agentSet.LastName;
                textBoxMiddleName.Text = agentSet.MiddleName;
                textBoxShare.Text = agentSet.DealShare.ToString();
            }
            else
            {
                textBoxFirstName.Text = "";
                textBoxLastName.Text = "";
                textBoxMiddleName.Text = "";
                textBoxShare.Text = "";
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewAgentSet.SelectedItems.Count == 1)
                {
                    AgentSet agentSet = listViewAgentSet.SelectedItems[0].Tag as AgentSet;
                    Program.wftDb.AgentSet.Remove(agentSet);
                    Program.wftDb.SaveChanges();
                    ShowAgent();
                }
                textBoxFirstName.Text = "";
                textBoxLastName.Text = "";
                textBoxMiddleName.Text = "";
                textBoxShare.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBoxShare_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
