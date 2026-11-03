using System.Windows;

namespace HelloWpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SayHello_Click(object sender, RoutedEventArgs e)
        {
            Greeting greeting = new Greeting();
            greeting.Name = "Ari";
            MessageText.Text = greeting.BuildMessage();
        }
    }

    public class Greeting
    {
        public string Name { get; set; }

        public string BuildMessage()
        {
            return string.IsNullOrWhiteSpace(Name)
                ? "Hello!"
                : "Hello, " + Name + "!";
        }
    }
}