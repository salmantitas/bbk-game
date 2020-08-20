using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace BC_Functions
{
    public class Position2D
    {
        private int x;

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        private int y;

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public Position2D()
        {
            x = 0;
            x = 0;
        }

        public Position2D
            (int position)
        {
            x = position;
            y = position;
        }
        public Position2D
            (int x,
            int y)
        {
            this.x = x;
            this.y = y;
        }
        public Position2D(Position2D position)
        {
            this.x = position.x;
            this.y = position.y;
        }

        public virtual void SetPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return "(" + X.ToString() + "," + Y.ToString() + ")";
        }

        public virtual void SetPosition(int position)
        {
            x = position;
            y = position;
        }

        public virtual void SetPosition(Position2D position)
        {
            SetPosition(position.X, position.Y);
        }

        public virtual int Area
        {
            get
            {
                return x * y;
            }
        }
        
        public static implicit operator Position2D(Vector2 vector2)
        {
            return new Position2D((int)vector2.X,(int) vector2.Y);
        }

        public static explicit operator Vector2(Position2D position)
        {
            return new Vector2(position.x, position.y);
        }

        public static Position2D operator +(Position2D a, Position2D b)
        {
            return new Position2D(a.x + b.x, a.y + b.y);
        }

        public static Position2D operator -(Position2D a, Position2D b)
        {
            return new Position2D(a.x - b.x, a.y - b.y);
        }

        public static Position2D operator *(Position2D pos, int value)
        {
            return new Position2D(pos.x * value, pos.y * value);
        }
         
    }
}
