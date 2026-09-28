
using System.Diagnostics;
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
using System.Windows.Threading;

namespace _02_TaskManager;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    DispatcherTimer _timer = null;

    public MainWindow()
    {
        InitializeComponent();
        _timer = new DispatcherTimer();
        _timer.Interval = new TimeSpan(0, 0, 20);
        _timer.Tick += _timer_Tick;
        _timer.Start();
        Refresh(null, null);
    }

    private void Refresh(object sender, RoutedEventArgs e)
    {
        grid.ItemsSource = Process.GetProcesses();
    }
    private void _timer_Tick(object? sender, EventArgs e)
    {
        Refresh(sender, null);
    }

    private void RadioButton_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show(((RadioButton)sender).Content.ToString());
        int number = int.Parse(((RadioButton)sender).Content.ToString());
    }

    private void Kill_Process(object sender, RoutedEventArgs e)
    {

        var res = ((Process)grid.SelectedItem);
        MessageBox.Show(res.ProcessName);
        //text.Text = res.ProcessName;
        res.Kill();
        Refresh(null, null);
        //input.Text
    }
}