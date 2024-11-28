using Pacman;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace PACMAN
{
  
    public partial class MainWindow : Window
    {
       
        public MainWindow()

        {
            InitializeComponent();
            GameSounds.PlayBackgroundMusic();
            AnimationHelper.ApplyBlinkAnimationByTag(MainGrid, "blink", 0.8);
            DataFile.LoadGameData();
            this.Loaded += MainWindow_Loaded;
            Skins.LockSkin();
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Start();
            }
            if (e.Key == Key.Escape && NewGame.Visibility == Visibility.Hidden && Stats.Visibility == Visibility.Hidden)
            {
                Button_Exit();
            }
            if (e.Key == Key.F1 && NewGame.Visibility==Visibility.Hidden && Stats.Visibility==Visibility.Hidden)
            {

                Settings Settings = new Settings();
                Settings.ShowDialog();
            }
            if (e.Key == Key.F4) {
                NewGame.Visibility = Visibility.Visible; } 
            else if (e.Key == Key.Escape && NewGame.Visibility == Visibility.Visible) { 
                NewGame.Visibility = Visibility.Hidden; }
            if (e.Key == Key.F2 && NewGame.Visibility == Visibility.Hidden && Stats.Visibility == Visibility.Hidden)
            {

                Skins Settings = new Skins();
                Settings.ShowDialog();
            }
            if (e.Key == Key.F3)
            {
                StatsLoad();

            }
            if (e.Key == Key.Escape && Stats.Visibility == Visibility.Visible)
            {
                Stats.Visibility = Visibility.Hidden;
            }
            if (e.Key == Key.Escape && NewGame.Visibility==Visibility.Visible)
            {
                NewGame.Visibility = Visibility.Hidden;
            }
        }

        private void StatsLoad()
        {
            WinsText.Text = $"Wins:{DataFile.wins}";
            CountCoins.Text = $"Coins:{DataFile.countCoins}";
            Hits.Text = $"Hits:{DataFile.Hits}";
            HightScore.Text = $"HightScore:{DataFile.HightScore}";
            Stats.Visibility = Visibility.Visible;
        }
            private void ButtonYes_Click(object sender, RoutedEventArgs e)
            {
               
           
                DataFile.skin2Locked = true;
                DataFile.skin3Locked = true;
                DataFile.countCoins = 0;
                DataFile.currentSkin = 0;
                DataFile.wins = 0;
                DataFile.HightScore = 0;
                DataFile.Hits= 0;
                DataFile.SaveGameData();
                // Скрываем экран выхода
                NewGame.Visibility = Visibility.Hidden;
            }
            
            private void ButtonNo_Click(object sender, RoutedEventArgs e)
            {
                NewGame.Visibility = Visibility.Hidden;
            }
    void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Включаем полноэкранный режим
            this.WindowStyle = WindowStyle.None;
            this.WindowState = WindowState.Maximized;
            // Убедитесь, что игра запускается в рабочей области
            var workingArea = SystemParameters.WorkArea;
            this.Left = workingArea.Left;
            this.Top = workingArea.Top;
            this.Width = workingArea.Width;
            this.Height = workingArea.Height;
        }

        private MediaPlayer mediaPlayerHover = new MediaPlayer();
        private MediaPlayer mediaPlayerClick = new MediaPlayer();
        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            string targetTag = "fadeTag"; // Ваш целевой тег

            foreach (var element in AnimationHelper.FindVisualChildren<UIElement>(this))
            {
                if (element is FrameworkElement fe && fe.Tag != null && fe.Tag.ToString() == targetTag)
                {
                    AnimationHelper.FadeIn(element, 11.0); // Применение анимации плавного появления
                }
            }

        }
        private void Button_Exit() { 
     
            Window1 popup = new Window1();
            popup.ShowDialog();
        }
        private void Start()
        {
            GameSounds.StopMusic();
            Game gameWindow = new Game();
           
                gameWindow.WindowStyle = WindowStyle.None;
                gameWindow.WindowState = WindowState.Maximized;
                var workingArea = SystemParameters.WorkArea;
                gameWindow.Left = workingArea.Left;
                gameWindow.Top = workingArea.Top;
                gameWindow.Width = workingArea.Width;
                gameWindow.Height = workingArea.Height;
            
            gameWindow.Show();
            this.Close();
        }
    }
}
