using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _07_Copy_File
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel model;
        public MainWindow()
        {
            InitializeComponent();
            model = new ViewModel()
            {
                Source = @"D:\Dasha\Programming\1GB.bin",
                Destination = @"D:\Dasha\Programming\Gropus\Test",
                Progress = 0
            };
            this.DataContext = model;
        }


        private async void CopyButtonClick(object sender, RoutedEventArgs e)
        {
            string FileName = System.IO.Path.GetFileName(model.Source);
            // Destination + "\" + FileName
            string destFilePath = System.IO.Path.Combine(model.Destination, FileName);
            // way 1 //File.Copy(Source, destFilePath,true);
            await CopyFileAsync(model.Source, destFilePath);

            MessageBox.Show("Complate");
        }

        private Task CopyFileAsync(string src, string dest)
        {
            return Task.Run(() =>
            {
                using (FileStream srcStream = new FileStream(src, FileMode.Open, FileAccess.Read))
                {
                    using (FileStream destStream = new FileStream(dest, FileMode.Create, FileAccess.Write))
                    {
                        byte[] buffer = new byte[1024 * 8]; // 8 kb
                        int bytes = 0;
                        do
                        {
                            bytes = srcStream.Read(buffer, 0, buffer.Length);
                            destStream.Write(buffer, 0, bytes);
                            float percenttage = destStream.Length / (srcStream.Length / 100);
                            //Thread.Sleep(1000);
                            model.Progress = (int)percenttage;

                        } while (bytes > 0);
                    }
                }
            });
        }
        private void OpenSourceButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                model.Source = dialog.FileName;
                //srcTextBox.Text = Source;
            }
        }

        private void OpenDestButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFolderDialog dialog = new OpenFolderDialog();
            if (dialog.ShowDialog() == true)
            {
                model.Destination = dialog.FolderName;
                //destTextBox.Text = Destination;
            }
        }


    }
    public class ViewModel
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public int Progress { get; set; }
        public ViewModel()
        {
            
        }
    }
}