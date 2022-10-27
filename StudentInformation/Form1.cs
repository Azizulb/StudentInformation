using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentInformation
{
    public partial class Form1 : Form
    {
       

        Student s = new Student();
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-49PGGOU;Initial Catalog=Information;Integrated Security=True;");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT*FROM Student", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

            lblMsg.Text = "form is ready to use...";
        }

        private void LoadData()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-49PGGOU;Initial Catalog=Information;Integrated Security=True;");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT*FROM Student", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnAvg_Click(object sender, EventArgs e)
        {
           
            s.MarksOfBangla = Convert.ToDouble(txtBangla.Text);
            s.MarksOfEnglish = Convert.ToDouble(txtEnglish.Text);
            s.MarksOfMath = Convert.ToDouble(txtMath.Text);
            s.AVGMarks();
            lblMsg.Text = s.AVGMarks().ToString();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            txtId.Clear();
            txtName.Clear();
            txtAdd.Clear();
            txtBangla.Clear();
            txtEnglish.Clear();
            txtMath.Clear();
            txtId.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            s.StudentId = txtId.Text;
            s.StudenName = txtName.Text;
            s.StudentAddress = txtAdd.Text;
            s.MarksOfBangla = Convert.ToDouble(txtBangla.Text);
            s.MarksOfEnglish = Convert.ToDouble(txtEnglish.Text);
            s.MarksOfMath = Convert.ToDouble(txtMath.Text);
            s.Save();
            lblMsg.Text = "Data saved successfully!!";
            ClearAll();
            LoadData();
            

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-49PGGOU;Initial Catalog=Information;Integrated Security=True;");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT*FROM Student WHERE Id='"+txtId.Text +"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtName.Text = dt.Rows[0][1].ToString();
                txtAdd.Text = dt.Rows[0][2].ToString();
                txtBangla.Text = dt.Rows[0][3].ToString();
                txtEnglish.Text = dt.Rows[0][4].ToString();
                txtMath.Text = dt.Rows[0][5].ToString();
            }

        }

      
    }
}
