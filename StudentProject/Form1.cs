using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace StudentProject
{
    public partial class Form1 : Form
    {

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-3VCAOSSB\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");



        public Form1()
        {
            InitializeComponent();
            show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        // For Reset Opearation
        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            comboBox1.Text = "";
        }

        // For INSERT Opearation 
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                String name = textBox1.Text.ToString();
                String add = textBox2.Text.ToString();

                String phone = textBox3.Text.ToString();
                long iphone = Int64.Parse(phone);

                String sem = textBox4.Text.ToString();
                int isem = Int32.Parse(sem);

                String dept = comboBox1.Text.ToString();


                //MessageBox.Show("Name :  " + name + ", address  " + add + " , iphone  "+iphone+". sem "+isem+", dept  " + dept);

                String qry = "insert into student values ('" + name + "' ,'" + add + "' ," + iphone + "," + isem + ", '" + dept + "')";

                SqlCommand sc = new SqlCommand(qry, con);

                int i = sc.ExecuteNonQuery();

                if (i >= 1)
                    MessageBox.Show(i + " Student Registered Successfully : " + name);
                else
                    MessageBox.Show(" Student is not Registered: ");


                button1_Click(sender, e);

                show();
                con.Close();



            }
            catch (System.Exception exp)
            {

                MessageBox.Show(" Error is  " + exp.ToString());







            }
        }


        // For UPDATE Opearation
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                String name = textBox1.Text.ToString();
                String add = textBox2.Text.ToString();

                String phone = textBox3.Text.ToString();
                long iphone = Int64.Parse(phone);

                String sem = textBox4.Text.ToString();
                int isem = Int32.Parse(sem);

                String dept = comboBox1.Text.ToString();


                //MessageBox.Show("Name :  " + name + ", address  " + add + " , iphone  "+iphone+". sem "+isem+", dept  " + dept);

                String qry = "update student set  sadd='" + add + "' ,phone=" + iphone + ",sem=" + isem + ",dept= '" + dept + "' where sname='" + name + "'";

                SqlCommand sc = new SqlCommand(qry, con);

                int i = sc.ExecuteNonQuery();

                if (i >= 1)
                    MessageBox.Show(i + " Student Updated Successfully : " + name);
                else
                    MessageBox.Show(" Student Updation Failed! User name already exists! ");


                button1_Click(sender, e);

                show();
                con.Close();


            }
            catch (System.Exception exp)
            {

                MessageBox.Show(" Error is  " + exp.ToString());


            }

        }

        void show()
        {

            SqlDataAdapter sda = new SqlDataAdapter("select * from student ", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = dr[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = dr[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = dr[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = dr[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = dr[4].ToString();



            }

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }



        // For DELETE Opearation 
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                String name = textBox1.Text.ToString();
                
                String qry = "delete from student where sname='" + name + "'";

                SqlCommand sc = new SqlCommand(qry, con);

                int i = sc.ExecuteNonQuery();

                if (i >= 1)
                    MessageBox.Show(i + " Student Deleted Successfully : " + name);
                else
                    MessageBox.Show(" Student Deletion Failed... ");


                button1_Click(sender, e);

                show();
                con.Close();


            }
            catch (System.Exception exp)
            {

                MessageBox.Show(" Error is  " + exp.ToString());


            }
        }

        // For searching STUDENT by NAME
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from student where sname like '%"+textBox5.Text.ToString()+"%'" , con);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = dr[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = dr[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = dr[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = dr[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = dr[4].ToString();



            }
            con.Close();
        }

        // For checking a phone no is valid or not
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            var text = textBox3.Text.ToString();
            if (text.Length <= 0)
                return;
            if (!(text[text.Length-1] >= '0' && text[text.Length - 1] <= '9'))
            {
                MessageBox.Show("Phone no can only be a number!");
                textBox3.Text = text.Substring(0, text.Length-1);

                return;
            }
            if(text.Length>11)
            {
                MessageBox.Show("Mobile No can't be greater than 11 digits!");
                textBox3.Text = text.Substring(0, text.Length - 1);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
