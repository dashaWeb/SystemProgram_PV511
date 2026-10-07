using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _06_Async_await_demo_first;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    Random rnd = new Random();
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void Generate(object sender, RoutedEventArgs e)
    {
        //int value = GenerateValue(); // freeze
        //list.Items.Add(value);
        //var  task = Task.Run(GenerateValue);
        //list.Items.Add(await Task.Run(GenerateValue)); // freeze
        list.Items.Add(await GenerateValueAsync());
        //MessageBox.Show("Complate");
        // async - alow method to use await keywords
        // await - wait task without freezing

        
    }

    int GenerateValue()
    {
        MessageBox.Show("Generate");
        Thread.Sleep(rnd.Next(5000));
        return rnd.Next(1000);
    }
    Task<int> GenerateValueAsync()
    {
        return Task.Run(() =>
        {
            Thread.Sleep(rnd.Next(5000));
            return rnd.Next(1000);
        });
    }
}