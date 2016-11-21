using Pong.Commands;
using Pong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Pong.ViewModels
{
    internal class Singleplayer                   //Zoek betekenis internal op
    {
        private Ball ball;
        private Paddle paddle;
        private ScoreBoard scoreboard;
        private DispatcherTimer timer;
        private Vector z;
        private Canvas drawingarea;

        public Singleplayer(Canvas DrawingArea)   //Vind andere manier om DrawingArea mee te geven.
        {
            ball = new Ball();
            paddle = new Paddle();
            scoreboard = new ScoreBoard();

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            timer.IsEnabled = false;
            timer.Tick += timer_Tick;

            this.DrawingArea = DrawingArea;     //Workaround

            StartCommand = new StartCommand(this);
            StopCommand = new StopCommand(this);
            MoveLeftCommand = new MoveLeftCommand(this);
            MoveRightCommand = new MoveRightCommand(this);

            ResetGame();
        }


        #region GameLogic

        public void StartGame()
        {
            ResetGame();
            timer.Start();
            timer.IsEnabled = true;
        }

        public void StopGame()
        {
            timer.Stop();
            timer.IsEnabled = false;
        }

        public void MovePaddleLeft()
        {
            paddle.NotMoving = false;
            paddle.MoveLeft = true;
        }

        public void MovePaddleRight()
        {
            paddle.NotMoving = false;
            paddle.MoveLeft = false;
        }

        private void ResetGame()
        {
            scoreboard.Score = 0;

            ball.X = 50;
            ball.Y = 50;
            ball.Angle = 70;
            ball.Speed = 3;
            ball.Size = 10;

            paddle.Width = 60;
            paddle.Height = 10;
            paddle.Y = DrawingArea.ActualHeight - 10 - paddle.Height;
            paddle.X = DrawingArea.ActualWidth / 2 - paddle.Width / 2;
            paddle.Speed = 2;
            paddle.NotMoving = true;

            z = Convert.VectorConverter.AngleToVector(ball.Angle);
        }

        /// <summary>
        /// Checks for collisions between the ball and the paddle
        /// </summary>
        private bool CheckPadCollision()
        {
            bool result = ball.Y >= paddle.Y - 2 && ball.Y <= paddle.Y + 1 &&ball.X >= paddle.X && ball.X <= paddle.X + paddle.Width;
            return result;
        }

        /// <summary>
        /// Checks wether the ball collides with the paddle or walls and takes necessary actions
        /// </summary>
        private void CheckCollision()
        {
            if (ball.Y <= 0)
                z.Y = -z.Y;
            else if (ball.X <= 0 || ball.X >= DrawingArea.ActualWidth - ball.Size)
                z.X = -z.X;
            else if (CheckPadCollision())
            {
                z.Y = -z.Y;
                scoreboard.Score += 1;
            }
            else if (ball.Y > DrawingArea.ActualHeight)
                ResetGame();
        }

        /// <summary>
        /// Moves the ball in the direction specified by vector z with a speed set in ball.Speed
        /// </summary>
        private void MoveBall()
        {
            ball.X = ball.X + z.X * ball.Speed;
            ball.Y = ball.Y + z.Y * ball.Speed;
        }

        /// <summary>
        /// Moves the paddle in the direction specified by the player with a speed set in paddle.Speed
        /// </summary>
        private void MovePaddle()
        {
            if (!paddle.NotMoving)
            {
                if (paddle.MoveLeft && paddle.CanMoveLeft)
                    paddle.X -= paddle.Speed;
                else if (!paddle.MoveLeft && paddle.CanMoveRight)
                    paddle.X += paddle.Speed;
            }
        }

        /// <summary>
        /// Checks if the paddle is at its maxleft or maxright position and sets a bool CanMoveLeft or CanMoveRight
        /// </summary>
        private void ValidateMove()
        {
            if (paddle.X <= 0)
                paddle.CanMoveLeft = false;
            else 
                paddle.CanMoveLeft = true;

            if (paddle.X >= DrawingArea.ActualWidth - paddle.Width)
                paddle.CanMoveRight = false;
            else
                paddle.CanMoveRight = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            CheckCollision();
            MoveBall();

            ValidateMove();
            MovePaddle();
        }

        #endregion


        #region Properties

        public Ball Ball
        {
            get
            {
                return ball;
            }
        }

        public Paddle Paddle
        {
            get
            {
                return paddle;
            }
        }

        public ScoreBoard ScoreBoard
        {
            get
            {
                return scoreboard;
            }
        }

        public Canvas DrawingArea       //Workaround (betere oplossing?)
        {
            get
            {
                return drawingarea;
            }
            set
            {
                drawingarea = value;
            }
        }

        public ICommand StartCommand
        {
            get;
            private set;
        }

        public bool CanStart
        {
            get
            {
                if (timer.IsEnabled)
                    return false;
                return true;
            }
        }

        public ICommand StopCommand
        {
            get;
            private set;
        }

        public bool CanStop
        {
            get
            {
                if (timer.IsEnabled)
                    return true;
                return false;
            }
        }

        public ICommand MoveLeftCommand
        {
            get;
            private set;
        }

        public bool CanMoveLeft
        {
            get
            {
                    return true;
            }
        }

        public ICommand MoveRightCommand
        {
            get;
            private set;
        }

        public bool CanMoveRight
        {
            get
            {
                return true;
            }
        }

        #endregion
    }
}
