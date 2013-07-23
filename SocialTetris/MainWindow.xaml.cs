using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using SocialTetris.Controller; 

namespace SocialTetris
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer Timer;
        private Board myBoard; 

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
            myBoard = new Board(MainGrid);
            Timer.Start();
        }

        void GameTick(object sender, EventArgs e)
        {
            Score.Content = myBoard.getScore().ToString("000000000");
            Lines.Content = myBoard.getLines().ToString("000000000"); 

            myBoard.CurrTetraminoMovDown();
        }

        private void HandleKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
             
                if (Timer.IsEnabled)
                {
                    myBoard.CurrTetraminoMovLeft();
                }

                break;

                case Key.Right:

                if (Timer.IsEnabled)
                {
                    myBoard.CurrTetraminoMovRight();
                }

                break;

                case Key.Down:

                if (Timer.IsEnabled)
                {
                    myBoard.CurrTetraminoMovDown();
                }

                break;

                case Key.Up:

                if (Timer.IsEnabled)
                {
                    myBoard.CurrTetraminoMovRotate();
                }

                break; 

                case Key.F2:
                    GameStart();
                    break; 

                case Key.F3:
                GamePause(); 
                break; 

                break;

                default:
                break; 
            }
        }

        private void GamePause()
        {
            if (Timer.IsEnabled)
            {
                Timer.Stop();
            }

            else
            {
                Timer.Start();
            }
        }
    }
}
