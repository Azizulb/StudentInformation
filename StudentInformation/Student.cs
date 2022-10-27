using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace StudentInformation
{
   public class Student
    {
        string sId = "";
        string sName = "";
        string sAddress = "";
        double bangla = 0.0;
        double english = 0.0;
        double math = 0.0;
        

        #region properties
        public string StudentId

        {
            get
            {
                return sId;
            }
            set
            {
                sId = value;
            }
        }
        public string StudenName

        {
            get
            {
                return sName;
            }
            set
            {
                sName = value;
            }
        }
        public string StudentAddress

        {
            get
            {
                return sAddress;
            }
            set
            {
                sAddress = value;
            }
        }
        public double MarksOfBangla
        {
            get
            {
                return bangla;
            }
            set
            {

                if (value >= 0 && value <= 100)
                {
                    bangla = value;
                }
            }
               
            
        }
        public double MarksOfEnglish
        {
            get
            {
                return english;
            }
            set
            {

                if (value >= 0 && value <= 100)
                {
                    english = value;
                }
            }


        }
        public double MarksOfMath
        {
            get
            {
                return math;
            }
            set
            {

                if (value >= 0 && value <= 100)
                {
                    math = value;
                }
            }


        }
        #endregion

        #region Methods
        public double AVGMarks()
        {
            return (MarksOfBangla + MarksOfEnglish + MarksOfMath) / 3;
        }
        public void Save()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-49PGGOU;Initial Catalog=Information;Integrated Security=True");
              SqlCommand cmd = new SqlCommand("INSERT INTO Student VALUES('"+StudentId+"','"+StudenName+"','"+StudentAddress+"',"+MarksOfBangla+","+MarksOfEnglish+","+MarksOfMath+")", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void Update()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-49PGGOU;Initial Catalog=Information;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("UPDATE student SET name('" + StudentId + "','" + StudenName + "','" + StudentAddress + "'," + MarksOfBangla + "," + MarksOfEnglish + "," + MarksOfMath + "WHERE Id='"+StudentId+"')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
      

        #endregion
       
    }

}
