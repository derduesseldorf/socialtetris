using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using SocialTetris.Controller;
using SocialTetris.Utils; 

namespace SocialTetris
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer Timer;
        private Board GameBoard;
        private Label GameOverLabel; 

        public MainWindow()
        {
            InitializeComponent();
        }

        void MainWindow_Initialized(object sender, EventArgs e)
        {
            Timer = new DispatcherTimer();
            Timer.Tick += new EventHandler(GameTick);
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 400);
            GameStart(); 
        }

        private void GameStart()
        {
            MainGrid.Children.Clear();
            GameBoard = new Board(MainGrid);
            if (GameStatsPanel.Children.Contains(GameOverLabel))
            {
                GameStatsPanel.Children.Remove(GameOverLabel);
            }

            Timer.Start();
        }

        void GameTick(object sender, EventArgs e)
        {
            Score.Content = GameBoard.getScore().ToString("000000000");
            Lines.Content = GameBoard.getLines().ToString("000000000"); 
            GameBoard.CurrTetraminoMovDown();
            CheckGameState();
        }

        private void CheckGameState()
        {
            if (GameBoard.GameOver())
            {
                GamePause();
                GameOverLabel = UiHelper.MakeLabel("Game Over", Brushes.DarkRed, Brushes.White, FontWeights.Bold, 24); 
                GameStatsPanel.Children.Add(GameOverLabel); 
            }
        }

        private void HandleKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:      if (Timer.IsEnabled) { GameBoard.CurrTetraminoMovLeft(); } break;
                case Key.Right:     if (Timer.IsEnabled) { GameBoard.CurrTetraminoMovRight(); } break;
                case Key.Down:      if (Timer.IsEnabled) { GameBoard.CurrTetraminoMovDown(); } break; 
                case Key.Up:        if (Timer.IsEnabled) { GameBoard.CurrTetraminoMovRotate(); } break; 
                case Key.F2:        GameStart(); break; 
                case Key.F3:        
                    if(!GameBoard.GameOver()) GamePause(); 
                    else GameStart();
                    break; 

                default: break; 
            }
        }

        private void GamePause()
        {
            if (Timer.IsEnabled) { Timer.Stop(); }
            else { Timer.Start(); }
        }
    }
}
