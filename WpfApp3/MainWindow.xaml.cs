using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;

namespace WPFinalka
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void DownloadPicture(object sender, RoutedEventArgs e)
        {
            string url = UrlTextBox.Text;
            string folderPath = DestinationTextBox.Text;


            if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(folderPath))
            {
                MessageBox.Show("Please enter a valid URL and select a save folder.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                StatusListBox.Items.Add("Downloading...");
                await DownloadPictureAsync(url, folderPath);
                StatusListBox.Items.Add("Download completed!");
            }
            catch (Exception ex)
            {
                StatusListBox.Items.Add($"Failed: {ex.Message}");
            }
        }
        private async void DonwloadFile(object sender, RoutedEventArgs e)
        {
            string url = UrlTextBox.Text;
            string folderPath = DestinationTextBox.Text;

            if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(folderPath))
            {
                MessageBox.Show("Please enter a valid URL and select a save folder.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                StatusListBox.Items.Add("Downloading...");
                await DownloadFileAsync(url, folderPath);
                StatusListBox.Items.Add("Download completed!");
            }
            catch (Exception ex)
            {
                StatusListBox.Items.Add($"Failed: {ex.Message}");
            }
        }

        private async Task DownloadPictureAsync(string url, string filePath)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFile(url, $@"{filePath}\picture.jpg");
        }
        private async Task DownloadFileAsync(string url, string filePath)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFile(url, $@"{filePath}\File.bin");
        }

    }
}
