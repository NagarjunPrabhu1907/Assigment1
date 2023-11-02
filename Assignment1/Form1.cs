using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Assignment1

{
    public partial class Form1 : Form
    {
        //SqlConnection connection;
        //SqlCommand command;
        public Form1()
        {
            InitializeComponent();


            //string connectionString = "Data Source=DESKTOP-D1U4HM6;Initial Catalog=MyDB;Integrated Security=True";
            //connection = new SqlConnection(connectionString);
            //command = new SqlCommand();
            //command.Connection = connection;

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string ID = textBox1.Text;
                string FirstName = textBox2.Text;
                string SecondName = textBox3.Text;
                using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-D1U4HM6;Initial Catalog=MyDB;Integrated Security=True"))
                {

                    connection.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "INSERT INTO NAMES1 (ID, FirstName, SecondName) VALUES (@ID, @FirstName, @SecondName)";

                        // Create and add SqlParameter objects
                        command.Parameters.Add(new SqlParameter("@ID", ID));
                        command.Parameters.Add(new SqlParameter("@FirstName", FirstName));
                        command.Parameters.Add(new SqlParameter("@SecondName", SecondName));

                        command.ExecuteNonQuery();

                        MessageBox.Show("Data inserted Successfully");

                        connection.Close();

                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                    }
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string ID = textBox1.Text;
                string FirstName = textBox2.Text;
                string SecondName = textBox3.Text;
                using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-D1U4HM6;Initial Catalog=MyDB;Integrated Security=True"))
                {

                    connection.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;

                        command.CommandText = "UPDATE NAMES1 SET FirstName = @FirstName, SecondName = @SecondName WHERE ID = @ID";

                        // Create and add SqlParameter objects
                        command.Parameters.Add(new SqlParameter("@ID", ID));
                        command.Parameters.Add(new SqlParameter("@FirstName", FirstName));
                        command.Parameters.Add(new SqlParameter("@SecondName", SecondName));

                        command.ExecuteNonQuery();

                        MessageBox.Show("Data updated Successfully");

                        connection.Close();

                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-D1U4HM6;Initial Catalog=MyDB;Integrated Security=True"))
                {

                    connection.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;

                        command.CommandText = "select * from NAMES1";
                        SqlDataReader reader = command.ExecuteReader();

                        // Create a DataTable to store the results
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);

                        // Bind the data to a DataGridView 
                        dataGridView1.DataSource = dataTable;

                        // Close the SqlDataReader and the database connection
                        reader.Close();
                        connection.Close();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                string ID = textBox1.Text;

                using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-D1U4HM6;Initial Catalog=MyDB;Integrated Security=True"))
                {

                    connection.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "select FirstName,SecondName from NAMES1 where ID = @ID";
                        command.Parameters.AddWithValue("@ID", ID);
                        SqlDataReader reader = command.ExecuteReader();

                        // Create a DataTable to store the results
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);

                        // Bind the data to a DataGridView 
                        dataGridView2.DataSource = dataTable;


                        reader.Close();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}