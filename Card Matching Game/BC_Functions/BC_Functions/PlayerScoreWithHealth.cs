using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BC_Functions
{
    public class PlayerScoreWithHealth : PlayerScoreWithLife
    {
        private int health;

        public int Health
        {
            get { return health; }
            set
            {
                health = value;
                NumberFunction.SetBetween(ref health, 0, maxHealth);
            }
        }
        private int maxHealth;

        public int MaxHealth
        {
            get { return maxHealth; }
            set
            {
                maxHealth = value;
                NumberFunction.SetMaximum(ref health, maxHealth);
                NumberFunction.SetMaximum(ref startingHealth, maxHealth);
            }
        }
        private int startingHealth;

        public int StartingHealth
        {
            get 
            {
                if (maxHealthIsStartingHealth)
                {
                    return maxHealth;
                }
                else
                {
                    return startingHealth;
                }
            }
            set
            {
                startingHealth = value;
                NumberFunction.SetBetween(ref startingHealth, 0, maxHealth);
                maxHealthIsStartingHealth = false;
            }
        }

        private bool maxHealthIsStartingHealth;

        public bool MaxHealthIsStartingHealth
        {
            get { return maxHealthIsStartingHealth; }
            set { maxHealthIsStartingHealth = value; }
        }

        public bool IsDead
        {
            get
            {
                return health == 0;
            }
            set
            {
                if (value)
                {
                    health = 0;
                }
                else
                {
                    NumberFunction.SetMinimum(ref health, 1);
                }
            }
        }

        private const int DEFAULT_HEALTH = 100;
        private const int DEFALUT_NUMBER_OF_LIVES = 1;

        public PlayerScoreWithHealth()
        {
            this.health = DEFAULT_HEALTH;
            maxHealth = DEFAULT_HEALTH;
            startingHealth = 0;
            Life = DEFALUT_NUMBER_OF_LIVES;
            StartingLife = DEFALUT_NUMBER_OF_LIVES;
            maxHealthIsStartingHealth = true;
        }

        public PlayerScoreWithHealth(int health)
        {
            this.health = health;
            maxHealth = health;
            startingHealth = 0;
            Life = DEFALUT_NUMBER_OF_LIVES;
            StartingLife = DEFALUT_NUMBER_OF_LIVES;
            maxHealthIsStartingHealth = true;
        }

        public PlayerScoreWithHealth(int health, int life)
        {
            this.health = health;
            maxHealth = health;
            startingHealth = 0;
            Life = life;
            StartingLife = life;
            maxHealthIsStartingHealth = true;
        }

        public override void ResetPoints()
        {
            health = StartingHealth;
            base.ResetPoints();
        }
        public override void LoseLife()
        {
            base.LoseLife();
            health = StartingHealth;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public void Heal()
        {
            health = maxHealth;
        }

        public void Heal(int healValue)
        {
            Health += healValue;
        }

        public void ResetHealth()
        {
            health = startingHealth;
        }
    }
}
