using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5_addition
{
    public partial class Form1 : Form
    {
        public static Dictionary<char, char> letters = new Dictionary<char, char>() 
        { 
            { 'а', 'я' },
            { 'б', 'ю' },
            { 'в', 'ь' },
            { 'г', 'щ' },
            { 'ґ', 'ш' },
            { 'д', 'ч' },
            { 'е', 'ц' },
            { 'є', 'х' },
            { 'ж', 'ф' },
            { 'з', 'у' },
            { 'и', 'т' },
            { 'і', 'с' },
            { 'й', 'р' },
            { 'ї', 'п' },
            { 'к', 'о' },
            { 'л', 'н' },
            { 'м', 'м' },
            { 'н', 'л' },
            { 'о', 'к' },
            { 'п', 'й' },
            { 'р', 'ї' },
            { 'с', 'і' },
            { 'т', 'и' },
            { 'у', 'з' },
            { 'ф', 'ж' },
            { 'х', 'є' },
            { 'ц', 'е' },
            { 'ч', 'д' },
            { 'ш', 'ґ' },
            { 'щ', 'г' },
            { 'ь', 'в' },
            { 'ю', 'б' },
            { 'я', 'а' }
        };

        public Form1()
        {
            InitializeComponent();
            FillDataGridView();
        }
        private void FillDataGridView()
        {
            dataGridView1.Rows.Clear();
            foreach (var ch in letters)
            {
                dataGridView1.Rows.Add(ch.Key, ch.Value);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> to = new List<string>();
            try
            {
                for (int i = 0; i < 33; i++)
                {
                    to.Add(dataGridView1.Rows[i].Cells[1].Value.ToString());
                }
                if (IsValid(to))
                {
                    if (checkBox1.Checked)
                    {
                        Decrypt();
                    }
                    else
                    {
                        Encrypt();
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private bool IsValid(List<string> letters)
        {
            if (string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                MessageBox.Show("Please, enter text to richTextBox");
                return false;
            }
            if (letters.Distinct().Count() < 33)
            {
                MessageBox.Show("You cannot replace several letters with one");
                return false;
            }
            return true;
        }

        private void Encrypt()
        {
            string result = "";
            foreach(var ch in richTextBox1.Text.ToLower())
            {
                result += letters.ContainsKey(ch) ? letters[ch] : ch;
            }
            richTextBox2.Text = result;
        }

        private void Decrypt()
        {
            string result = "";
            foreach(var ch in richTextBox1.Text.ToLower())
            {
                result += letters.Any(c => c.Value == ch) ? letters.Where(c => c.Value == ch).Select(c => c.Key).First() : ch;
            }
            richTextBox2.Text = result;
        }
    }
}
