using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace UsbKeyTester
{
    public partial class TestUsbKeyForm : Form
    {
        private readonly BackgroundWorker _backgroundWorker = new BackgroundWorker();
        private static Random _rand = new Random(Guid.NewGuid().GetHashCode());
        private char[] lettersAndNumbers = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz01234567890".ToCharArray();
        private char[] originalChars;
        private int linesGenerated = 0;
        public TestUsbKeyForm()
        {
            InitializeComponent();
            _backgroundWorker.DoWork += (sender, args) =>
            {
                RunBtn.Enabled = false;
                var fullPath = ((DriveRunDetails) args.Argument).FullPath;
                var availableFreeSpace = ((DriveRunDetails) args.Argument).EmptyBytes;
                BuildFile(fullPath, availableFreeSpace);
                CheckFile(fullPath);
                CheckFileProgressBar.Value = 0;
                CheckFileProgressBar.Maximum = 1;
                CreateFileProgressBar.Maximum = 1;
                CreateFileProgressBar.Value = 0;
                File.Delete(fullPath);
            };

            _backgroundWorker.RunWorkerCompleted += (sender, args) =>
            {
                RunBtn.Enabled = true;
            };

            this.FormClosing += (sender, args) =>
            {
                if (_backgroundWorker.WorkerSupportsCancellation == true)
                {
                    // Cancel the asynchronous operation.
                    _backgroundWorker.CancelAsync();
                }
            };
        }

        private void TestUsbKeyForm_Load(object sender, EventArgs e)
        {
            foreach (var ite in DriveInfo.GetDrives().Select(f => f.Name))
            {
                this.DriveDropDownBox.Items.Add(ite);
            }

            DriveDropDownBox.SelectedIndex = 0;
        }

        private void RunBtn_Click(object sender, EventArgs e)
        {
            var drive = DriveInfo.GetDrives().FirstOrDefault(f => f.Name == DriveDropDownBox.SelectedItem.ToString());
            var fileName = $"{Guid.NewGuid():N}.img";
            var fullPath = $"{drive}{fileName}";
            _backgroundWorker.RunWorkerAsync(new DriveRunDetails {FullPath = fullPath, EmptyBytes = drive.AvailableFreeSpace});
        }

        private class DriveRunDetails
        {
            public string FullPath { get; set; }
            public long EmptyBytes { get; set; }
        }

        private void BuildFile(string filePath, long sizeOfUsbInBytes)
        {
            const int LenghtOfBytes = 10000000;
            // as we know in asci a letter is a byte lets make a list 
            var chars = new List<char>(LenghtOfBytes);
            for (int i = 0; i < LenghtOfBytes; i++)
            {
                chars.Add(lettersAndNumbers[_rand.Next(1, lettersAndNumbers.Length - 1)]);
            }

            originalChars = chars.ToArray();
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            using (var sw = new StreamWriter(filePath))
            {
                for (long i = 0; i < sizeOfUsbInBytes -(LenghtOfBytes+1); i += LenghtOfBytes + 1)
                {
                    sw.WriteLine(chars.ToArray());
                    char first = chars[0];
                    chars = chars.Skip(1).ToList();
                    chars.Add(first);
                    linesGenerated++;
                    CreateFileProgressBar.Value = (int) (i / LenghtOfBytes);
                    CreateFileProgressBar.Maximum = (int) (sizeOfUsbInBytes / LenghtOfBytes);
                }
            }

            CreateFileProgressBar.Value = 1;
            CreateFileProgressBar.Maximum = 1;
        }

        private void CheckFile(string filePath)
        {
            var lines = 0;
            var listChars = originalChars.ToList();
            using (var fs2 = new StreamReader(filePath))
            {
                string fileOneLine = null;
                while ((fileOneLine = fs2.ReadLine()) != null)
                {
                    if (fileOneLine != string.Join("", listChars))
                    {
                        MessageBox.Show("miss match in files");
                        return;
                    }

                    char first = listChars[0];
                    listChars = listChars.Skip(1).ToList();
                    listChars.Add(first);
                    lines++;

                    CheckFileProgressBar.Maximum = linesGenerated;
                    CheckFileProgressBar.Value = lines;
                }


                if (linesGenerated != lines)
                {
                    MessageBox.Show("miss match in files");
                    return;
                }

                MessageBox.Show("Done");
            }
        }
    }
}