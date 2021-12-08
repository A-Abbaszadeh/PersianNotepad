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
        List<SearchResult> searchResults = new List<SearchResult>();
        int indexSelectedSearchResult = -1;
        private void searchButton_Click(object sender, EventArgs e)
        {
            form1.richText.SelectionBackColor = form1.richText.BackColor;
            string SearchKey = searchTextBox.Text;
            if (searchResults.Count > 0)
            {
                ShowResultWithSelected(radioDown.Checked);
                return;
            } else
            {
                searchResults = new List<SearchResult>();
            }
            var searchOption = RichTextBoxFinds.None;
            if (radioWholeWord.Checked)
            {
                searchOption = RichTextBoxFinds.WholeWord;
            }

            int startIndex = 0;
            int wordStartIndex = 0;
            while (startIndex < form1.richText.Text.Length)
            {
                wordStartIndex = form1.richText.Find(SearchKey, startIndex, searchOption);
                if (wordStartIndex != -1)
                {
                    searchResults.Add(new SearchResult
                    {
                        SelectionStart = wordStartIndex,
                        SelectionLength = SearchKey.Length,
                        SearchKey = SearchKey
                    });
                }
                else break;
                startIndex = wordStartIndex + SearchKey.Length;
            }
            if (wordStartIndex != -1)
                ShowResultWithSelected(radioDown.Checked);
        }

        private void ShowResultWithSelected(bool IsDown)
        {
            try
            {
                if (IsDown)
                {
                    indexSelectedSearchResult++;
                }
                else
                {
                    indexSelectedSearchResult--;
                }

                var selected = searchResults[indexSelectedSearchResult];
                form1.richText.SelectionStart = selected.SelectionStart;
                form1.richText.SelectionLength = selected.SelectionLength;
                form1.richText.SelectionBackColor = Color.Yellow;

                if (searchResults.Count <= indexSelectedSearchResult)
                {
                    indexSelectedSearchResult = 0;
                    searchResults = new List<SearchResult>();
                }
            }
            catch (Exception)
            {
                if (IsDown)
                {
                    indexSelectedSearchResult--;

                }
                else
                {
                    indexSelectedSearchResult++;
                }

                var selected = searchResults[indexSelectedSearchResult];
                form1.richText.SelectionStart = selected.SelectionStart;
                form1.richText.SelectionLength = selected.SelectionLength;
                form1.richText.SelectionBackColor = Color.Yellow;
            }
        }

        private void SearchForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.richText.SelectionBackColor = form1.richText.BackColor;
        }
    }

    public class SearchResult
    {
        public int SelectionStart { get; set; }
        public int SelectionLength { get; set; }
        public string SearchKey { get; set; }
    }
}
