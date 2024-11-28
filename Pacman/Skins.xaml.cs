using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using PACMAN;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Pacman
{
    public partial class Skins : Window
    {
        private readonly string _DragonImagePath = "pack://application:,,,/images/addition/DragonIcon.png";
        private readonly string _PacmanImagePath = "pack://application:,,,/images/addition/PacmanIcon.png";
        private readonly string _CatImagePath = "pack://application:,,,/images/addition/CatIcon.png";
        private readonly string _CatinBoxImagePath = "C:\\Users\\Alice\\source\\repos\\Pacman\\Pacman\\images\\addition\\CatinBoxIcon.png";
        private readonly string _usingImagePath = "pack://application:,,,/images/addition/using.png";
        private readonly string _LockImagePath = "C:\\Users\\Alice\\source\\repos\\Pacman\\Pacman\\images\\addition\\Lockek.png";

        private Button _currentButton = null;

        public Skins()
        {
            InitializeComponent();
            Images();


        }

        private void Exit(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            // Example: Apply animation to button
            AnimationHelper.FadeIn(Window, 1.0); // Smooth appearance of the button in 1 second
        }

        public static void LockSkin()
        {
            if (DataFile.wins >= 2 && DataFile.countCoins >= 400)
            {
                DataFile.skin2Locked = false;
                DataFile.SaveGameData();
            }
            else
            {
                DataFile.skin2Locked = true;
            }
          
            if (DataFile.wins >= 15 && DataFile.countCoins >= 1200)
            {
                DataFile.skin3Locked = false;
                DataFile.SaveGameData();
            }
            else
            {
                DataFile.skin3Locked = true;
            }
            if (DataFile.wins >= 15 && DataFile.countCoins >= 1200)
            {
                DataFile.skin4Locked = false;
                DataFile.SaveGameData();
            }
            else
            {
                DataFile.skin4Locked = true;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == null) return;

            // If another button was previously clicked, reset its background
            if (_currentButton != null && _currentButton != clickedButton)
            {
                ResetButtonBackground(_currentButton);
            }

            // Change the background of the clicked button
            if (_currentButton == clickedButton)
            {
                ResetButtonBackground(clickedButton);
                _currentButton = null;
            }
            else
            {
                clickedButton.Background = new ImageBrush(new BitmapImage(new Uri(_usingImagePath)));
                _currentButton = clickedButton;
            }

            // Update the currentSkin variable based on the clicked button's name
            UpdateCurrentSkin(clickedButton.Name);


        }

        private void ResetButtonBackground(Button button)
        {
            if (button == Pacman)
                button.Background = new ImageBrush(new BitmapImage(new Uri(_PacmanImagePath)));
            else if (button == Dragon)
                button.Background = new ImageBrush(new BitmapImage(new Uri(_DragonImagePath)));
            else if (button == Cat)
                button.Background = new ImageBrush(new BitmapImage(new Uri(_CatImagePath)));
            else if (button == CatinBox)
                button.Background = new ImageBrush(new BitmapImage(new Uri(_CatinBoxImagePath)));
        }

        private void Images()
        {
            Pacman.Background = new ImageBrush(new BitmapImage(new Uri(_PacmanImagePath)));

            if (DataFile.skin2Locked == false)
            {
                Dragon.Background = new ImageBrush(new BitmapImage(new Uri(_DragonImagePath)));
                Dragon.IsEnabled = true;
            }
            else
            {
                Dragon.Background = new ImageBrush(new BitmapImage(new Uri(_LockImagePath)));
                Dragon.IsEnabled = false;
            }

            if (DataFile.skin3Locked == false)
            {
                Cat.Background = new ImageBrush(new BitmapImage(new Uri(_CatImagePath)));
                Cat.IsEnabled = true;
            }
            else
            {
                Cat.Background = new ImageBrush(new BitmapImage(new Uri(_LockImagePath)));
                Cat.IsEnabled = false;
            }

            if (DataFile.skin4Locked == false)
            {
                CatinBox.Background = new ImageBrush(new BitmapImage(new Uri(_CatinBoxImagePath)));
                CatinBox.IsEnabled = true;
            }
            else
            {
                CatinBox.Background = new ImageBrush(new BitmapImage(new Uri(_LockImagePath)));
                CatinBox.IsEnabled = false;
            }
        }




        private void UpdateCurrentSkin(string buttonName)
        {
            switch (buttonName)
            {
                case "Dragon":
                    DataFile.currentSkin = 1;
                    break;
                case "Cat":
                    DataFile.currentSkin = 2;
                    break;
                case "CatinBox":
                    DataFile.currentSkin = 3;
                    break;
                case "Pacman":
                    DataFile.currentSkin = 0;
                    break;


            }
        }
    }
}

       
