using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace json_data_save
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<Book> listB = new List<Book>();
        JavaScriptSerializer convertJS = new JavaScriptSerializer();


        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Book newBook = new Book();
            newBook.Title = textBoxTitle.Text;
            newBook.Author = textBoxAuthor.Text;
            newBook.Publisher = textBoxPublisher.Text;
            newBook.Page = textBoxPage.Text;
            newBook.Price = numericUpDownPrice.Value;
            newBook.BType = comboBoxBType.Text;

            listB.Add(newBook);

            AddToJSON(listB);

            MessageBox.Show("SAVED");

        }

        private void AddToJSON(List<Book> newBook)
        {
            string j = convertJS.Serialize(listB);
            File.WriteAllText("../../booksdata1.json",j);
           
        }

        private void buttonGetJSON_Click(object sender, EventArgs e)
        {
            string content = File.ReadAllText("../../booksdata1.json");
            var listS = convertJS.Deserialize<List<Book>>(content);

            listBox1.DisplayMember = "Data";

            foreach (var item in listS)
            {
                listBox1.Items.Add((item.Title + " - " + item.Author + " - " + item.Price+"£" ));
            }


        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxTitle.Clear();
            textBoxAuthor.Clear();
            textBoxPublisher.Clear();
            textBoxPage.Clear();
            numericUpDownPrice.ResetText();
            comboBoxBType.ResetText();
        }

        private void buttonClearListBox_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}
