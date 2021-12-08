using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersianNotepad
{
    public partial class SearchForm : Form
    {
        Form1 form1;
        public SearchForm(Form1 frm1)
        {
            form1 = frm1;
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string SearchKey = searchTextBox.Text;
            int startIndex = 0;
            while (startIndex < form1.richText.Text.Length)
            {
                int wordStartIndex = form1.richText.Find(SearchKey, startIndex, RichTextBoxFinds.None);
                if (wordStartIndex != -1)
                {
                    form1.richText.SelectionStart = wordStartIndex;
                    form1.richText.SelectionLength = SearchKey.Length;
                    form1.richText.SelectionBackColor = Color.Yellow;
                }
                else break;
                startIndex = wordStartIndex + SearchKey.Length;
            }
        }
    }
}
