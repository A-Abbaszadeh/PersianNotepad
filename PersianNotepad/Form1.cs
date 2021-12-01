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
        Stack<string> undoList = new Stack<string>();

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

        public DialogResult SaveSure()
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
            }
            if (dialogResult != DialogResult.Cancel)
            {
                richText.Text = "";
                DocumentIsChanged = false;
                pathSave = "";
            }
            return dialogResult;
        }

        private void newDocumentMenuItem_Click(object sender, EventArgs e)
        {
            if (DocumentIsChanged)
            {
                SaveSure();
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
            undoList.Push(richText.Text);
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

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            if (DocumentIsChanged)
            {
                DialogResult userResult = SaveSure();
                if (userResult != DialogResult.Cancel)
                {
                    Application.Exit();

                }
            }
            else
            {
                Application.Exit();
            }
        }

        private void statusBarMenuItem_Click(object sender, EventArgs e)
        {
            statusBarMenuItem.Checked = !statusBarMenuItem.Checked;
            statusBar.Visible = !statusBar.Visible;
        }

        private void toolBoxMenuItem_Click(object sender, EventArgs e)
        {
            toolBoxMenuItem.Checked = !toolBoxMenuItem.Checked;
            toolBox.Visible = !toolBox.Visible;
        }

        private void editMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            copyMenuItem.Enabled = (richText.SelectedText.Length > 0);
            cutMenuItem.Enabled = (richText.SelectedText.Length > 0);
            deleteMenuItem.Enabled = (richText.SelectedText.Length > 0);
            pasteMenuItem.Enabled = Clipboard.ContainsText();
        }

        private void copyMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(richText.SelectedText))
            {
                Clipboard.SetText(richText.SelectedText);
            }
        }

        private void pasteMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                richText.Paste();
            }
        }

        private void deleteMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(richText.SelectedText))
            {
                richText.SelectedText = richText.SelectedText.Replace(richText.SelectedText, "");
            }
        }

        private void cutMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(richText.SelectedText))
            {
                Clipboard.SetText(richText.SelectedText);
                richText.SelectedText = richText.SelectedText.Replace(richText.SelectedText, "");
            }
        }

        private void undoMenuItem_Click(object sender, EventArgs e)
        {
            undoList.Pop();
            richText.Text = undoList.Pop();
        }

        private void selectAllMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectAll();
        }

        private void dateTimeMenuItem_Click(object sender, EventArgs e)
        {
            int cursorLocation = richText.SelectionStart;
            string dateTime = $"{DateTime.Now} " ;
            richText.SelectionStart = cursorLocation;
            
            richText.Text = richText.Text.Insert(cursorLocation, dateTime);
            richText.SelectionStart = cursorLocation + dateTime.Length;

            //richText.Text += DateTime.Now.ToString();
        }

        private void printMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string str = richText.Text;
            int chars;
            int lines;

            SolidBrush b = new SolidBrush(Color.Black);
            StringFormat strformat = new StringFormat();
            strformat.Trimming = StringTrimming.Word;
            RectangleF myrect = new RectangleF(e.MarginBounds.Left,
            e.MarginBounds.Top, e.MarginBounds.Width, e.MarginBounds.Height);
            SizeF sz = new SizeF(e.MarginBounds.Width, e.MarginBounds.Height - fontDialog1.Font.GetHeight(e.Graphics));
            e.Graphics.MeasureString(str, fontDialog1.Font, sz, strformat, out chars, out lines);
            string printstr = str.Substring(0, chars);
            e.Graphics.DrawString(printstr, fontDialog1.Font, b, myrect, strformat);
            if (str.Length > chars)
            {
                str = str.Substring(chars);
                e.HasMorePages = true;
            }
            else
                e.HasMorePages = false;
        }
    }
}