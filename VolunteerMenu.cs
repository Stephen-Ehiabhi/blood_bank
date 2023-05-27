using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1
{
    public partial class VolunteerMenu : Form
    {
        public VolunteerMenu()
        {
            InitializeComponent();
        }

        private void btnAddVol_Click(object sender, EventArgs e)
        {
            AddVolunteerForm newform = new AddVolunteerForm();
            this.Hide();
            newform.ShowDialog();
        }

        private void btnShowVol_Click(object sender, EventArgs e)
        {
            ShowVolunteerForm newform = new ShowVolunteerForm();
            this.Hide();
            newform.ShowDialog();
        }

        private void btnAddVol_MouseHover(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.FromArgb(138, 171, 194);
            btn.Cursor = Cursors.Hand;
        }

        private void btnAddVol_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.FromArgb(137, 181, 175);
        }

    }
}
