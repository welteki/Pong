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
        private PlayField playfield;
        private Ball ball;
        private Paddle paddle;
        private ScoreBoard scoreboard;
        private DispatcherTimer timer;
        private Vector z;

        public Singleplayer()   //Vind andere manier om DrawingArea mee te geven.
        {
            playfield = new PlayField();
            ball = new Ball();
            paddle = new Paddle();
            scoreboard = new ScoreBoard();

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            timer.IsEnabled = false;
            timer.Tick += timer_Tick;

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
            playfield.Height = 227;
            playfield.Width = 448;

            scoreboard.Score = 0;

            ball.X = 50;
            ball.Y = 50;
            ball.Angle = 70;
            ball.Speed = 3;
            ball.Size = 10;

            paddle.Width = 60;
            paddle.Height = 10;
            paddle.Y = playfield.Height - 10 - paddle.Height;
            paddle.X = playfield.Width / 2 - paddle.Width / 2;
            paddle.Speed = 2;
            paddle.NotMoving = true;

            z = Convert.VectorConverter.AngleToVector(ball.Angle);
        }

        /// <summary>
        /// Changes the angle af the ball when it collides with the Paddle
        /// </summary>
        //private void ChangeAngle()
        //{
        //    double angle = Convert.VectorConverter.VectorToAngle(z);

        //    double newAngle = angle + Math.PI / 4 * ((Paddle.X - Ball.X)/ 0.5 * Paddle.Width);
        //}

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
            else if (ball.X <= 0 || ball.X >= playfield.Width - ball.Size)
                z.X = -z.X;
            else if (CheckPadCollision())
            {
                z.Y = -z.Y;
                scoreboard.Score += 1;
            }
            else if (ball.Y > playfield.Height)
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

            if (paddle.X >= playfield.Width - paddle.Width)
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

        public PlayField Playfield
        {
            get
            {
                return playfield;
            }
        }

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
