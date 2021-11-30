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
            richText.Font = fontDialog1.Font;
        }

        bool DocumentIsChanged = false;
        string pathSave = "";

        public void SaveDocument(string path, RichTextBox richTextBox)
        {
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                streamWriter.Write(richTextBox.Text);
            }
        }

        public string SaveDocument(SaveFileDialog saveFileDialog, RichTextBox richTextBox)
        {
            var resultSave = saveFileDialog.ShowDialog();
            if (resultSave == DialogResult.OK)
            {
                using (StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName))
                {
                    streamWriter.Write(richTextBox.Text);
                }
            }
            return saveFileDialog.FileName;
        }

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
                    SaveDocument(saveFileDialog1, richText);
                    richText.Text = "";
                    DocumentIsChanged = false;
                    pathSave = "";
                }
                else if (dialogResult == DialogResult.No)
                {
                    richText.Text = "";
                    DocumentIsChanged = false;
                    pathSave = "";
                }
            }
            else
            {
                richText.Text = "";
                pathSave = "";
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
                pathSave = openFileDialog1.FileName;
            }
        }

        private void openNewWindowMenuItem_Click(object sender, EventArgs e)
        {
            string currentProcess = Process.GetCurrentProcess().ProcessName;
            Process.Start(currentProcess);
        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pathSave))
            {
                // Save Document
                pathSave = SaveDocument(saveFileDialog1, richText);
            }
            else
            {
                // Update Document
                SaveDocument(pathSave, richText);
            }
        }

        private void saveAsMenuItem_Click(object sender, EventArgs e)
        {
            pathSave = SaveDocument(saveFileDialog1, richText);
        }



        private void fontMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richText.Font = fontDialog1.Font;
        }
    }
}