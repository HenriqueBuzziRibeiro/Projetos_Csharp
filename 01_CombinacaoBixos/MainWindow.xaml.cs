using System.Reflection;
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
    using System;
    using System.Windows.Threading;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            HideGameButton();

            // Configura o intervalo do timer para 1 segundo, irá chamar o evento 'Tick' a cada 1s
            timer.Interval = TimeSpan.FromSeconds(1);
            // Evento chamado a cada tick (1s), ligamos a função 'Timer_Tick' 
            timer.Tick += Timer_Tick;
        }

        public void HideGameButton() //para iniciar o programa com os botões escondidos
        {
            foreach (Button button in mainGrid.Children.OfType<Button>()) 
            {
                if(button != startButton) 
                    button.Visibility = Visibility.Hidden;           
            }
        }

        private TimeSpan elapsedTime;        //armazena o tempo decorrido
        private DateTime startTime;          //armazenao momento que o jogo começou
        private DispatcherTimer timer = new DispatcherTimer();   //atualiza o tempo na tela  - Quando você usa o DispatcherTimer, ele executa um método a cada intervalo de tempo.
        public void StarTime()
        {
            elapsedTime = TimeSpan.Zero;       // Armazena o tempo decorrido
            startTime = DateTime.Now;          // Armazena o horário atual
            timer.Start();                     // Inicia o timer
        }

        private void StopTime()
        {
            //Para o timer
            timer.Stop();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            // Calcula o tempo decorrido
            elapsedTime = DateTime.Now - startTime;

            // Atualiza o TextBlock com o tempo formatado
            timeTextBlock.Text = elapsedTime.ToString(@"mm\:ss");
        }

        bool gameStarted = false;
        public void StartAndStopButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button button in mainGrid.Children.OfType<Button>())
            {
                if (button != startButton)
                    button.Visibility = Visibility.Visible;
            }

            if (!gameStarted)
            {
                gameStarted = true;
                startButton.Content = "Stop";
                SetUpGame(); //Inicia o jogo
                StarTime();
                return;
            }else {
                gameStarted = false;
                startButton.Content = "Start";
                HideGameButton();
                StopTime();
                timeTextBlock.Text = "00:00";
                return;
            }
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

            foreach (Button button in mainGrid.Children.OfType<Button>()) //'mainGrid' nome que foi dado para a grid, linha 10 do 'MainWindow.xaml'. Importante ressaltar que os 'textBlock' não são uma lista, mas podem ser percorridos
            {
                if (button != startButton) 
                {
                    button.Content = "?"; //para iniciar sempre com '?'
                    int index = random.Next(animalEmoji.Count); //'.Count' retorna os elementos restante na lista e o '.Next' gera um numero entre 0 e n-1          
                    button.Tag = animalEmoji[index];    //guarda o emoji no '.Tag' (escondido)
                    animalEmoji.RemoveAt(index);
                    button.Cursor = Cursors.Hand;       //faz as mãozinha quando em cima do button              
                }
            }
        }

        Button lasTextBlockClicked; //não intanciamos aqui por que se não iria ser criado um botão fora da interface gráfica, fazendo com que o 'lasTextBlockClicked' não refletisse o botão real clicado
        bool findingMatch = false;
        int contadorPares = 0;
        private async void Button_Click(object sender, RoutedEventArgs e) 
        {
            Button button = sender as Button;
            
            // Impede clique em botão já revelado
            if (button.Content.ToString() != "?")
                return;

            if (findingMatch == false) //findingMatch será false quando não tiver sido revelada nenhum emoji ainda
            {
                button.Content = button.Tag;
                lasTextBlockClicked = button;
                findingMatch = true;
            }
            else if (lasTextBlockClicked.Content == button.Tag)
            {
                button.Content = button.Tag;
                findingMatch = false;
                contadorPares = contadorPares +1;
            }
            else
            {
                button.Content = button.Tag;
                mainGrid.IsEnabled = false;   //desativa a grid para não poder haver interações
                await Task.Delay(1000);       //congela por 2 segundos imagem para memorização           
                button.Content = "?";
                lasTextBlockClicked.Content = "?";
                findingMatch = false;
                mainGrid.IsEnabled = true;    //reativa grid para tentar adivinhar novamente
            }

            //Paralisa tempo caso descubra todos os pares
            if(contadorPares == 8)
            {
                StopTime();
            }

        }
    }
}