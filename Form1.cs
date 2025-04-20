 using System;
using System.Linq;
using System.Windows.Forms;

namespace TextAnalyzer
{
    public partial class Form1 : Form
    {
        private TextBox inputBox;
        private Button analyzeButton;
        private Label resultLabel;

        public Form1()
        {
            InitializeComponent();

            this.Text = "Text Analyzer";
            this.Width = 600;
            this.Height = 400;

            inputBox = new TextBox
            {
                Multiline = true,
                Width = 500,
                Height = 150,
                Top = 20,
                Left = 40,
                ScrollBars = ScrollBars.Vertical
            };

            analyzeButton = new Button
            {
                Text = "Analyze",
                Top = inputBox.Bottom + 10,
                Left = 40,
                Width = 100
            };
            analyzeButton.Click += AnalyzeButton_Click;

            resultLabel = new Label
            {
                Top = analyzeButton.Bottom + 10,
                Left = 40,
                Width = 500,
                Height = 150,
                AutoSize = false
            };

            this.Controls.Add(inputBox);
            this.Controls.Add(analyzeButton);
            this.Controls.Add(resultLabel);
        }

        private void AnalyzeButton_Click(object sender, EventArgs e)
        {
            string text = inputBox.Text;
            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show("Please enter text to analyze.");
                return;
            }

            var words = text
                .Split(new[] { ' ', '\n', '\r', '\t', '.', ',', ';', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);

            int wordCount = words.Length;
            int charCount = text.Count(c => !char.IsWhiteSpace(c));
            int lineCount = text.Split('\n').Length;
            string mostCommon = words
                .GroupBy(w => w.ToLower())
                .OrderByDescending(g => g.Count())
                .First()
                .Key;

            double avgWordLength = words.Any() ? words.Average(w => w.Length) : 0;

            resultLabel.Text =
                $"Words: {wordCount}\n" +
                $"Characters (no spaces): {charCount}\n" +
                $"Lines: {lineCount}\n" +
                $"Most common word: {mostCommon}\n" +
                $"Average word length: {avgWordLength:F2}";
        }
    }
}
