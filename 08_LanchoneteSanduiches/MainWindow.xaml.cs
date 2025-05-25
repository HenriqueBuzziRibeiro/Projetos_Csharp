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
using _08_LanchoneteSanduiches;

namespace _08_LanchoneteSanduiches
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MakeMenuItem();

        }

        private void MakeMenuItem()
        {
            MenuItem[] menu = new MenuItem[5];

            for (int i = 0; i < menu.Length; i++)
            {
                if (i < 3)
                {
                    menu[i] = new MenuItem();
                    menu[i].GenerateMenuItem();
                }
                else
                {
                    if (i == 3)
                    {
                        menu[i] = new MenuItem();
                        menu[i].Bread = new string[] { "plain bagel", "onion bagel", "pumpernicked bagel", "everything bagel" }; //adiciona uma nova lista de Breads para o item de index 3 e depois usa a função GenerateMenuItem();
                        menu[i].GenerateMenuItem();
                    }
                    else
                    {
                        menu[i] = new MenuItem();
                        menu[i].Proteins = new string[] { "Prganic man", "Mushroom patty", "Mortadella" };
                        menu[i].Codiments = new string[] { "A gluten free roll", "a wrap", "pita" };
                        menu[i].Bread = new string[] { "dijon mustard", "mise dressing", "au jus" };
                        menu[i].GenerateMenuItem();
                    }
                }
            }

            item1.Text = menu[0].description;
            item2.Text = menu[1].description;
            item3.Text = menu[2].description;
            item4.Text = menu[3].description;
            item5.Text = menu[4].description;
            price1.Text = menu[0].price;
            price2.Text = menu[1].price;
            price3.Text = menu[2].price;
            price4.Text = menu[3].price;
            price5.Text = menu[4].price;
        }
    }
}