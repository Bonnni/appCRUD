using System;
using System.Windows.Forms;
using appCRUD.EF.Entities;

namespace appCRUD
{
    public partial class Form1 : Form
    {
        private int _row; 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UserOperationsEF eF = new UserOperationsEF();
            dataGridView1.DataSource = eF.GetUsers();
            dataGridView1.Columns[1].ReadOnly = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            UserOperationsEF eF = new UserOperationsEF();
            eF.UserCreate(new User() { FirstName = textBox1.Text, LastName = textBox2.Text });
            MessageBox.Show("Пользователь создан :)");
            dataGridView1.DataSource = eF.GetUsers();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserOperationsEF eF = new UserOperationsEF();
            eF.UserUpdate(int.Parse(textBox3.Text), textBox1.Text, textBox2.Text);
            dataGridView1.DataSource = eF.GetUsers();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _row = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[_row].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[_row].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[_row].Cells[0].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserOperationsEF eF = new UserOperationsEF();
            eF.UserDelete(int.Parse(textBox3.Text));
            dataGridView1.DataSource = eF.GetUsers();

        }
    }
}
