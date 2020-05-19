﻿using System;
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
    public partial class FormDemandSet : Form
    {
        public FormDemandSet()
        {
            InitializeComponent();
            comboBoxType.SelectedIndex = 0;
            ShowAgent();
            ShowClient();
            ShowDemandSet();
        }
        void ShowDemandSet()
        {
            listViewDemandSet_Apartment.Items.Clear();
            listViewDemandSet_House.Items.Clear();
            listViewDemandSet_Land.Items.Clear();
            foreach (DemandSet demand in Program.wftDb.DemandSet)
            {
                if (demand.Type == 0)
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                        demand.IdAgent.ToString(),
                        demand.AgentSet.LastName + " " + demand.AgentSet.FirstName + " " + demand.AgentSet.MiddleName,
                        demand.IdClient.ToString(),
                        demand.ClientSet.LastName + " " + demand.ClientSet.FirstName + " " + demand.ClientSet.MiddleName,
                        demand.MinPrice.ToString(),
                        demand.MaxPrice.ToString(),
                        demand.MinArea.ToString(),
                        demand.MaxArea.ToString(),
                        demand.MinFloor.ToString(),
                        demand.MaxFloor.ToString(),
                        demand.MinRooms.ToString(),
                        demand.MaxRooms.ToString()
                        
                    });
                    item.Tag = demand;
                    listViewDemandSet_Apartment.Items.Add(item);
                }
                else if (demand.Type == 1)
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                        demand.IdAgent.ToString(),
                        demand.AgentSet.LastName + " " + demand.AgentSet.FirstName + " " + demand.AgentSet.MiddleName,
                        demand.IdClient.ToString(),
                        demand.ClientSet.LastName + " " + demand.ClientSet.FirstName + " " + demand.ClientSet.MiddleName,
                        demand.MinPrice.ToString(),
                        demand.MaxPrice.ToString(),
                        demand.MinArea.ToString(),
                        demand.MaxArea.ToString(),
                        demand.MinFloors.ToString(),
                        demand.MaxFloors.ToString()
                    });
                    item.Tag = demand;
                    listViewDemandSet_House.Items.Add(item);
                }
                else 
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                        demand.IdAgent.ToString(),
                        demand.AgentSet.LastName + " " + demand.AgentSet.FirstName + " " + demand.AgentSet.MiddleName,
                        demand.IdClient.ToString(),
                        demand.ClientSet.LastName + " " + demand.ClientSet.FirstName + " " + demand.ClientSet.MiddleName,
                        demand.MinPrice.ToString(),
                        demand.MaxPrice.ToString(),
                        demand.MinArea.ToString(),                        
                        demand.MaxArea.ToString()                     
                    });
                    item.Tag = demand;
                    listViewDemandSet_Land.Items.Add(item);
                }
            }
        }
        void ShowAgent()
        {
            comboBoxAgent.Items.Clear();
            foreach (AgentSet agentSet in Program.wftDb.AgentSet)
            {
                string[] item = {agentSet.Id.ToString() + ".", agentSet.FirstName, agentSet.MiddleName,
                agentSet.LastName};
                comboBoxAgent.Items.Add(string.Join(" ", item));
            }
        }
        void ShowClient()
        {
            comboBoxClient.Items.Clear();
            foreach (ClientSet clientSet in Program.wftDb.ClientSet)
            {
                string[] item = {clientSet.Id.ToString() + ".", clientSet.FirstName, clientSet.MiddleName,
                clientSet.LastName};
                comboBoxClient.Items.Add(string.Join(" ", item));
            }
        }

        

        private void FormDemand_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void listViewDemandSet_House_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDemandSet_House.SelectedItems.Count == 1)
            {
                DemandSet demand = listViewDemandSet_House.SelectedItems[0].Tag as DemandSet;

                textBoxMinArea.Text = demand.MinArea.ToString();
                textBoxMaxArea.Text = demand.MaxArea.ToString();
                textBoxMinPrice.Text = demand.MinPrice.ToString();
                textBoxMaxPrice.Text = demand.MaxPrice.ToString();
                textBoxMinFloors.Text = demand.MinFloors.ToString();
                textBoxMaxFloors.Text = demand.MaxFloors.ToString();
            }
            else
            {
                textBoxMinArea.Text = "";
                textBoxMaxArea.Text = "";
                textBoxMinPrice.Text = "";
                textBoxMaxPrice.Text = "";
                textBoxMinFloors.Text = "";
                textBoxMaxFloors.Text = "";
            }
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedIndex == 0)
            {
                listViewDemandSet_Apartment.Visible = true;
                labelAgent.Visible = true;
                comboBoxAgent.Visible = true;
                labelClient.Visible = true;
                comboBoxClient.Visible = true;
                labelMinFloor.Visible = true;
                textBoxMinFloor.Visible = true;
                labelMaxFloor.Visible = true;
                textBoxMaxFloor.Visible = true;
                labelMinArea.Visible = true;
                textBoxMinArea.Visible = true;
                labelMaxArea.Visible = true;
                textBoxMaxArea.Visible = true;
                labelMinRooms.Visible = true;
                textBoxMinRooms.Visible = true;
                labelMaxRooms.Visible = true;
                textBoxMaxRooms.Visible = true;
                labelMinPrice.Visible = true;
                textBoxMinPrice.Visible = true;
                labelMaxPrice.Visible = true;
                textBoxMaxPrice.Visible = true;

                listViewDemandSet_House.Visible = false;
                listViewDemandSet_Land.Visible = false;
                labelMinFloors.Visible = false;
                textBoxMinFloors.Visible = false;
                labelMaxFloors.Visible = false;
                textBoxMaxFloors.Visible = false;

                textBoxMinFloor.Text = "";
                textBoxMaxFloor.Text = "";
                textBoxMinArea.Text = "";
                textBoxMaxArea.Text = "";
                textBoxMinRooms.Text = "";
                textBoxMaxRooms.Text = "";
                textBoxMinPrice.Text = "";
                textBoxMaxPrice.Text = "";
            }
            else if (comboBoxType.SelectedIndex == 1)
            {
                listViewDemandSet_House.Visible = true;
                labelAgent.Visible = true;
                comboBoxAgent.Visible = true;
                labelClient.Visible = true;
                comboBoxClient.Visible = true;
                labelMinArea.Visible = true;
                textBoxMinArea.Visible = true;
                labelMaxArea.Visible = true;
                textBoxMaxArea.Visible = true;
                labelMinPrice.Visible = true;
                textBoxMinPrice.Visible = true;
                labelMaxPrice.Visible = true;
                textBoxMaxPrice.Visible = true;
                labelMinFloors.Visible = true;
                textBoxMinFloors.Visible = true;
                labelMaxFloors.Visible = true;
                textBoxMaxFloors.Visible = true;

                listViewDemandSet_Land.Visible = false;
                listViewDemandSet_Apartment.Visible = false;
                labelMinFloor.Visible = false;
                textBoxMinFloor.Visible = false;
                labelMaxFloor.Visible = false;
                textBoxMaxFloor.Visible = false;
                labelMinRooms.Visible = false;
                textBoxMinRooms.Visible = false;
                labelMaxRooms.Visible = false;
                textBoxMaxRooms.Visible = false;

                textBoxMinFloors.Text = "";
                textBoxMaxFloors.Text = "";
                textBoxMinArea.Text = "";
                textBoxMaxArea.Text = "";
                textBoxMinPrice.Text = "";
                textBoxMaxPrice.Text = "";
            }
            else if (comboBoxType.SelectedIndex == 2)
            {
                listViewDemandSet_Land.Visible = true;
                labelAgent.Visible = true;
                comboBoxAgent.Visible = true;
                labelClient.Visible = true;
                comboBoxClient.Visible = true;
                labelMinFloor.Visible = true;
                labelMinArea.Visible = true;
                textBoxMinArea.Visible = true;
                labelMaxArea.Visible = true;
                textBoxMaxArea.Visible = true;
                labelMinPrice.Visible = true;
                textBoxMinPrice.Visible = true;
                labelMaxPrice.Visible = true;
                textBoxMaxPrice.Visible = true;

                listViewDemandSet_Apartment.Visible = false;
                listViewDemandSet_House.Visible = false;
                labelMinFloors.Visible = false;
                textBoxMinFloors.Visible = false;
                labelMaxFloors.Visible = false;
                textBoxMaxFloors.Visible = false;
                labelMinFloor.Visible = false;
                textBoxMinFloor.Visible = false;
                labelMaxFloor.Visible = false;
                textBoxMaxFloor.Visible = false;
                labelMinRooms.Visible = false;
                textBoxMinRooms.Visible = false;
                labelMaxRooms.Visible = false;
                textBoxMaxRooms.Visible = false;

                textBoxMinArea.Text = "";
                textBoxMaxArea.Text = "";
                textBoxMinPrice.Text = "";
                textBoxMaxPrice.Text = "";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            DemandSet demand = new DemandSet();
            demand.IdAgent = Convert.ToInt32(comboBoxAgent.SelectedItem.ToString().Split('.')[0]);
            demand.IdClient = Convert.ToInt32(comboBoxClient.SelectedItem.ToString().Split('.')[0]);
            demand.MinArea = Convert.ToDouble(textBoxMinArea.Text);
            demand.MaxArea = Convert.ToDouble(textBoxMaxArea.Text);
            demand.MinPrice = Convert.ToInt64(textBoxMinPrice.Text);
            demand.MaxPrice = Convert.ToInt64(textBoxMaxPrice.Text);
            

            if (comboBoxType.SelectedIndex == 0)
            {
                demand.Type = 0;
                demand.MinRooms = Convert.ToInt32(textBoxMinRooms.Text);
                demand.MaxRooms = Convert.ToInt32(textBoxMaxRooms.Text);
                demand.MinFloor = Convert.ToInt32(textBoxMinFloor.Text);
                demand.MaxFloor = Convert.ToInt32(textBoxMaxFloor.Text);
            }
            else if (comboBoxType.SelectedIndex == 1)
            {
                demand.Type = 1;
                demand.MinFloors = Convert.ToInt32(textBoxMinFloors.Text);
                demand.MaxFloors = Convert.ToInt32(textBoxMaxFloors.Text);
            }
            else
            {
                demand.Type = 2;
            }
            Program.wftDb.DemandSet.Add(demand);
            Program.wftDb.SaveChanges();
            ShowDemandSet();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedIndex == 0)
            {
                if (listViewDemandSet_Apartment.SelectedItems.Count == 1)
                {
                    DemandSet demand = listViewDemandSet_Apartment.SelectedItems[0].Tag as DemandSet;

                    demand.IdAgent = Convert.ToInt32(comboBoxAgent.SelectedItem.ToString().Split('.')[0]);
                    demand.IdClient = Convert.ToInt32(comboBoxClient.SelectedItem.ToString().Split('.')[0]);
                    demand.MinArea = Convert.ToDouble(textBoxMinArea.Text);
                    demand.MaxArea = Convert.ToDouble(textBoxMaxArea.Text);
                    demand.MinPrice = Convert.ToInt64(textBoxMinPrice.Text);
                    demand.MaxPrice = Convert.ToInt64(textBoxMaxPrice.Text);
                    demand.MinRooms = Convert.ToInt32(textBoxMinRooms.Text);
                    demand.MaxRooms = Convert.ToInt32(textBoxMaxRooms.Text);
                    demand.MinFloor = Convert.ToInt32(textBoxMinFloor.Text);
                    demand.MaxFloor = Convert.ToInt32(textBoxMaxFloor.Text);

                    Program.wftDb.SaveChanges();
                    ShowDemandSet();
                }
            }
            else if (comboBoxType.SelectedIndex == 1)
            {
                if (listViewDemandSet_House.SelectedItems.Count == 1)
                {
                    DemandSet demand = listViewDemandSet_House.SelectedItems[0].Tag as DemandSet;

                    demand.IdAgent = Convert.ToInt32(comboBoxAgent.SelectedItem.ToString().Split('.')[0]);
                    demand.IdClient = Convert.ToInt32(comboBoxClient.SelectedItem.ToString().Split('.')[0]);
                    demand.MinArea = Convert.ToDouble(textBoxMinArea.Text);
                    demand.MaxArea = Convert.ToDouble(textBoxMaxArea.Text);
                    demand.MinPrice = Convert.ToInt64(textBoxMinPrice.Text);
                    demand.MaxPrice = Convert.ToInt64(textBoxMaxPrice.Text);
                    demand.MinFloors = Convert.ToInt32(textBoxMinFloors.Text);
                    demand.MaxFloors = Convert.ToInt32(textBoxMaxFloors.Text);

                    Program.wftDb.SaveChanges();
                    ShowDemandSet();
                }
            }
            else
            {
                if (listViewDemandSet_Land.SelectedItems.Count == 1)
                {
                    DemandSet demand = listViewDemandSet_Land.SelectedItems[0].Tag as DemandSet;

                    comboBoxAgent.SelectedIndex = comboBoxAgent.FindString(demand.IdAgent.ToString());
                    comboBoxClient.SelectedIndex = comboBoxClient.FindString(demand.IdClient.ToString());
                    demand.IdAgent = Convert.ToInt32(comboBoxAgent.SelectedItem.ToString().Split('.')[0]);
                    demand.IdClient = Convert.ToInt32(comboBoxClient.SelectedItem.ToString().Split('.')[0]);
                    demand.MinArea = Convert.ToDouble(textBoxMinArea.Text);
                    demand.MaxArea = Convert.ToDouble(textBoxMaxArea.Text);
                    demand.MinPrice = Convert.ToInt64(textBoxMinPrice.Text);
                    demand.MaxPrice = Convert.ToInt64(textBoxMaxPrice.Text);

                    Program.wftDb.SaveChanges();
                    ShowDemandSet();
                }
            }
        }

        private void listViewDemandSet_Apartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDemandSet_Apartment.SelectedItems.Count == 1)
            {
                DemandSet demand = listViewDemandSet_Apartment.SelectedItems[0].Tag as DemandSet;

                comboBoxAgent.SelectedIndex = comboBoxAgent.FindString(demand.IdAgent.ToString());
                comboBoxClient.SelectedIndex = comboBoxClient.FindString(demand.IdClient.ToString());
                textBoxMinArea.Text = demand.MinArea.ToString();
                textBoxMaxArea.Text = demand.MaxArea.ToString();
                textBoxMinPrice.Text = demand.MinPrice.ToString();
                textBoxMaxPrice.Text = demand.MaxPrice.ToString();
                textBoxMinRooms.Text = demand.MinRooms.ToString();
                textBoxMaxRooms.Text = demand.MaxRooms.ToString();
                textBoxMinFloor.Text = demand.MinFloor.ToString();
                textBoxMaxFloor.Text = demand.MaxFloor.ToString();
            }
            else
            {
                textBoxMinArea.Text = "";
                textBoxMaxArea.Text = "";
                textBoxMinPrice.Text = "";
                textBoxMaxPrice.Text = "";
                textBoxMinRooms.Text = "";
                textBoxMaxRooms.Text = "";
                textBoxMinFloor.Text = "";
                textBoxMaxFloor.Text = "";
            }
        }

        private void listViewDemandSet_Land_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDemandSet_Land.SelectedItems.Count == 1)
            {
                DemandSet demand = listViewDemandSet_Land.SelectedItems[0].Tag as DemandSet;

                comboBoxAgent.SelectedIndex = comboBoxAgent.FindString(demand.IdAgent.ToString());
                comboBoxClient.SelectedIndex = comboBoxClient.FindString(demand.IdClient.ToString());
                textBoxMinArea.Text = demand.MinArea.ToString();
                textBoxMaxArea.Text = demand.MaxArea.ToString();
                textBoxMinPrice.Text = demand.MinPrice.ToString();
                textBoxMaxPrice.Text = demand.MaxPrice.ToString();
            }
            else
            {
                textBoxMinArea.Text = "";
                textBoxMaxArea.Text = "";
                textBoxMinPrice.Text = "";
                textBoxMaxPrice.Text = "";
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxType.SelectedIndex == 0)
                {
                    if (listViewDemandSet_Apartment.SelectedItems.Count == 1)
                    {
                        DemandSet demand = listViewDemandSet_Apartment.SelectedItems[0].Tag as DemandSet;
                        Program.wftDb.DemandSet.Remove(demand);
                        Program.wftDb.SaveChanges();
                        ShowDemandSet();
                    }
                    textBoxMinArea.Text = "";
                    textBoxMaxArea.Text = "";
                    textBoxMinPrice.Text = "";
                    textBoxMaxPrice.Text = "";
                    textBoxMinRooms.Text = "";
                    textBoxMaxRooms.Text = "";
                    textBoxMinFloor.Text = "";
                    textBoxMaxFloor.Text = "";

                }
                else if (comboBoxType.SelectedIndex == 1)
                {
                    if (listViewDemandSet_House.SelectedItems.Count == 1)
                    {
                        DemandSet demand = listViewDemandSet_House.SelectedItems[0].Tag as DemandSet;
                        Program.wftDb.DemandSet.Remove(demand);
                        Program.wftDb.SaveChanges();
                        ShowDemandSet();
                    }
                    textBoxMinArea.Text = "";
                    textBoxMaxArea.Text = "";
                    textBoxMinPrice.Text = "";
                    textBoxMaxPrice.Text = "";
                    textBoxMinFloors.Text = "";
                    textBoxMaxFloors.Text = "";
                }
                else
                {
                    if (listViewDemandSet_Land.SelectedItems.Count == 1)
                    {
                        DemandSet demand = listViewDemandSet_Land.SelectedItems[0].Tag as DemandSet;
                        Program.wftDb.DemandSet.Remove(demand);
                        Program.wftDb.SaveChanges();
                        ShowDemandSet();
                    }
                    textBoxMinArea.Text = "";
                    textBoxMaxArea.Text = "";
                    textBoxMinPrice.Text = "";
                    textBoxMaxPrice.Text = "";
                }

            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись уже используется", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBoxMinArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }

        private void textBoxMaxArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }

        private void textBoxMinPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 )
            {
                e.Handled = true;
            }
        }

        private void textBoxMaxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBoxMinRooms_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBoxMaxRooms_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBoxMaxFloors_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBoxMaxFloor_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBoxMinFloors_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBoxMinFloor_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBoxMinFloors_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
