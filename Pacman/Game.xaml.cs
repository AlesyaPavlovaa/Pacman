using Pacman;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using System.Windows.Data;
using System.IO;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes; 
using System.Windows.Threading;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;
using System.Printing;


namespace PACMAN
{
    public partial class Game : Window
    {
        int GameCountCoins = 0;

     
        private double dx = 0, dy = 0; // NAPROV DVIJ
        private DispatcherTimer collisionFreezeTimer;

        public static double moveStep;
        public static double speed;
        private Dictionary<string, (double Left, double Top)> initialPositions;

        private bool toggleImage;
        private bool soundPlayed = false; 
        int QuantityOfHits=0;
        int Score = 2000;

        private Rect playerHitBox;
        private bool moveUp, moveDown, moveLeft, moveRight;
        private DispatcherTimer timer;

        private bool isColliding;
        private DispatcherTimer collisionTimer;
        private bool isFrozen = false;

        private DispatcherTimer movementTimer;
        private int pinkCubePointIndex = 0;
        private int yellowCubePointIndex = 0;
        private int orangeCubePointIndex = 0;
        private int blueCubePointIndex = 0;
        private int redCubePointIndex = 0;
        private List<Point> pinkCubePath;
        private List<Point> yellowCubePath;
        private List<Point> orangeCubePath;
        private List<Point> blueCubePath;
        private List<Point> redCubePath;
        private List<Rect> walls = new List<Rect>();

        private bool isImmune = false;
        private DispatcherTimer immunityTimer;
        private int immunityTimeLeft;

        private DispatcherTimer animationTimer;

