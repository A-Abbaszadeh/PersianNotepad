using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersianNotepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool DocumentIsChanged = false;

        private void newDocumentMenuItem_Click(object sender, EventArgs e)
        {
            if (DocumentIsChanged)
            {
                DialogResult dialogResult = MessageBox.Show("آیا میخواهید تغییرت موجود را ذخیره کنید؟"
                , "ذخیره سند"
                , MessageBoxButtons.YesNoCancel
                , MessageBoxIcon.Question
                , MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.Yes)
                {
                    // Save Document
                    var resultSave = saveFileDialog1.ShowDialog();
                    if (resultSave == DialogResult.OK)
                    {
                        using (StreamWriter streamWriter = new StreamWriter(saveFileDialog1.FileName))
                        {
                            streamWriter.Write(richText.Text);
                        }
                    }
                    richText.Text = "";
                    DocumentIsChanged = false;
                }
                else if (dialogResult == DialogResult.No)
                {
                    richText.Text = "";
                    DocumentIsChanged = false;
                }
            }
            else
            {
                richText.Text = "";
            }
        }

        private void richText_TextChanged(object sender, EventArgs e)
        {
            DocumentIsChanged = true;
        }

        private void openDocumentMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = openFileDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string fileText = "";
                using (StreamReader streamReader = new StreamReader(openFileDialog1.FileName))
                {
                    fileText = streamReader.ReadToEnd();
                }
                richText.Text = fileText;
            }

        }

        private void openNewWindowMenuItem_Click(object sender, EventArgs e)
        {
            string currentProcess = Process.GetCurrentProcess().ProcessName;
            Process.Start(currentProcess);
        }
    }
}