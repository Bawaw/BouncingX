using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace BouncingX
{
    class Box
    {
        const int HEALTH = 100;
        const int DAMAGE = 10;

        private Point position;
        private Point velocity;
        private List<ConsoleColor> colors;
        private int character;
        private int health = HEALTH;

        # region properties
        public Point Position 
        { 
            get 
            { 
                return position; 
            } 
            set 
            { 
                position = value; 
            } 
        }

        public Point Velocity 
        {
            get 
            {
                return velocity; 
            }
            set 
            {
                velocity = value; 
            } 
        }

        public int Character
        {
            get
            {
                return character;
            }
            set
            {
                character = value;
            }
        }

        public int Health { get { return health; }}
        
        #endregion

        #region methods

        public void Initialize()
        { 
            colors = new List<ConsoleColor>();
            colors.Add(ConsoleColor.Red);
            colors.Add(ConsoleColor.Yellow);
            colors.Add(ConsoleColor.Green);
            colors.Add(ConsoleColor.White);
        }

        private void wallHitt()
        {
            TakeDamage();
        }
        public void TakeDamage()
        {
            if (health - DAMAGE > 0)
                health -= DAMAGE;

            else health = 0;

        }


        public void update()
        {
            position.X += velocity.X;
            position.Y += velocity.Y;

            checkWallCollision();
        }

       public void draw ()
       {
           float percent = (float)health / HEALTH;
           int ColorIndex = (int)(percent * colors.Count);
           ColorIndex = Math.Min(ColorIndex, colors.Count -1 );

           character = health;
           Console.ForegroundColor = colors[ColorIndex];

           Console.SetCursorPosition(position.X, position.Y);
           Console.Write(this.character);

       }
       
       private void checkWallCollision()
       {
           string convert = Health.ToString();
           int charWidth = convert.Length;

           if (Position.X < 0)
           {
               position.X = 0;
               velocity.X *= -1;
               wallHitt();
           }
           else if (position.X > Console.WindowWidth - charWidth)
           {
               position.X = Console.WindowWidth - charWidth;
               velocity.X *= -1;
               wallHitt();

           }

           if (Position.Y < 0)
           {
               position.Y = 0;
               velocity.Y *= -1;
               wallHitt();
           }
           else if (position.Y > Console.WindowHeight- 1)
           {
               position.Y = Console.WindowHeight - 1;
               velocity.Y *= -1;
               wallHitt();
           }
       }
       #endregion
    }
}
