using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace FileMerger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _file1 = string.Empty;
        private string _file2 = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MergeFile_Clicked(object sender, RoutedEventArgs e)
        {
            string path = "Data/merged.txt";

            if (string.IsNullOrEmpty(_file1) || string.IsNullOrEmpty(_file2))
            {
                MessageBox.Show("Please select both files before merging.");
                return;
            }
            else if (File.Exists(path))
            {
                MessageBox.Show("The file already exists. Please delete it before merging.");
                return;
            }

            if (!Directory.Exists("Data"))
            {
                Directory.CreateDirectory("Data");
            }

            try
            {
                File.WriteAllText(path, _file1 + _file2);
                MessageBox.Show("Files merged successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while merging files: " + ex.Message);
            }
        }

        private void BrowseFile1_Clicked(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    _file1 = File.ReadAllText(openFileDialog.FileName);
                    File1.Text = _file1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while reading file: " + ex.Message);
                }
            }
        }

        private void BrowseFile2_Clicked(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    _file2 = File.ReadAllText(openFileDialog.FileName);
                    File2.Text = _file2;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while reading file: " + ex.Message);
                }
            }
        }
    }
}
}