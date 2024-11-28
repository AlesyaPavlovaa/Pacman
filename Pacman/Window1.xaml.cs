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
using System.Windows.Shapes;

namespace PACMAN
{
   
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        

            private void OnWindowLoaded(object sender, RoutedEventArgs e)
            {
                // Пример: Применение анимации к кнопке
                AnimationHelper.FadeIn(Window, 1.0); // Плавное появление кнопки за 1 секунду
            }


        private void Exit(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }

        private void ButtonYes_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonNo_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
           
        }
    }
}
