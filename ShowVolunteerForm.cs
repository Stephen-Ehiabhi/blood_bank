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
    public partial class ShowVolunteerForm : Form
        {
        public int index = 0;
        public int NoCust = 1;

        public ShowVolunteerForm ( )
            {
            InitializeComponent ( );
            }

        private void ShowCustomerForm_Load ( object sender, EventArgs e )
            {
            DataHolding.all_Volunteers.Clear ( );// This one used to clear the list before Loading the data
            DataHolding.ReadDataVolunteer( );
            ShowData ( );

            }

        private void nextbtn_Click ( object sender, EventArgs e )
            {
            int NoOfVolunteers = DataHolding.all_Volunteers.Count;
            if ( NoCust < NoOfVolunteers)
                {
                index++;
                NoCust++;
                ShowData ( );
                lblNoCust.Text = NoCust.ToString ( );
                previousBtn.Enabled = true;
                } 
            
            if ( NoCust == NoOfVolunteers)
                {
                nextbtn.Enabled = false;
                previousBtn.Enabled = true;
                }
            }

        private void previousBtn_Click(object sender, EventArgs e)
        {
            int NoOfVolunteers = DataHolding.all_Volunteers.Count;
            if (NoCust == 2)
            {
                previousBtn.Enabled = false;
            }
            
            if (NoCust <= NoOfVolunteers)
            {
                index--;
                NoCust--;
                ShowData();
                lblNoCust.Text = NoCust.ToString();
                nextbtn.Enabled = true;
            }
        }



        private void btnback_Click ( object sender, EventArgs e )
            {
            VolunteerMenu newform = new VolunteerMenu( );
            newform.Show ( );
            this.Close ( );
            }

        private void btnEdit_MouseHover ( object sender, EventArgs e )
            {
            Button btn = ( Button )sender;
            btn.BackColor = Color.FromArgb ( 138, 171, 194 );
            btn.Cursor = Cursors.Hand;
        }

        private void btnEdit_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.FromArgb(137, 181, 175);
        }

        // Method That Shows the DATA 
        public void ShowData ( )
            {

            lblname.Text = DataHolding.all_Volunteers[index].Name;
            lblVol_ID.Text = DataHolding.all_Volunteers[index].ID;
            lbllastname.Text = DataHolding.all_Volunteers[index].LName;
            lblphonenum.Text = DataHolding.all_Volunteers[index].PhoneNumber.ToString ( );
            lblemail.Text = DataHolding.all_Volunteers[index].Email;
            lblSocialID.Text = DataHolding.all_Volunteers[index].SocialID.ToString();
            lblBloodType.Text = DataHolding.all_Volunteers[index].BloodType;
            lblDob.Text = DataHolding.all_Volunteers[index].DateOfDonation;

            try
            {
                PicBoxCustomer.Load ( $"Pictures/{DataHolding.all_Volunteers[index].ID}.jpg" );
                }
            catch ( Exception )
                {
                PicBoxCustomer.Load ( "Pictures/Default.jpg" );
                }
            }


        private void button1_Click(object sender, EventArgs e)
        {
            // Identify the volunteer to be deleted (e.g., using the volunteer's ID)
            string volunteerIdToDelete = DataHolding.all_Volunteers[index].ID;

            // Find the volunteer in the list and remove it
            Volunteer volunteerToDelete = DataHolding.all_Volunteers.Find(volunteer => volunteer.ID == volunteerIdToDelete);
            if (volunteerToDelete != null)
            {
                DataHolding.all_Volunteers.Remove(volunteerToDelete);
                DataHolding.WriteDataVolunteer(); // Save the updated data to the text file
                MessageBox.Show("Volunteer has been deleted.");
            }
            else
            {
                MessageBox.Show("Volunteer not found.");
            }
        }

    }
}