        private string MoveUp;
        private string MoveDown;
        private string MoveLeft;
        private string MoveRight;

    
            public  Game()
        {
         
            InitializeComponent();
            InitializeTimers();
            InitializeWalls();
            InitializePathPoints();
            DataFile.Dificulty();
            InitializeAnimationTimer();
            Play();
        
      
        }

       
        private void Play()
        {
            if (Settings.MusicSound)
            {
               
                GameSounds.PlayBackgroundMusic();
            }

        }
            private void InitializeAnimationTimer()
            {
            animationTimer = new DispatcherTimer(); 
            animationTimer.Interval = TimeSpan.FromMilliseconds(150); 
            animationTimer.Tick += Animate; 
            animationTimer.Start();
            
            ImageBrush RedImage = new ImageBrush();
            RedImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/gosts/red.png"));
            RedCube.Fill = RedImage;

            ImageBrush BlueImage = new ImageBrush();
            BlueImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/gosts/blue.png"));
            BlueCube.Fill = BlueImage;

            ImageBrush YellowImage = new ImageBrush();
            YellowImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/gosts/pink.png"));
            YellowCube.Fill =YellowImage;

            ImageBrush OrangeImage = new ImageBrush();
            OrangeImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/gosts/orange.png"));
            OrangeCube.Fill = OrangeImage;

            ImageBrush PinkImage = new ImageBrush();
            PinkImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/gosts/Yellow.png"));
            PinkCube.Fill = PinkImage;
            ImageBrush Special = new ImageBrush();
            Special.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/addition/coconat.png"));
            SpecialCoin.Fill = Special;
        }

          
        private void Animate(object sender, EventArgs e)
        {
            switch (DataFile.currentSkin)
            {
                case 0:
                    if (dy == 0 && dx == 0)
                    {
                        ChangeImage("pack://application:,,,/images/player/pacman-left.png", "pack://application:,,,/images/player/pacman-left.png");
                    }
                    if (dx < 0)
                    {
                        ChangeImage("pack://application:,,,/images/player/pacman-left.png",
                                    "pack://application:,,,/images/player/pacman-left1.png");
                    }
                    if (dx > 0)
                    {
                        
                        ChangeImage("C:\\Users\\Alice\\source\\repos\\Pacman\\Pacman\\images\\player\\pacman-right.png",
                                   "C:\\Users\\Alice\\source\\repos\\Pacman\\Pacman\\images\\player\\pacman-right1.png");
                    }
                    if (dy < 0)
                    {
                        ChangeImage("C:\\Users\\Alice\\source\\repos\\Pacman\\Pacman\\images\\player\\pacman-up.png",
                                    "C:\\Users\\Alice\\source\\repos\\Pacman\\Pacman\\images\\player\\pacman-up1.png");
                    }
                    if (dy > 0)
                    {
                        ChangeImage("pack://application:,,,/images/player/pacman-down.png",
                                   "pack://application:,,,/images/player/pacman-down1.png");
                    }
                    break;
                case 1:
                 
                    if (dy == 0 && dx == 0)
                    {
                        ChangeImage("pack://application:,,,/images/player/Dragon left.png", "pack://application:,,,/images/player/Dragon left.png");
                    }
                    if (dx < 0)
                    {
                        ChangeImage("pack://application:,,,/images/player/Dragon left.png",
                                    "pack://application:,,,/images/player/Dragon left1.png");
                    }
                    if (dx > 0)
                    {
                        ChangeImage("pack://application:,,,/images/player/Dragon right.png",
                                   "pack://application:,,,/images/player/Dragon right1.png");
                    }
                    if (dy < 0)
                    {
                        ChangeImage("pack://application:,,,/images/player/Dragon up.png",
                                    "pack://application:,,,/images/player/Dragon up1.png");
                    }
                    if (dy > 0)
                    {
                        ChangeImage("pack://application:,,,/images/player/Dragon down.png",
                           "pack://application:,,,/images/player/Dragon down1.png");
                    }
                    break;
                case 2:
                    if (dy == 0 && dx == 0)
                    {
                      
                        ChangeImage("pack://application:,,,/images/player/Frenchmanleft 1.png", "pack://application:,,,/images/player/Frenchmanleft 1.png");
                    }
                    if (dx < 0)
                    {
                      
                        ChangeImage("pack://application:,,,/images/player/Frenchmanleft 1.png", "pack://application:,,,/images/player/Frenchmanleft 1.1.png");
                    }
                        if (dx > 0)
                    {
                       
                        ChangeImage("pack://application:,,,/images/player/Frenchmanright 1.png", "pack://application:,,,/images/player/Frenchmanright 1.1.png");
                    }
                    if (dy < 0)
                    {
                        
                        ChangeImage("C:\\Users\\Alice\\source\\repos\\Pacman\\Pacman\\images\\player\\Frenchmanup 1.png",
                                    "C:\\Users\\Alice\\source\\repos\\Pacman\\Pacman\\images\\player\\Frenchmanup 1.1.png");
                    }
                    if (dy > 0)
                    {
                     
                        ChangeImage("pack://application:,,,/images/player/Frenchmandown 1.png",
                                   "pack://application:,,,/images/player/Frenchmandown 1.1.png");
                    }
                    break;
                case 3:
                    if (dy == 0 && dx == 0)
                    {

                        ChangeImage("pack://application:,,,/images/player/CatInBox(rl).png", "pack://application:,,,/images/player/CatInBox(rl).png");
                    }
                    if (dx < 0)
                    {

                        ChangeImage("pack://application:,,,/images/player/CatInBox(rl).png", "pack://application:,,,/images/player/CatInBox(rl).png");
                    }
                    if (dx > 0)
                    {

                        ChangeImage("pack://application:,,,/images/player/CatInBox(rl).png", "pack://application:,,,/images/player/CatInBox(rl).png");
                    }
                    if (dy < 0)
                    {

                        ChangeImage("C:\\Users\\Alice\\source\\repos\\Pacman\\Pacman\\images\\player\\CatInBox(u).png",
                                    "C:\\Users\\Alice\\source\\repos\\Pacman\\Pacman\\images\\player\\CatInBox(u).png");
                    }
                    if (dy > 0)
                    {

                        ChangeImage("pack://application:,,,/images/player/CatInBox(d).png",
                                   "pack://application:,,,/images/player/CatInBox(d).png");
                    }
                    break;
            }
        }

        private void ChangeImage(string imagePath1, string imagePath2)
        {
            string selectedImagePath = toggleImage ? imagePath1 : imagePath2;
            ImageBrush PacmanImage = new ImageBrush();
            PacmanImage.ImageSource = new BitmapImage(new Uri(selectedImagePath));
            Player.Fill = PacmanImage;
            toggleImage = !toggleImage;
        }
    
