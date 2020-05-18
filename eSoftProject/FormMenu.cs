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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form formDemandSet = new FormDemandSet();
            formDemandSet.Show();
        }

        private void buttonOpenClients_Click(object sender, EventArgs e)
        {
            
            Form formClient = new FormClient();
            formClient.Show();
        }

        private void buttonOpenRealEstates_Click(object sender, EventArgs e)
        {
            Form formRealEstate = new FormRealEstate();
            formRealEstate.Show();
        }

        private void buttonOpenAgents_Click(object sender, EventArgs e)
        {
            Form formAgentSet = new FormAgentSet();
            formAgentSet.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonOpenDemands_Click(object sender, EventArgs e)
        {
            Form formSupply = new FormSupply();
            formSupply.Show();
        }
    }
}
