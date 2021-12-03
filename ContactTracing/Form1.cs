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

namespace ContactTracing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string[] arr = { "Fever", "Dry Cough", "Sore Throat", "Shortness of Breath", "Loss of Smell and taste", "Fatigue", "Body Pain", "Runny Nose", "Diarhea", "Headache" };
            healthCheckList.Items.AddRange(arr);
        }

        private void buttonGender_Click(object sender, EventArgs e)
        {
            groupGenderBox.Enabled = true;
            if (groupGenderBox.Visible)
            {
                groupGenderBox.Visible = false;
            }
            else
            {
                groupGenderBox.Visible = true;
            }

        }

        private void radioButtonMale_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonMale.Checked)
            {
                buttonGender.Text = "Male";
            }
            else
            {
                buttonGender.Text = "Female";
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            StreamWriter output;
            output = File.CreateText(@"C:\Users\ASUNCION\Desktop\Safe Stay\" + textBoxFN.Text + ".txt");
            output.WriteLine("Full Name: " + textBoxFN.Text);
            output.WriteLine("Date: " + dateTimePicker.Value);
            output.WriteLine("Residence: " + textBoxResidence.Text);
            if (radioButtonMale.Checked)
            {
                buttonGender.Text = "Male";
                output.WriteLine("Gender: Male");
            }
            else
            {
                buttonGender.Text = "Female";
                output.WriteLine("Gender: Female");
            }
            output.WriteLine("Contact Number: " + textBoxContact.Text);
            output.WriteLine("Email: " + textBoxEmail.Text);
            output.WriteLine("1.) Has experienced any symptoms: ");
            foreach (Object item in healthCheckList.CheckedItems)
            {     
                output.WriteLine(item.ToString());
            }
            output.WriteLine("2.) Had f2f contact with person positive with Covid-19 for the past 14 days: ");
            if (question2No.Checked)
            {
                output.WriteLine(" -No");
            }
            else
            {
                output.WriteLine(" -Yes");
            }
            output.WriteLine("3. )Took care of a person probable or positive with Covid-19 for the past 14 days: ");
            if (question3No.Checked)
            {
                output.WriteLine(" -No");
            }
            else
            {
                output.WriteLine(" -Yes");
            }
            output.WriteLine("4.) Traveled outside the Philippines for the past 14 days: ");
            if (question4No.Checked)
            {
                output.WriteLine(" -No");
            }
            else
            {
                output.WriteLine(" -Yes");
            }
            output.WriteLine("5.) Have travel outside the current city: ");
            if (question5No.Checked)
            {
                output.WriteLine(" -No");
            }
            else
            {
                output.WriteLine(" -Yes");
            }
            output.Close();
            MessageBox.Show("Data added. Thank you for your input.");
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
            
 
        }

        private void healthCheckList_Click(object sender, EventArgs e)
        {
            
        }

        private void certiCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (certiCheckBox.Checked)
            {
                btnSubmit.Enabled = true;
            }
            else
            {
                btnSubmit.Enabled = false;
            }
        }
    }
}
