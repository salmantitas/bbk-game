using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace BC_Functions
{
    public class Position3D : Position2D
    {
        private int z;

        public int Z
        {
            get { return z; }
            set { z = value; }
        }

        public Position3D()
        {
            X = 0;
            Y = 0;
            z = 0;
        }
        public Position3D(int position)
        {
            X = position;
            Y = position;
            z = position;
        }

        public Position3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            this.z = z;
        }

        public Position3D(Position2D position)
        {
            SetPosition(position);
        }

        public virtual void SetPosition(int x, int y, int z)
        {
            X = x;
            Y = y;
            this.z = z;
        }

        public override void SetPosition(int x, int y)
        {
            base.SetPosition(x, y);
            z = 0;
        }
        public override string ToString()
        {
            return "(" + X.ToString() + "," + Y.ToString() +","+z.ToString()+ ")";
        }

        public override void SetPosition(int position)
        {
            X = position;
            Y = position;
            z = position;
        }

        public override void SetPosition(Position2D position)
        {
            X = position.X;
            Y = position.Y;
            if (position is Position3D)
            {
                Position3D position3D = (Position3D)position;
                this.z = position3D.z;
            }
            else
            {
                z = 0;
            }
        }

        public override int Area
        {
            get
            {
                return base.Area * z;
            }
        }

        public static implicit operator Position3D(Vector3 vector3)
        {
            return new Position3D((int)vector3.X, (int)vector3.Y,(int)vector3.Z);
        }

        public static implicit operator Position3D(Vector2 vector2)
        {
            return new Position3D((int)vector2.X, (int)vector2.Y, 0);
        }

        public static explicit operator Vector3(Position3D position)
        {
            return new Vector3(position.X, position.Y,position.z);
        }

        public static explicit operator Vector2(Position3D position)
        {
            return new Vector2(position.X, position.Y);
        }

        public static Position3D operator +(Position3D a, Position3D b)
        {
            return null;
        }

        public static Position3D operator -(Position3D a, Position3D b)
        {
            return null;
        }

        public static Position3D operator *(Position3D pos, int value)
        {
            return null;
        }
    }
}
