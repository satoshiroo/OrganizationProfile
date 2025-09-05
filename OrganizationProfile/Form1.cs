using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OrganizationProfile.Program;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OrganizationProfile
{
    public partial class frmRegistration : Form
    {
        private string _FullName;
        private int _Age;
        private long _ContactNo;
        private long _StudentNo;

        /////return methods 
        public long StudentNumber(string studNum)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(studNum))
                {
                    throw new ArgumentNullException("Student number cannot be empty.");
                }

                _StudentNo = long.Parse(studNum); // may throw FormatException or OverflowException
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Invalid Student Number format: " + ex.Message);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Student Number is too large: " + ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Always executes
            }
            return _StudentNo;
        }

        public long ContactNo(string Contact)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Contact))
                {
                    throw new ArgumentNullException("Contact number cannot be empty.");
                }
                if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
                {
                    _ContactNo = long.Parse(Contact);
                }
                else
                {
                    throw new FormatException("Contact number must be 10 or 11 digits.");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Contact number too large: " + ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Always executes
            }
            return _ContactNo;
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(LastName) ||
                    string.IsNullOrWhiteSpace(FirstName) ||
                    string.IsNullOrWhiteSpace(MiddleInitial))
                {
                    throw new ArgumentNullException("Name fields cannot be empty.");
                }

                if (Regex.IsMatch(LastName, @"^[a-zA-Z ]+$") &&
                    Regex.IsMatch(FirstName, @"^[a-zA-Z ]+$") &&
                    Regex.IsMatch(MiddleInitial, @"^[a-zA-Z ]+$"))
                {
                    _FullName = LastName + ", " + FirstName + " " + MiddleInitial;
                }
                else
                {
                    throw new FormatException("Name fields must contain only letters.");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Always executes
            }
            return _FullName;
        }

        public int Age(string age)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(age))
                {
                    throw new ArgumentNullException("Age cannot be empty.");
                }
                if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
                {
                    _Age = Int32.Parse(age); // can throw OverflowException
                }
                else
                {
                    throw new FormatException("Invalid age format.");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Age value is too large: " + ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Always executes
            }
            return _Age;
        }

        public frmRegistration()
        {
            InitializeComponent();
        }

        private void OrganizationalForm_Load(object sender, EventArgs e)
        {

            string[] ListOfProgram = new string[] {
                "BS Information Technology",
                "BS Computer Science",
                "BS Information System",
                "BS in Accountancy",
                "BS in Hospitality Management",
                "BS in Tourism Management"
            };
            for(int i = 0; i < ListOfProgram.Length; i++)
            {
                cbProgram.Items.Add(ListOfProgram[i].ToString());
            }

            cbGender.Items.Add("Male");
            cbGender.Items.Add("Female");
            cbGender.Items.Add("Prefer not to say");
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string Capitalize(string input)
            {
                if (string.IsNullOrWhiteSpace(input))
                    return string.Empty;

                input = input.Trim().ToLower(); // lowercase everything
                return char.ToUpper(input[0]) + input.Substring(1);
            }

                StudentInformationClass.SetFullName = FullName(Capitalize(txtLastName.Text),
                Capitalize(txtFirstName.Text), Capitalize(txtMiddleInitial.Text));

                StudentInformationClass.SetStudentNo = (int)StudentNumber(txtStudentNo.Text);
                StudentInformationClass.SetProgram = cbProgram.Text;
                StudentInformationClass.SetGender = cbGender.Text;
                StudentInformationClass.SetContactNo = (long)ContactNo(txtContactNo.Text);
                StudentInformationClass.SetAge = Age(txtAge.Text);
                StudentInformationClass.SetBirthday = dateTimePicker.Value.ToString("yyyyMM-dd");

                frmConfirmation frm = new frmConfirmation();
                frm.ShowDialog();
            }
    }
}
