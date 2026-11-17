namespace HelloGUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }


        private void btnGoodbye_Click(object sender, EventArgs e)
        {
            string fullName = tbFullName.Text;

            lblResult.Text = "GOODBYE " + fullName.ToUpper() + " !!!";
        }

        private void btnHelloWorld_Click(object sender, EventArgs e)
        {
            string fullName = tbFullName.Text;

            lblResult.Text = "HELLO WORLD !!! Hello, " + fullName + ".";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string fullName = tbFullName.Text;
            string gender = "";
            string country = "";

            if (rbMale.Checked == true)
            {
                gender = "Male";
            }
            else if (rbFemale.Checked == true)
            {
                gender = "Female";
            }

            country = cbbCountry.Text;

            tbResult.Text = "Name: " + fullName + ". Gender: " 
                + gender + ". Country: " + country + ".";
        }
    }
}
