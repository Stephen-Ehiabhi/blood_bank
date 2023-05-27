using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace _1
{
    static class DataHolding
    {
        public static List<Volunteer> all_Volunteers = new List<Volunteer>();

        public static void ReadDataVolunteer()
        {
            try
            {
                all_Volunteers.Clear(); // Clear the list before reading the data

                using (StreamReader reader = new StreamReader("VolunteerDB.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] data = line.Split('|');
                        all_Volunteers.Add(new Volunteer(data[0], data[1], data[2], Convert.ToInt32(data[3]), Convert.ToInt32(data[4]), data[5], data[6], data[7]));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void WriteDataVolunteer()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("VolunteerDB.txt", false))
                {
                    foreach (Volunteer volunteer in all_Volunteers)
                    {
                        string line = $"{volunteer.Name}|{volunteer.LName}|{volunteer.Email}|{volunteer.SocialID}|{volunteer.PhoneNumber}|{volunteer.BloodType}|{volunteer.ID}|{volunteer.DateOfDonation}";
                        writer.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
