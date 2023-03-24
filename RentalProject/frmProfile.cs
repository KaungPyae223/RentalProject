using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RentalProject
{
    public partial class frmProfile : Form
    {
        public frmProfile()
        {
            InitializeComponent();
            this.DT = Program.DT;
            AddInfo();  // call a method to add info
            AddHistory();   // call a method to add data in dgv History
        }
        RentalTableAdapters.vi_ModifyTableAdapter objAdmin = new RentalTableAdapters.vi_ModifyTableAdapter();
        RentalTableAdapters.HireTableAdapter objHire = new RentalTableAdapters.HireTableAdapter();
        RentalTableAdapters.vi_CustomerPaymentTableAdapter objHistory = new RentalTableAdapters.vi_CustomerPaymentTableAdapter();
        DataTable DT = new DataTable();

        private void AddHistory()
        {
            if(Program.Type == "User") //Check the type is user
            {
                string Description;

                DataTable Return = new DataTable();
                Return = objHire.GetReturnDate(DT.Rows[0][0].ToString());
                //select user return Hire data from data base and add in Return

                DataTable History = new DataTable();
                History = objHistory.GetData(DT.Rows[0][0].ToString());
                //select user History data from data base and add in History

                DataTable ShowHistory = new DataTable(); // declare a new data table
                ShowHistory.Columns.Add("HireID", typeof(string));
                ShowHistory.Columns.Add("Description", typeof(string));
                ShowHistory.Columns.Add("Date", typeof(string));
                // add columns to the new data table

                int a = 0; // declare and assigned data 0 to the int a for looping
                foreach (DataRow Row in History.Rows) // 
                {

                    int i = a;  // declare and assigned data from "a" as a inilized data for loopin
                    while (i<Return.Rows.Count) // use while loop until the i < Return rows count
                    {

                        // check the history date is less than return date
                        if (Convert.ToDateTime(Row[4])<=Convert.ToDateTime(Return.Rows[i][10])) 
                        {
                            DataRow Ret = ShowHistory.NewRow(); // declare new row of the Show History
                            Ret[0] = Return.Rows[i][0].ToString();
                            Description = "Return an Hire";
                            Ret[1]= Description;
                            Ret[2]= Convert.ToDateTime(Return.Rows[i][10]).ToString("dd MMMM yyyy");
                            // add data to the new row

                            ShowHistory.Rows.Add(Ret);
                            // add row to the data table

                            a++;  // add 1 to the a
                        }
                        i++;    // add 1 to i
                       
                    }
                    DataRow dr = ShowHistory.NewRow(); // declare new row of the Show History
                    dr[0] = Row[1].ToString();
                    Description = Row[6].ToString();
                    Description = (Description.Contains("New Hire")) ? "New Hire" : Row[6].ToString();
                    dr[1]= Description;
                    dr[2]= Convert.ToDateTime(Row[4]).ToString("dd MMMM yyyy");
                    ShowHistory.Rows.Add(dr);
                    // add row the show History
                }
                dgvUserHistory.DataSource = ShowHistory; 
                // add all the data from show History to the dgvUserHistory to show data
                dgvUserHistory.Columns[0].Width = (dgvUserHistory.Width/100)*10;
                dgvUserHistory.Columns[1].Width = (dgvUserHistory.Width/100)*70;
                dgvUserHistory.Columns[2].Width = (dgvUserHistory.Width/100)*20;
                // design a data grid view


                /*

                    disclaimer for the User History Add

                    In user history, user transation hire, extension is in one table and 
                    return hire table is from different table. 

                    So to show all the data, use new data table and add data from two 
                    data table into one and show

                    In here the user transation such as hire, extend and return are not
                    serial as a transation date. So, to make it looping and selection 
                    statement are use to add data to show serial as the transation date

                    In looping start loop all the row in the Hire and payment table and
                    in here make a nested loop the row in Return table. In nested loop
                    use the while loop because the added data are not wanted to add agan
                    in data table

                    Out side the loop declare variable a as a start point while loop.
                    In loop declare i as an initilized for while loop and add a to the i
                    In while loop check the date between the return and hire. If the return
                    date is greater than the hire date, add return to the data table and
                    add 1 to the a, so next loop, this row is not checked. After the while loop
                    add data from the hire row. and then next loop is start.

                */


            }
            else
            {
                dgvUserHistory.DataSource = objAdmin.GetModifyByAdmin(DT.Rows[0]["AdminName"].ToString());
                // add admin transation data to show

                dgvUserHistory.Columns[0].Visible = false;
                dgvUserHistory.Columns[1].Width = (dgvUserHistory.Width/100)*40;
                dgvUserHistory.Columns[2].Width = (dgvUserHistory.Width/100)*30;
                dgvUserHistory.Columns[3].Width = (dgvUserHistory.Width/100)*30;

            }
        }
        private void AddInfo()
        {
            if (Program.Type == "User")
            {
                // add the user data to the profile form
                lblName.Text = DT.Rows[0]["CustomerName"].ToString();
                lblAccountName.Text = DT.Rows[0]["AccountName"].ToString();
                lblEmail.Text = DT.Rows[0]["CustomerEmail"].ToString();
                lblID.Text = DT.Rows[0]["CustomerID"].ToString();
                lblLocation.Text = DT.Rows[0]["CustomerLocation"].ToString();
                lblUserLevel.Text = DT.Rows[0]["CustomerLevel"].ToString();

                if (DT.Rows[0]["CustomerPhoto"].ToString() != string.Empty)
                {
                    byte[] img = (byte[])(DT.Rows[0]["CustomerPhoto"]);
                    MemoryStream ms = new MemoryStream(img);
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }
            else
            {

                // add the admin data to the profile form
                lblName.Text = DT.Rows[0]["AdminName"].ToString();
                lblAccountName.Text = DT.Rows[0]["AccountName"].ToString();
                lblEmail.Text = DT.Rows[0]["AdminEmail"].ToString();
                lblID.Text = DT.Rows[0]["AdminID"].ToString();
                lblLocation.Text = DT.Rows[0]["AdminLocation"].ToString();
                lblUserLevel.Text = DT.Rows[0]["AdminPost"].ToString();

                if (DT.Rows[0]["AdminPhoto"].ToString() != string.Empty)
                {
                    byte[] img = (byte[])(DT.Rows[0]["AdminPhoto"]);
                    MemoryStream ms = new MemoryStream(img);
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }
        }

        private void btnEditProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Program.Type == "Admin")    // If the type is admin, only password to updat
            {
                frmUpdatePassword frm = new frmUpdatePassword(DT.Rows[0][9].ToString(), DT.Rows[0]["AdminID"].ToString());
                frm.Show();
            }
            else // If the type is user, user update form is appear and can update.
            {
                frmUserRegister frm = new frmUserRegister();
                frm.txtName.Text = DT.Rows[0][3].ToString();
                frm.txtAccountName.Text = DT.Rows[0][2].ToString();
                frm.txtPhone.Text = DT.Rows[0][6].ToString();
                frm.txtNRC.Text = DT.Rows[0][7].ToString();
                frm.txtLocation.Text = DT.Rows[0][4].ToString();
                frm.txtEmail.Text = DT.Rows[0][5].ToString();
                frm.txtEmail.ReadOnly = true;
                frm.IsEdit = true;
                frm.image = (byte[])(DT.Rows[0]["CustomerPhoto"]);
                frm.CustomerID = DT.Rows[0]["CustomerID"].ToString();
                frm.Text = "The Customer Edit";
                frm.btnRegister.Text = "Edit";
                frm.Show();
            }
        }
    }
}