    private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W: dx = 0; dy = -moveStep; break; // Вверх
                case Key.S: dx = 0; dy = moveStep; break; // Вниз
                case Key.A: dx = -moveStep; dy = 0; break; // Влево
                case Key.D: dx = moveStep; dy = 0; break; // Вправоs

            }
            if (e.Key == Key.Escape)
            {
                timer.Stop();
                movementTimer.Stop();
                
                ExitScreed.Visibility = Visibility.Visible;   
            }
        }




        private void InitializeTimers()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(15);
            timer.Tick += Timer_Tick;

            movementTimer = new DispatcherTimer();
            movementTimer.Interval = TimeSpan.FromMilliseconds(60);
            movementTimer.Tick += MovementTimer_Tick;

            timer.Start();
            movementTimer.Start();
            KeyDown += OnKeyDown;
            KeyDown += OnKeyDownExit;
            KeyDown += Restart;


            movementTimer = new DispatcherTimer();
            movementTimer.Interval = TimeSpan.FromMilliseconds(1);
            movementTimer.Tick += MovementTimer_Tick;
            movementTimer.Start();
        }

        private void MovementTimer_Tick(object sender, EventArgs e)
        {
            // NEW POSITION OF
            MoveCube(PinkCube, ref pinkCubePointIndex, pinkCubePath, speed);
            MoveCube(YellowCube, ref yellowCubePointIndex, yellowCubePath, speed);
            MoveCube(BlueCube, ref blueCubePointIndex, blueCubePath, speed);
            MoveCube(OrangeCube, ref orangeCubePointIndex, orangeCubePath, speed);
            MoveCube(RedCube, ref redCubePointIndex, redCubePath, speed);

            // STUCK VIA PLAUER
            CheckCollisionWithPlayer(PinkCube);
            CheckCollisionWithPlayer(YellowCube);
            CheckCollisionWithPlayer(OrangeCube);
            CheckCollisionWithPlayer(BlueCube);
            CheckCollisionWithPlayer(RedCube);
        }
        int i = 0;
        private void HandleSpecialCoinCollision(FrameworkElement specialCoin)
        {
            if (specialCoin.Visibility == Visibility.Visible)
            {
                specialCoin.Visibility = Visibility.Hidden;
                StartImmunity();
              
                GameSounds.PlaySpecialCoinSound(); 

            }
        }


        private void StartImmunity()
        {
            isImmune = true;
            immunityTimeLeft = 20;
            ImmunityTimerText.Visibility = Visibility.Visible;
            ImmunityTimerText.Text = $"Неуязвимость: {immunityTimeLeft} секунд";
          
            immunityTimer = new DispatcherTimer();
            immunityTimer.Interval = TimeSpan.FromSeconds(1);
            immunityTimer.Tick += ImmunityTimer_Tick;
            immunityTimer.Start();
        }

        private void ImmunityTimer_Tick(object sender, EventArgs e)
        {
            immunityTimeLeft--;

            if (immunityTimeLeft > 0)
            {
               
                ImmunityTimerText.Text = $"Неуязвимость: {immunityTimeLeft} секунд";
            }
            else
            {
                immunityTimer.Stop();
                isImmune = false;
                ImmunityTimerText.Visibility = Visibility.Collapsed;
            }
        }

        private void CheckCollisionWithPlayer(Rectangle cube)
        {
            Rect cubeRect = new Rect(Canvas.GetLeft(cube), Canvas.GetTop(cube), cube.Width, cube.Height);
            Rect playerRect = new Rect(Canvas.GetLeft(Player), Canvas.GetTop(Player), Player.Width, Player.Height);

            if (cubeRect.IntersectsWith(playerRect) && !isImmune && i < 1)
            {
                GameOver();
                i++;
            }
        }



        private void MoveCube(Rectangle cube, ref int pointIndex, List<Point> path,double speed)
        {
            Point currentPoint = new Point(Canvas.GetLeft(cube), Canvas.GetTop(cube));
            Point nextPoint = path[(pointIndex + 1) % path.Count];

            double distance = Distance(currentPoint, nextPoint);
            

            if (distance > speed)
            {
                Point direction = new Point((nextPoint.X - currentPoint.X) / distance, (nextPoint.Y - currentPoint.Y) / distance);
                SetCubePosition(cube, new Point(currentPoint.X + direction.X * speed, currentPoint.Y + direction.Y * speed));
            }
            else
            {
                pointIndex = (pointIndex + 1) % path.Count;
                SetCubePosition(cube, nextPoint);
            }
        }

        private double Distance(Point p1, Point p2)
        {
            return Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }

        private void SetCubePosition(Rectangle cube, Point point)
        {
            Canvas.SetLeft(cube, point.X);
            Canvas.SetTop(cube, point.Y);
        }
        private void InitializePathPoints()
        {

            pinkCubePath = new List<Point>
    {
        new Point(160, 110),
        new Point(160,50),
        new Point(360,50),
        new Point(360,100),
        new Point(560,103),
        new Point(560,50),
        new Point(760,50),
        new Point(760,103),
        new Point(960,103),
        new Point(960,50),
        new Point(960, 50),
        new Point(760, 50),
        new Point(760, 113),
        new Point(560, 50),
        new Point(560, 113),
        new Point(360, 113),
        new Point(360, 50),
        new Point(160, 50),
        new Point(160, 110),
    };
        yellowCubePath = new List<Point>
    {
        new Point(1218, 475),
        new Point(955, 475),
        new Point(955, 200),
        new Point(655, 200),
        new Point(675, 542),
        new Point(315, 542),
        new Point(315, 834),
        new Point(675, 834),
        new Point(655, 730),
        new Point(955, 730),
        new Point(975, 475)
    };

         orangeCubePath = new List<Point>
            {
          new Point(1472,183),
          new Point(1632,183 ),
          new Point(1632,257),
          new Point( 1675,257),
          new Point(1675,385),
          new Point(1492,405),
          new Point(1472,280),
          new Point(1240,280),
          new Point(1472,280),
          new Point(1472,183)

            };
            // BLUE CUBIC
            blueCubePath = new List<Point>
            {
                new Point(1458, 635),
                new Point(1686, 635),
                new Point(1686, 844),
                new Point(1458, 844),
                new Point(1458, 635),
                
            };

            // RED KUBIC
            redCubePath = new List<Point>
            {
                new Point(410, 185),
                new Point(410, 400),
                new Point(250, 400),
                new Point(250, 330),
                new Point(185, 330),
                 new Point(185, 185),
                  new Point(410, 185),

            };
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
                // FullScreen
                this.WindowStyle = WindowStyle.None;
                this.WindowState = WindowState.Maximized;
                // Work Plase
                var workingArea = SystemParameters.WorkArea;
                this.Left = workingArea.Left;
                this.Top = workingArea.Top;
                this.Width = workingArea.Width;
                this.Height = workingArea.Height;
          
            
            }


        private void HandleCollision()
        {
            //Back Player Position
            Canvas.SetLeft(Player, lastPosition.X);
            Canvas.SetTop(Player, lastPosition.Y);

            moveUp = moveDown = moveLeft = moveRight = false;
        }

        private void Timer_Tick(object sender, EventArgs e)
            {
                if (isFrozen) return;
                MovePlayer(dx, dy);

                playerHitBox = new Rect(Canvas.GetLeft(Player), Canvas.GetTop(Player), Player.Width, Player.Height);

                CheckCollisions();
            }
                  private void OnKeyDown(object sender, KeyEventArgs e)
                    {
                        if (e.Key == Key.Space && GameOverScreen.Visibility == Visibility.Visible)
                        {
                            RestartGame();
                        }
                    }
               private void OnKeyDownExit(object sender, KeyEventArgs e)
                {
                    if (e.Key == Key.F1 && ExitScreed.Visibility == Visibility.Visible)
                    {
                        GameSounds.StopMusic();
                speed = 0;
                moveStep = 0;
                timer.Stop();
                movementTimer.Stop();
                MainWindow Window = new MainWindow();
                this.Close();

                Window.WindowStyle = WindowStyle.None;
                Window.WindowState = WindowState.Maximized;
                var workingArea = SystemParameters.WorkArea;
                Window.Left = workingArea.Left;
                Window.Top = workingArea.Top;
                Window.Width = workingArea.Width;
                Window.Height = workingArea.Height;

                Window.Show();
                this.Close();
            }
                    if (e.Key == Key.F2 && ExitScreed.Visibility == Visibility.Visible)
                    {
              timer.Start();
                movementTimer.Start();
                ExitScreed.Visibility = Visibility.Hidden;
                    }
                }
               private void GameOver()
                    {
            GameSounds.StopMusic();
            timer.Stop();
            movementTimer.Stop();
            GameOverScreen.Visibility = Visibility.Visible;
            speed = 0;

                    GameSounds.PlayLoseSound();

                }

                private void GameWin()
                {
            if (Score > DataFile.HightScore)
            {
                DataFile.HightScore = Score;
            }
                    GameSounds.StopMusic();
                    movementTimer.Stop();
                    timer.Stop();
            speed = 0;
                    
            DataFile.wins = DataFile.wins + 1; ;

            DataFile.SaveGameData();
         

                    GameSounds.PlayWinSound();

                   GameWinScreen.Visibility = Visibility.Visible;
                }

        private void GameTable()
        {
            ScoreInformation.Text = $"SCORE:{Score} \nTOTAL COINS:{DataFile.countCoins}\nHITS:{QuantityOfHits}";
        }
        private void InitializeWalls()
            {
                foreach (var x in MyCanvas.Children.OfType<FrameworkElement>())
                {
                    if (x.Tag != null && (string)x.Tag == "wall")
                    {
                        walls.Add(new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height));
                    }
                }
            }
        private Point lastPosition;

        private void MovePlayer(double dx, double dy)
        {
            // Save Last position
            lastPosition = new Point(Canvas.GetLeft(Player), Canvas.GetTop(Player));

            Rect proposedHitBox = new Rect(lastPosition.X + dx, lastPosition.Y + dy, Player.Width, Player.Height);
            bool canMove = true;
            bool collisionOccurred = false;

            foreach (var wall in walls)
            {    
                if (proposedHitBox.IntersectsWith(wall))
                {
                    
                  
                    collisionOccurred = true;
                    if (!soundPlayed)
                    {
                        QuantityOfHits++;
                        DataFile.Hits++;
                        DataFile.SaveGameData();
                        Score = Score - (12 * QuantityOfHits);
                     
                       
                        GameSounds.PlayWallSound();
                        soundPlayed = true;
                    }
                    canMove = false;
                    break;
                }
            }

            if (canMove)
            {
                Canvas.SetLeft(Player, lastPosition.X + dx);
                Canvas.SetTop(Player, lastPosition.Y + dy);
                soundPlayed = false; 
            }
            else if (!collisionOccurred)
            {
                soundPlayed = false; 
            }
        }

       private void Restart(object sender, KeyEventArgs e)
            {
                if (e.Key == Key.Enter  && GameWinScreen.Visibility==Visibility.Visible)
                {
              
                RestartGame();
                
                }
            }
        private void RestartGame()
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                RestartApplication();
            DataFile.SaveGameData();
            }

        private void RestartApplication()
            {
                
            {   
                Game newGame = new Game();
                this.Close();
                newGame.Show();
                this.Close();
            }
        }
        private void CheckCollisions()
        {
            foreach (var x in MyCanvas.Children.OfType<FrameworkElement>())
            {
                if (x.Tag == null) continue;

                Rect hitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                if (playerHitBox.IntersectsWith(hitBox))
                {
                    switch (x.Tag)
                    {
                        case "coin":
                            HandleCoinCollision(x);
                            break;
                        case "specialCoin":
                            HandleSpecialCoinCollision(x);
                            break;
                        default:
                            if (x.Name.StartsWith("key"))
                            {
                                HandleKeyCollision(x);
                            }
                            else if (x.Name.StartsWith("door"))
                            {
                                HandleDoorCollision(x);
                            }
                            break;
                    }
                }
            }
        }


        private void HandleCoinCollision(FrameworkElement coin)
            {
                if (coin.Visibility == Visibility.Visible)
                {
                    coin.Visibility = Visibility.Hidden;
               
               DataFile.countCoins++;
                DataFile.SaveGameData();
                GameCountCoins++;
                
                    if (GameCountCoins == 100)
                {
                    GameTable();
                    GameWin();
                }
                    GameSounds.PlayCoinSound();
                }
            }

        private bool hasKey = false; // Переменная для хранения состояния ключа
        private void HandleKeyCollision(FrameworkElement key)
        {
            if (key.Visibility == Visibility.Visible)
            {
                GameSounds.PlayCoinSound();
                key.Visibility = Visibility.Hidden;
              ShowNotification("Door open.");
                
                hasKey = true; // Обновляем состояние ключа

                var door = MyCanvas.Children.OfType<FrameworkElement>().FirstOrDefault(y => y.Name.StartsWith("door"));
                if (door != null)
                {
                    door.Visibility = Visibility.Hidden;  
                }
            }
        }

        private void HandleDoorCollision(FrameworkElement door)
        {
            if (!hasKey)
            {
                HandleCollision();

            }

        }

        private void ShowNotification(string message)
        {
            NotificationText.Text = message;
            Notification.Visibility = Visibility.Visible;

            var notificationTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(3)
            };
            notificationTimer.Tick += (s, e) =>
            {
                Notification.Visibility = Visibility.Hidden;
                notificationTimer.Stop();
            };
            notificationTimer.Start();
        }

   

        private void FadeOutAnimation_Completed(object sender, EventArgs e)
        {
            this.Hide(); // Используем Hide() вместо Close() для сохранения состояния

            var newGame = new Game
            {
                Opacity = 0 // Устанавливаем начальную непрозрачность для нового окна
            };
            newGame.Show();
            StartFadeInAnimationForNewWindow(newGame);
        }

       
        private void StartFadeInAnimationForNewWindow(Window newGame)
        {
            DoubleAnimation fadeInAnimation = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(2));
            newGame.BeginAnimation(Window.OpacityProperty, fadeInAnimation);
        }
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
    }
    }
