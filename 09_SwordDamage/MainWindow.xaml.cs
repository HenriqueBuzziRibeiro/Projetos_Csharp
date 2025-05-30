using System.Security.Cryptography.X509Certificates;
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
using _09_SwordDamage;

namespace _09_SwordDamage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        SwordDamage swordDmg = new SwordDamage();

        public MainWindow()
        {
            InitializeComponent();
        }

        public void RollDice()
        {
            swordDmg.Roll = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
            swordDmg.CalculateDamage();
        }

        private void Flaming_Checked(object sender, RoutedEventArgs e)
        {
            swordDmg.SetFlaming(true);
        }

        private void Flaming_Unchecked(object sender, RoutedEventArgs e)
        {
            swordDmg.SetFlaming(false);
        }

        private void Magic_Checked(object sender, RoutedEventArgs e)
        {
            swordDmg.SetMagic(true);
        }

        private void Magic_Unchecked(object sender, RoutedEventArgs e)
        {
            swordDmg.SetMagic(false);
        }

        private void buttonRoll_Click(object sender, RoutedEventArgs e)
        {
            RollDice();
            Displaydamage();
        }

        public void Displaydamage()
        {
            displayDamage.Text = "Rolled " + swordDmg.Roll + "for" + swordDmg.Damage + "HP";
        }
    }
}