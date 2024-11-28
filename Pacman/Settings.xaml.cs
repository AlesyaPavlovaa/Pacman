using PACMAN;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Pacman
{ 
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }
       public static bool EffectSound=true;
       public static bool MusicSound=true;
        private void DebugMessage(string message)
        {
            DebugOutput.Text += message + "\n";
        }
        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            
            AnimationHelper.FadeIn(Window, 1.0); // Плавное появление кнопки за 1 секунду
        }
        private void Exit(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }
        private void EffectsOn(object sender, RoutedEventArgs e)
        {

            EffectSound = true;
            HighlightButton(sender as Button, "EffectsGroup");
        }
        private void EffectsOff(object sender, RoutedEventArgs e)
            {
                EffectSound = false;
                HighlightButton(sender as Button, "EffectsGroup");
            }
        private void MusicOn(object sender, RoutedEventArgs e)
            {
                if (!GameSounds.AlreadyPlay)
                {
                    MusicSound = true;
                    GameSounds.PlayBackgroundMusic();
                }
                HighlightButton(sender as Button, "MusicGroup");
            }
        private void MusicOff(object sender, RoutedEventArgs e)
            {
                MusicSound = false;
                GameSounds.StopMusic();
                HighlightButton(sender as Button, "MusicGroup");
            }
        private void SetDificulty(object sender, RoutedEventArgs e)
            {
                // Проверяем, что sender является кнопкой
                if (sender is Button button)
                {
                    switch (button.Name)
                    {
                        case "Easy":

                            DataFile.Dificult = 0;

                            break;
                        case "Normal":

                            DataFile.Dificult = 1;

                            break;
                        case "Hard":

                            DataFile.Dificult = 2;

                            break;
                        default:
                            MessageBox.Show("Unknown difficulty level");
                            break;
                    }
                    HighlightButton(button, "DifficultyGroup");
                }
            }
        private void HighlightButton(Button button, string groupTag)
            {
                // Сбрасываем цвета всех кнопок в группе
                var buttonsInGroup = FindVisualChildren<Button>(this).Where(b => (string)b.Tag == groupTag);
                foreach (var btn in buttonsInGroup)
                {
                    btn.ClearValue(Button.BackgroundProperty);
                }

                // Меняем цвет нажатой кнопки
                if (button != null)
                {
                    button.Background = new SolidColorBrush(Color.FromRgb(92,92,92)); // Светло-серый цвет
                }
            }
         private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
            {
                if (depObj != null)
                {
                    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                    {
                        DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                        if (child != null && child is T)
                        {
                            yield return (T)child;
                        }

                        foreach (T childOfChild in FindVisualChildren<T>(child))
                        {
                            yield return childOfChild;
                        }
                    }
                }
            }
        }
    }
