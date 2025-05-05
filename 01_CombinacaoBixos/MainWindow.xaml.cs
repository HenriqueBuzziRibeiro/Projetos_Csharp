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

namespace Projetos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SetUpGame();
        }

        public void SetUpGame()
        {
            List<string> animalEmoji = new List<string>()
            {
                "🐙","🐙",
                "🐒","🐒",
                "🐎","🐎",
                "🦌","🦌",
                "🦅","🦅",
                "🦨","🦨",
                "🦏","🦏",
                "🐇","🐇"
            };

            Random random = new Random();

            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>()) //'mainGrid' nome que foi dado para a grid, linha 10 do 'MainWindow.xaml'. Importante ressaltar que os 'textBlock' não são uma lista, mas podem ser percorridos
            {
                int index = random.Next(animalEmoji.Count); //'.Count' retorna os elementos restante na lista e o '.Next' gera um numero entre 0 e n-1
                textBlock.Text = animalEmoji[index];
                animalEmoji.RemoveAt(index);
            }
        }
    }
}