using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Task1
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Registration_Click(object sender, EventArgs e)
        {
            string login = Login.Text;
            string password = Password.Text;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password)) 
            { 
                MessageBox.Show("Введите логин или пароль");
                return;
            }
            string filePath = Path.Combine("login.csv");
            
            if(File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                bool userExist = lines.Any(line => line.Split(';')[0] == login);
                if(userExist) 
                {
                    MessageBox.Show("Пользователь с таким логином существует");
                    return;
                }
            }
            using(StreamWriter writer = File.AppendText(filePath)) 
            {
                writer.WriteLine($"{login};{password};{DateTime.Now}");
                MessageBox.Show("Пользователь успешно зарегистрирован");
            }
        }
    }
}
