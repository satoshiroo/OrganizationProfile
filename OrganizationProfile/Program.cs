using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrganizationProfile
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmRegistration());
        }

        public class StudentInformationClass
        {
            public int SetStudentNo = 0;
            public int SetContactNo = 0;
            public string SetProgram = "";
            public string SetGender = "";
            public string SetBirthday = "";
            public string SetFullName = "";
        }
    }
}
