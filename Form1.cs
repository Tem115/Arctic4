using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Collections;

namespace Pizzeria
{
    public partial class Form1 : Form
    {
        new int Click = 0;
        List<Person> Human = new List<Person>();
        class Person
        {
            public Label Label = new Label();
            public TextBox FIO = new TextBox();
            public TextBox Address = new TextBox();
            public TextBox Pizza = new TextBox();
            public TextBox Diametr = new TextBox();
            public CheckBox Sauce = new CheckBox();
        }

        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "XML files(*.xml)|*.xml";
            saveFileDialog1.Filter = "XML files(*.xml)|*.xml";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Click++;
            Human.Add(new Person());
            tableLayoutPanel1.RowCount++;

            for (int column = 0; column < 6; column++)
            {
                tableLayoutPanel1.Controls.Add(Qwaqwa(Click - 1, column), column, Click);
                Qwaqwa(Click - 1, column).Anchor = (AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left);
                Qwaqwa(Click - 1, column).Font = new System.Drawing.Font("Times New Roman", this.Height / 30);
            }
            Human.ElementAt(Click - 1).Label.Text = Click.ToString();
            Human.ElementAt(Click - 1).Sauce.CheckAlign = ContentAlignment.MiddleCenter;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            
            if (tableLayoutPanel1.RowCount > 2)
            { 
                tableLayoutPanel1.RowCount--;
                for (int column = 0; column < 6; column++)
                    tableLayoutPanel1.Controls.Remove(Qwaqwa(Click - 1, column));
                Human.RemoveAt(Click - 1);
                Click--;
            }          
        }

        private void OpenToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string fileNameOpen = openFileDialog1.FileName;
            XMLMetodOpen();
        }

        private void SaveToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string fileNameSave = saveFileDialog1.FileName;
            File.Create(fileNameSave);          
            XMLMetodSave(fileNameSave);
        }

        private Control Qwaqwa(int i, int column)
        {
            switch (column)
            {
                case 0:
                    return Human.ElementAt(i).Label;
                case 1:
                    return Human.ElementAt(i).FIO;
                case 2:
                    return Human.ElementAt(i).Address;
                case 3:
                    return Human.ElementAt(i).Pizza;
                case 4:
                    return Human.ElementAt(i).Diametr;
                default:
                    return Human.ElementAt(i).Sauce;
            }
        }
        private void XMLMetodSave(string fileNameSave)
        {
            //XmlDocument xDoc = new XmlDocument();

            //xDoc.Load(@fileNameSave);      //Начал делать сохранение файла.Но почему то на это строчке ошибку выводит-этот файл уже используется другим процессом!

            //List<XmlElement> Human = new List<XmlElement>();
            //XmlElement Label = xDoc.CreateElement("Label");
            //XmlElement FIO = xDoc.CreateElement("FIO");
            //XmlElement Address = xDoc.CreateElement("Address");
            //XmlElement Pizza = xDoc.CreateElement("Pizza");
            //XmlElement Diametr = xDoc.CreateElement("Diametr");
            //XmlElement Sause = xDoc.CreateElement("Sause");
        }
        private void XMLMetodOpen()
        {

        }
    }
}
