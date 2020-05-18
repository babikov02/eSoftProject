using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSoftProject
{
    public partial class FormSupply : Form
    {
        public FormSupply()
        {
            InitializeComponent();
            ShowClients();
            ShowAgents();
            ShowRealEstate();
            ShowSupplySet();
        }

       
        private void FormSupply_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxAgents_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        void ShowSupplySet()
        {
            listViewSupplySet.Items.Clear();
            foreach (SupplySet supply in Program.wftDb.SupplySet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    supply.IdAgent.ToString(),
                    supply.AgentSet.LastName + " " + supply.AgentSet.FirstName + " " + supply.AgentSet.MiddleName,
                    supply.IdClient.ToString(),
                    supply.ClientSet.LastName + " " + supply.ClientSet.FirstName + " " + supply.ClientSet.MiddleName,
                    supply.IdRealEstate.ToString(),
                    "г. " + supply.RealEstateSet.Address_City + ", ул. " + supply.RealEstateSet.Address_Street + ", д. " +
                    supply.RealEstateSet.Address_House + ", кв. " + supply.RealEstateSet.Address_Number,
                    supply.Price.ToString()
                });
                item.Tag = supply;
                listViewSupplySet.Items.Add(item);
            }
        }

        void ShowAgents()
        {
            comboBoxAgents.Items.Clear();
            foreach (AgentSet agentSet in Program.wftDb.AgentSet)
            {
                string[] item = {agentSet.Id.ToString() + ".", agentSet.FirstName, agentSet.MiddleName,
                agentSet.LastName};
                comboBoxAgents.Items.Add(string.Join(" ", item));
            }
        }

        private void comboBoxClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        void ShowClients()
        {
            comboBoxClients.Items.Clear();
            foreach (ClientSet clientSet in Program.wftDb.ClientSet)
            {
                string[] item = {clientSet.Id.ToString() + ".", clientSet.FirstName, clientSet.MiddleName,
                clientSet.LastName};
                comboBoxClients.Items.Add(string.Join(" ", item));
            }
        }

        private void comboBoxRealEstate_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        void ShowRealEstate()
        {
            comboBoxRealEstate.Items.Clear();
            foreach (RealEstateSet realEstateSet in Program.wftDb.RealEstateSet)
            {
                string[] item = { realEstateSet.Id.ToString()+".", realEstateSet.Address_City + ",", realEstateSet.Address_Street + ",",
                    "д. " + realEstateSet.Address_House + ",", "кв." + realEstateSet.Address_Number};
                comboBoxRealEstate.Items.Add(string.Join(" ", item));
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxAgents.SelectedItem != null && comboBoxClients.SelectedItem != null && comboBoxRealEstate != null && textBoxPrice.Text != "")
            {
                SupplySet supply = new SupplySet();
                supply.IdAgent = Convert.ToInt32(comboBoxAgents.SelectedItem.ToString().Split('.')[0]);
                supply.IdClient = Convert.ToInt32(comboBoxClients.SelectedItem.ToString().Split('.')[0]);
                supply.IdRealEstate = Convert.ToInt32(comboBoxRealEstate.SelectedItem.ToString().Split('.')[0]);
                supply.Price = Convert.ToInt64(textBoxPrice.Text);
                Program.wftDb.SupplySet.Add(supply);
                Program.wftDb.SaveChanges();
                ShowSupplySet();
            }
            else MessageBox.Show("Данные не выбраны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewSupplySet.SelectedItems.Count == 1)
            {
                SupplySet supply = listViewSupplySet.SelectedItems[0].Tag as SupplySet;
                supply.IdAgent = Convert.ToInt32(comboBoxAgents.SelectedItem.ToString().Split('.')[0]);
                supply.IdClient = Convert.ToInt32(comboBoxClients.SelectedItem.ToString().Split('.')[0]);
                supply.IdRealEstate = Convert.ToInt32(comboBoxRealEstate.SelectedItem.ToString().Split('.')[0]);
                supply.Price = Convert.ToInt64(textBoxPrice.Text);

                Program.wftDb.SaveChanges();
                ShowSupplySet();
            }
        }

        private void listViewSupplySet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewSupplySet.SelectedItems.Count == 1)
            {
                SupplySet supply = listViewSupplySet.SelectedItems[0].Tag as SupplySet;
                comboBoxAgents.SelectedIndex = comboBoxAgents.FindString(supply.IdAgent.ToString());
                comboBoxClients.SelectedIndex = comboBoxClients.FindString(supply.IdClient.ToString());
                comboBoxRealEstate.SelectedIndex = comboBoxRealEstate.FindString(supply.IdRealEstate.ToString());
                textBoxPrice.Text = supply.Price.ToString();
            }
             else
            {
                comboBoxAgents.SelectedItem = null;
                comboBoxClients.SelectedItem = null;
                comboBoxRealEstate.SelectedItem = null;
                textBoxPrice.Text = "";
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewSupplySet.SelectedItems.Count == 1)
                {
                    SupplySet supply = listViewSupplySet.SelectedItems[0].Tag as SupplySet;
                    Program.wftDb.SupplySet.Remove(supply);
                    Program.wftDb.SaveChanges();
                    ShowSupplySet();
                }
                comboBoxAgents.SelectedItem = null;
                comboBoxClients.SelectedItem = null;
                comboBoxRealEstate.SelectedItem = null;
                textBoxPrice.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись уже используется", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }
    }
}
