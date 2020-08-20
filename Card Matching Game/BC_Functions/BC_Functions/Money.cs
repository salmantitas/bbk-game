using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BC_Functions
{
    public class Money
    {
        private int cents;

        internal protected int Cents
        {
            get { return cents; }
            set { cents = value; }
        }
        public decimal Dollars
        {
            get
            { 
                return cents / 100;
            }
            set 
            {
                if (value < 0 && !allowDept)
                {
                    throw new Exception();
                }
                cents = (int)(value * 100);
            }
        }

        private bool allowDept;

        public bool AllowDept
        {
            get { return allowDept; }
            set { allowDept = value; }
        }

        public Money(decimal dollars,bool allowDept = false)
        {
            Dollars = dollars;
            this.allowDept = allowDept;
        }

        public Money()
        {
            cents = 0;
            allowDept = false;
        }

        public Money(Money money)
        {
            cents = money.cents;
            allowDept = money.allowDept;
        }

        public void AddMoney(decimal dollars)
        {
            if (dollars < 0)
            {
                throw new Exception();
            }
            Dollars += dollars;
        }

        public void RemoveMoney(decimal dollars)
        {
            if (dollars > Dollars && !allowDept)
            {
                throw new Exception();
            }
            if (dollars < 0)
            {
                throw new Exception();
            }
            Dollars -= dollars;
        }

        public override string ToString()
        {
            if (cents >= 100)
            {
                return Dollars.ToString("c");
            }
            else
            {
                return cents.ToString() + "¢";
            }
        }
    }
}