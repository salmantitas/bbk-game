using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BC_Functions
{
    public class PlayerScoreWithLife : PlayerScore
    {
        private int life;

        public int Life
        {
            get { return life; }
            set
            {
                life = value;
                NumberFunction.SetMinimum(ref life, 0);
            }
        }

        private int startingLife;

        public int StartingLife
        {
            get { return startingLife; }
            set { startingLife = value; }
        }

        private const int DEFALUT_NUMBER_OF_LIVES = 3;

        public PlayerScoreWithLife()
        {
            ID = 1;
            life = DEFALUT_NUMBER_OF_LIVES;
            startingLife = DEFALUT_NUMBER_OF_LIVES;
        }

        public PlayerScoreWithLife(string name, int life)
        {
            ID = 1;
            Name = name;
            this.life = life;
            startingLife = life;
        }

        public PlayerScoreWithLife(int id, string name, int life)
        {
            ID = id;
            Name = name;
            this.life = life;
            startingLife = life;
        }

        public void AddLife()
        {
            AddLife(1);
        }

        public void AddLife(int value)
        {
            life += value;
        }

        public virtual void LoseLife()
        {
            LoseLife(1);
        }

        public void LoseLife(int value)
        {
            life -= value;
            NumberFunction.SetMinimum(ref life, 0);
        }

        public override void ResetPoints()
        {
            life = startingLife;
            base.ResetPoints();
        }

        public bool GameOver
        {
            get
            {
                return (life <= 0);
            }
            set
            {
                if (value)
                {
                    life = 0;
                }
                else
                {
                    NumberFunction.SetMinimum(ref life, 1);
                }
            }
        }
    }
}
