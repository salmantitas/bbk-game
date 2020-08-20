using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BC_Functions;

namespace BC_Functions
{
    public class PlayerScore
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get
            {
                if (name == "")
                {
                    return "Player " + id.ToString();
                }
                else
                {
                    return name;
                }
            }
            set { name = value; }
        }
        private int points;

        public virtual int Points
        {
            get { return points; }
            set
            {
                points = value;
                FixPoints();
            }
        }

        protected int BasePoints
        {
            get { return points; }
            set
            {
                points = value;
                FixPoints();
            }
        }

        private bool allowNegatives;

        public bool AllowNegatives
        {
            get { return allowNegatives; }
            set
            {
                allowNegatives = value;
                FixPoints();
            }
        }

        private void FixPoints()
        {
            if (!allowNegatives)
            {
                NumberFunction.SetMinimum(ref points, 0);
            }
        }

        public PlayerScore()
        {
            id = 1;
            allowNegatives = false;
        }

        public PlayerScore(int id)
        {
            this.id = id;
            allowNegatives = false;
        }

        public PlayerScore(int id, string name)
        {
            this.id = id;
            this.name = name;
            allowNegatives = false;
        }

        public void AddPoints(int points)
        {
            this.points += points;
        }

        public void LosePoints(int points)
        {
            Points -= points;
        }

        public virtual void ResetPoints()
        {
            points = 0;
        }

        public override string ToString()
        {
            return Name + ":" + points.ToString();
        }

    }
}
