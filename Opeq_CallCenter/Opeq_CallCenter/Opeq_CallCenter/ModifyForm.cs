﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Opeq_CallCenter

{
    public partial class ModifyForm : Form
    {
        //SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-KFOB4HEQ\DINAL;Initial Catalog=Opeq_CallCenter;Integrated Security=True");
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-H0P1R86\SQLEXPRESS;Initial Catalog=Opeq;Integrated Security=True");

        public ModifyForm()
        {
            InitializeComponent();
        }

        private void ModifyForm_Load(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd1 = con.CreateCommand();
            SqlCommand cmd2 = con.CreateCommand();
            SqlCommand cmd3 = con.CreateCommand();
            SqlCommand cmd4 = con.CreateCommand();

            cmd1.CommandType = CommandType.Text;
            cmd2.CommandType = CommandType.Text;
            cmd3.CommandType = CommandType.Text;
            cmd4.CommandType = CommandType.Text;

            cmd1.CommandText = "SELECT * FROM Computer_Prob;";
            cmd2.CommandText = "SELECT * FROM Laptop_Prob;";
            cmd3.CommandText = "SELECT * FROM Screen_Prob;";
            cmd4.CommandText = "SELECT * FROM Phone_Tablet_Prob;";

            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            cmd3.ExecuteNonQuery();
            cmd4.ExecuteNonQuery();

            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
            SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2);
            SqlDataAdapter adapter3 = new SqlDataAdapter(cmd3);
            SqlDataAdapter adapter4 = new SqlDataAdapter(cmd4);

            DataSet dataSet1 = new DataSet();
            DataSet dataSet2 = new DataSet();
            DataSet dataSet3 = new DataSet();
            DataSet dataSet4 = new DataSet();

            adapter1.Fill(dataSet1);
            adapter2.Fill(dataSet2);
            adapter3.Fill(dataSet3);
            adapter4.Fill(dataSet4);

            con.Close();

            computerProblemComboBox.DataSource = dataSet1.Tables[0];
            computerProblemComboBox.DisplayMember = "computer_desc";
            computerProblemComboBox.ValueMember = "computer_prob_id";
            computerProblemComboBox.SelectedIndex = -1;

            laptopProblemComboBox.DataSource = dataSet2.Tables[0];
            laptopProblemComboBox.DisplayMember = "laptop_desc";
            laptopProblemComboBox.ValueMember = "laptop_prob_id";
            laptopProblemComboBox.SelectedIndex = -1;

            screenProblemComboBox.DataSource = dataSet3.Tables[0];
            screenProblemComboBox.DisplayMember = "screen_desc";
            screenProblemComboBox.ValueMember = "screen_prob_id";
            screenProblemComboBox.SelectedIndex = -1;

            phoneOrTabletProblemComboBox.DataSource = dataSet4.Tables[0];
            phoneOrTabletProblemComboBox.DisplayMember = "phone_tab_desc";
            phoneOrTabletProblemComboBox.ValueMember = "phone_tablet_prob_id";
            phoneOrTabletProblemComboBox.SelectedIndex = -1;

        }

        private void MATTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (MATTextBox.Text == "Entrer problème")
            {
                MATTextBox.Text = "";
            }
            MATTextBox.ForeColor = Color.Black;
        }



        private void loadBtn_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd1 = con.CreateCommand();
            SqlCommand cmd2 = con.CreateCommand();
            SqlCommand cmd3 = con.CreateCommand();
            SqlCommand cmd4 = con.CreateCommand();
            SqlCommand cmd5 = con.CreateCommand();
            SqlCommand cmd6 = con.CreateCommand();
            SqlCommand cmd7 = con.CreateCommand();
            SqlCommand cmd8 = con.CreateCommand();
            SqlCommand cmd9 = con.CreateCommand();
            SqlCommand cmd10 = con.CreateCommand();
            SqlCommand cmd11 = con.CreateCommand();
            SqlCommand cmd12 = con.CreateCommand();
            SqlCommand cmd13 = con.CreateCommand();
            SqlCommand cmd14 = con.CreateCommand();
            SqlCommand cmd15 = con.CreateCommand();
            SqlCommand cmd16 = con.CreateCommand();

            //Commands to run to get client information
            String MAT = MATTextBox.Text;
            cmd1.CommandText = "SELECT client_name FROM Client FULL OUTER JOIN Product ON Client.product_id=Product.product_id WHERE Product.MAT= '" + MAT + "';";
            cmd2.CommandText = "SELECT client_desc FROM Client FULL OUTER JOIN Product ON Client.product_id=Product.product_id WHERE Product.MAT= '" + MAT + "';";
            cmd3.CommandText = "SELECT date_added FROM Client FULL OUTER JOIN Product ON Client.product_id=Product.product_id WHERE Product.MAT= '" + MAT + "';";
            cmd4.CommandText = "SELECT by_email FROM Client FULL OUTER JOIN Product ON Client.product_id=Product.product_id WHERE Product.MAT= '" + MAT + "';";
            cmd5.CommandText = "SELECT by_telephone FROM Client FULL OUTER JOIN Product ON Client.product_id=Product.product_id WHERE Product.MAT= '" + MAT + "';";
            cmd6.CommandText = "SELECT in_person FROM Client FULL OUTER JOIN Product ON Client.product_id=Product.product_id WHERE Product.MAT= '" + MAT + "';";
            cmd7.CommandText = "SELECT client_email FROM Client FULL OUTER JOIN Product ON Client.product_id=Product.product_id WHERE Product.MAT= '" + MAT + "';";
            cmd8.CommandText = "SELECT client_phone_num FROM Client FULL OUTER JOIN Product ON Client.product_id=Product.product_id WHERE Product.MAT= '" + MAT + "';";
            cmd9.CommandText = "SELECT Client_Address.street FROM Client JOIN Product ON Client.product_id = Product.product_id JOIN Client_Address ON Client_Address.address_id = Client.address_id WHERE Product.MAT = '" + MAT + "';";
            cmd10.CommandText = "SELECT Client_Address.apt_num FROM Client JOIN Product ON Client.product_id = Product.product_id JOIN Client_Address ON Client_Address.address_id = Client.address_id WHERE Product.MAT = '" + MAT + "';";
            cmd11.CommandText = "SELECT Client_Address.city FROM Client JOIN Product ON Client.product_id = Product.product_id JOIN Client_Address ON Client_Address.address_id = Client.address_id WHERE Product.MAT = '" + MAT + "';";
            cmd12.CommandText = "SELECT Client_Address.postal_code FROM Client JOIN Product ON Client.product_id = Product.product_id JOIN Client_Address ON Client_Address.address_id = Client.address_id WHERE Product.MAT = '" + MAT + "';";
            cmd13.CommandText = "SELECT Computer_Prob.computer_prob_id FROM Client JOIN Product ON Client.product_id = Product.product_id JOIN Computer_Prob ON Computer_Prob.computer_prob_id = Client.computer_prob_id WHERE Product.MAT = '" + MAT + "';";
            cmd14.CommandText = "SELECT Laptop_Prob.laptop_prob_id FROM Client JOIN Product ON Client.product_id = Product.product_id JOIN Computer_Prob ON Laptop_Prob.laptop_prob_id = Client.laptop_prob_id WHERE Product.MAT = '" + MAT + "';";
            cmd15.CommandText = "SELECT Phone_Tablet_Prob.phone_tablet_prob_id FROM Client JOIN Product ON Client.product_id = Product.product_id JOIN Phone_Tablet_Prob ON Phone_Tablet_Prob.phone_tablet_prob_id = Client.phone_tablet_prob_id WHERE Product.MAT = '" + MAT + "';";
            cmd16.CommandText = "SELECT Screen_Prob.screen_prob_id FROM Client JOIN Product ON Client.product_id = Product.product_id JOIN Screen_Prob ON Screen_Prob.screen_prob_id = Client.screen_prob_id WHERE Product.MAT = '" + MAT + "';";

            //Commands to get problem descriptions
            SqlCommand cmd17 = con.CreateCommand();
            //SqlCommand cmd18 = con.CreateCommand();
            //SqlCommand cmd19 = con.CreateCommand();
            //SqlCommand cmd20 = con.CreateCommand();

            nameTextBox.Text = Convert.ToString(cmd1.ExecuteScalar());
            problemDescriptionTextBox.Text = Convert.ToString(cmd2.ExecuteScalar());
            dateTimePickerEntered.Value = Convert.ToDateTime(cmd3.ExecuteScalar());

            if(Convert.ToInt64(cmd4.ExecuteScalar())  == 1)
            {
                emailRadioBtn.Checked = true;
            }
            else if(Convert.ToInt64(cmd5.ExecuteScalar()) == 1)
            {
                phoneRadioBtn.Checked = true;
            }
            else if(Convert.ToInt64(cmd6.ExecuteScalar()) == 1)
            {
                inPersonRadioBtn.Checked = true;
            }

            emailTextbox.Text = Convert.ToString(cmd7.ExecuteScalar());
            phoneTextBox.Text = Convert.ToString(cmd8.ExecuteScalar());
            streetTextBox.Text = Convert.ToString(cmd9.ExecuteScalar());
            aptNumTextBox.Text = Convert.ToString(cmd10.ExecuteScalar());
            cityTextBox.Text = Convert.ToString(cmd11.ExecuteScalar());
            postalCodeTextBox.Text = Convert.ToString(cmd12.ExecuteScalar());

            if (Convert.ToInt64(cmd13.ExecuteScalar()) > 0)
            {
                cmd17.CommandText = "SELECT computer_desc FROM Computer_Prob WHERE computer_prob_id = '" + Convert.ToInt64(cmd13.ExecuteScalar()) + "';";
                //computerProblemComboBox.SelectedIndex = 0;
                computerProblemComboBox.SelectedIndex = computerProblemComboBox.FindString(cmd17.ExecuteScalar().ToString());
            }
            else if (Convert.ToInt64(cmd14.ExecuteScalar()) > 0)
            {
                cmd17.CommandText = "SELECT laptop_desc FROM Laptop_Prob WHERE laptop_prob_id = '" + Convert.ToInt64(cmd13.ExecuteScalar()) + "';";
                laptopProblemComboBox.SelectedIndex = laptopProblemComboBox.FindString(cmd17.ExecuteScalar().ToString());
            }
            else if (Convert.ToInt64(cmd15.ExecuteScalar()) > 0)
            {
                cmd17.CommandText = "SELECT phone_tab_desc FROM Phone_Tablet_Prob WHERE phone_tablet_prob_id = '" + Convert.ToInt64(cmd13.ExecuteScalar()) + "';";
                phoneOrTabletProblemComboBox.SelectedIndex = phoneOrTabletProblemComboBox.FindString(cmd17.ExecuteScalar().ToString());
            }
            else if (Convert.ToInt64(cmd16.ExecuteScalar()) > 0)
            {
                cmd17.CommandText = "SELECT screen_desc FROM Screen_Prob WHERE screen_prob_id = '" + Convert.ToInt64(cmd13.ExecuteScalar()) + "';";
                screenProblemComboBox.SelectedIndex = screenProblemComboBox.FindString(cmd17.ExecuteScalar().ToString());
            }


            con.Close();
        }

        //Boolean isAddBtnClicked;
        //Boolean isCancelBtnClicked;
        //Boolean isAddRadioBtnClicked;
        //Boolean isViewRadioBtnClicked;

        //private void confirmation()
        //{
        //    if (isAddBtnClicked == true)
        //    {
        //        DialogResult dialog = MessageBox.Show("Les donnés que vous avez rentrées vont être sauvegardés." +
        //            "\nModifier un autre client?", "Mise en garde", MessageBoxButtons.YesNo);
        //        if (dialog == DialogResult.Yes)
        //        {
        //            //This might break the app or not so test with caution
        //            this.Hide();
        //            AddForm addForm = new AddForm();
        //            addForm.ShowDialog();
        //            this.Close();
        //            //Alternate solution: create a Form for the confirmation 
        //        }
        //        else if (dialog == DialogResult.No)
        //        {
        //            this.Hide();
        //            MainHub mainHub = new MainHub();
        //            mainHub.ShowDialog();
        //            this.Close();
        //        }
        //    }
        //    else if (isCancelBtnClicked == true)
        //    {
        //        DialogResult dialog = MessageBox.Show("Les donnés que vous avez rentrées ne vont pas être sauvegardés." +
        //            "\nÊtes-vous sur d’annuler?", "Mise en garde", MessageBoxButtons.YesNo);
        //        if (dialog == DialogResult.Yes)
        //        {
        //            this.Hide();
        //            MainHub mainHub = new MainHub();
        //            mainHub.ShowDialog();
        //            this.Close();
        //        }
        //        else if (dialog == DialogResult.No)
        //        {
        //            isCancelBtnClicked = false;
        //        }
        //    }
        //    else if (isAddRadioBtnClicked == true)
        //    {
        //        DialogResult dialog = MessageBox.Show("Les donnés que vous avez rentrées ne vont pas être sauvegardés." +
        //            "\nÊtes-vous sur d’annuler?", "Mise en garde", MessageBoxButtons.YesNo);
        //        if (dialog == DialogResult.Yes)
        //        {
        //            this.Hide();
        //            ModifyForm modifyForm = new ModifyForm();
        //            modifyForm.ShowDialog();
        //            this.Close();
        //        }
        //        else if (dialog == DialogResult.No)
        //        {
        //            isAddRadioBtnClicked = false;
        //        }
        //    }
        //    else if (isViewRadioBtnClicked == true)
        //    {
        //        DialogResult dialog = MessageBox.Show("Les donnés que vous avez rentrées ne vont pas être sauvegardés." +
        //            "\nÊtes-vous sur d’annuler?", "Mise en garde", MessageBoxButtons.YesNo);
        //        if (dialog == DialogResult.Yes)
        //        {
        //            this.Hide();
        //            ViewForm viewForm = new ViewForm();
        //            viewForm.ShowDialog();
        //            this.Close();
        //        }
        //        else if (dialog == DialogResult.No)
        //        {
        //            isViewRadioBtnClicked = false;
        //        }
        //    }
        //}

        //private void addRadioBtn_MouseClick(object sender, MouseEventArgs e)
        //{
        //    isAddRadioBtnClicked = true;
        //    addRadioBtn.Checked = true;
        //    confirmation();
        //}

        //private void viewRadioBtn_MouseClick(object sender, MouseEventArgs e)
        //{
        //    isViewRadioBtnClicked = true;
        //    addRadioBtn.Checked = true;
        //    confirmation();
        //}
    }
}
