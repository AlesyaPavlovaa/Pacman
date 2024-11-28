using Pacman;
using System;
using System.Windows.Media;

namespace PACMAN
{
    public class GameSounds
    {
        public static bool AlreadyPlay = true;
        public static MediaPlayer backgroundMusicPlayer;
        private static MediaPlayer mediaPlayer = new MediaPlayer();


        public static void PlayCoinSound()
        {
            if (Settings.EffectSound)
                PlaySound("C:\\Users\\Alice\\source\\repos\\Pacman\\Pacman\\images\\Coin.mp3");
        }

        public static void PlayWallSound()
        {
            if (Settings.EffectSound)
                PlaySound("C:\\Users\\Alice\\source\\repos\\Pacman\\Pacman\\images\\Hit.mp3");
        }

        public static void PlayLoseSound()
        {
            if (Settings.EffectSound)
                PlaySound("C:\\Users\\Alice\\source\\repos\\Pacman\\Pacman\\images\\GameOver.mp3");
        }

        public static void PlayGameLoudSound()
        {
            if (Settings.EffectSound)
                PlaySound("C:\\Users\\Alice\\source\\repos\\Pacman\\Pacman\\images\\GameLound.mp3");
        }
        public static void PlaySpecialCoinSound()
        {
            if (Settings.EffectSound)
                PlaySound("C:\\Users\\Alice\\source\\repos\\Pacman\\Pacman\\images\\GameLoud.mp3");
        }
        public static void PlayButtonSound()
        {
            if (Settings.EffectSound)
                PlaySound("pC:\\Users\\Alice\\source\\repos\\Pacman\\Pacman\\images\\Button.mp3");
        }

        public static void PlayWinSound()
        {
            if (Settings.EffectSound)
                PlaySound("C:\\Users\\Alice\\source\\repos\\Pacman\\Pacman\\images\\Win.mp3");
        }

        public static void PlayBackgroundMusic()
        {
            if (Settings.MusicSound)
            {
                backgroundMusicPlayer = new MediaPlayer();
                backgroundMusicPlayer.Open(new Uri("C:\\Users\\Alice\\source\\repos\\Pacman\\Pacman\\images\\MusicMenu.mp3", UriKind.Absolute));
                backgroundMusicPlayer.MediaEnded += new EventHandler(Media_Ended);
                backgroundMusicPlayer.Play();
                AlreadyPlay = true;
            }
        }

        public static void Media_Ended(object sender, EventArgs e)
        {
            if (Settings.MusicSound)
            {
                backgroundMusicPlayer.Position = TimeSpan.Zero;
                backgroundMusicPlayer.Play();
            }
        }

        public static void StopMusic()
        {
            AlreadyPlay = false;
            backgroundMusicPlayer.Stop();
        }

        private static void PlaySound(string soundFile)
        {
         
                mediaPlayer.Open(new Uri(soundFile, UriKind.Absolute));
             
                mediaPlayer.Play();
            
        }
    }
}
