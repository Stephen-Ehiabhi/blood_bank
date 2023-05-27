using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _1
{
    public partial class AddVolunteerForm : Form
    {
        public AddVolunteerForm()
        {
            InitializeComponent();
        }
        // Method For Generate Date now
        protected string GenCurrentDate()
        {
            DateTime currentDateTime = DateTime.Now;
            return currentDateTime.ToString();
        }

        // Method For Generate VolunteerID 
        protected string GenId()
        {
            //generates random 5 digits id
            Random rnd = new Random();
            int rand01 = rnd.Next(10000, 99999);
            return $"{rand01}";
        }

        private void AddVolunteerForm_Load(object sender, EventArgs e)
        {
            lblDod.Text = GenCurrentDate();
        }

        private void btnImportImg_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "img files (*.png)|*.jpeg|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Read the Picture First
                PicBoxCustomer.Load(openFileDialog1.FileName);

            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TBfname.Text) ||
               string.IsNullOrEmpty(TBlastname.Text) ||
               string.IsNullOrEmpty(lblDod.Text) ||
               string.IsNullOrEmpty(TBemail.Text) ||
               string.IsNullOrEmpty(TBSocialId.Text) ||
               string.IsNullOrEmpty(TBPhonenumber.Text))
            {
                MessageBox.Show("Please fill in all the required fields.");
            }else
            {
                Volunteer nwVol = new Volunteer(TBfname.Text, TBlastname.Text, TBemail.Text, Convert.ToInt32(TBSocialId.Text), Convert.ToInt32(TBPhonenumber.Text), bloodtype.Text, GenId(), lblDod.Text);
                //Saving the picture into Pictures
                try
                {
                    string filedest = $"Pictures/{nwVol.ID}.jpg";
                    File.Copy(openFileDialog1.FileName, filedest, true);
                }
                catch (IOException iox)
                {
                    Console.WriteLine(iox.Message);
                }
                //Saving Data into VoluteerrDB.txt file

                // Adding the volunteer to the list in DataHolding class
                DataHolding.all_Volunteers.Add(nwVol);

                // Save the data to the text file
                DataHolding.WriteDataVolunteer();

                // Notify the user that the Volunteer has been added

                MessageBox.Show("Volunteer Has been Added");

                // Clearing Text Boxes 

                TBfname.Clear();
                TBlastname.Clear();
                TBemail.Clear();
                TBPhonenumber.Clear();
                TBSocialId.Clear();

                //Return To Main Menu 
                VolunteerMenu newform = new VolunteerMenu();
                this.Hide();
                newform.Show();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            VolunteerMenu newform = new VolunteerMenu();
            newform.Show();
        }

        private void btnSave_MouseHover(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.FromArgb(138, 171, 194);
            btn.Cursor = Cursors.Hand;
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.FromArgb(137, 181, 175);
        }
    }

}
