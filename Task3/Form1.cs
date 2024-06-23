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
using System.IO.Packaging;

namespace Task3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonComercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Умножение");
                for (int i = 2; i <=9; i++) 
                {
                    worksheet.Cells[1, i].Value = i;
                    worksheet.Cells[i, 1].Value = i;
                    for (int j = 2; j <=9; j++)
                    {
                        worksheet.Cells[i, j].Value = i * j;
                    }
                }
                package.SaveAs(new System.IO.FileInfo("Умножение.xlsx"));
            }
            MessageBox.Show("Таблица умножения сделана и сохранена в файле Умножение.xlsx");
        }
    }
}
