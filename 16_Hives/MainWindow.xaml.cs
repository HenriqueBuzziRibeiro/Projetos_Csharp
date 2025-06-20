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

namespace _16_Hives
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Queen queen = new Queen();
        public MainWindow()
        {
            InitializeComponent();
            statusReport.Text = queen.StatusReport;
        }

        private void AssignJob_Click(object sender, RoutedEventArgs e)
        {
            queen.AssignBee(jobSelector.Text);    //os casos do 'AssignBee' devem combinar exatamente com os itens do ComboBox
            statusReport.Text = queen.StatusReport;
        }

        private void WorkShift_Click(object sender, RoutedEventArgs e)
        {
            queen.AssignBee(jobSelector.Text);
            statusReport.Text = queen.StatusReport;
        }
    }
}