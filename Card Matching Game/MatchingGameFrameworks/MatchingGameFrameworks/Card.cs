/*
 * Brian Chaves
 * July 2013
 * Card Class
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BC_Functions;
using MatchingGameFrameworks.Exceptions;

namespace MatchingGameFrameworks
{
    public class Card
    {
        private int id;

        /// <summary>
        /// ID
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        private string imageLocation;

        /// <summary>
        /// Image Location
        /// </summary>
        public string ImageLocation
        {
            get { return imageLocation; }
            set { imageLocation = value; }
        }
        private bool flipped;

        /// <summary>
        /// card is fliped or not
        /// </summary>
        public bool Flipped
        {
            get
            {
                if (removed)
                {
                    return false;
                }
                return flipped;
            }
            set { flipped = value; }
        }

        private bool removed;

        /// <summary>
        /// card is removed
        /// </summary>
        public bool Removed
        {
            get
            {
                if(imageLocation=="N/A")
                {
                    return true;
                }
                return removed;
            }
            set { removed = value; }
        }

        public Card()
        {
            flipped = false;
            removed = false;
        }

        public Card(int id, string imageLocation)
        {
            this.id = id;
            this.imageLocation = imageLocation;
            flipped = false;
            removed = false;
        }

        public bool IsMatch(Card otherCard, bool throwCompareToSelfException = true)
        {
            if (otherCard == this)
            {
                if (throwCompareToSelfException)
                {
                    throw new CompareToSelfException();
                }
                else
                {
                    return false;
                }
            }

            if (this.ID == otherCard.ID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Flip()
        {
            flipped = !flipped;
        }

        public void Remove()
        {
            removed = true;
        }

        public void Reset()
        {
            flipped = false;
            removed = false;
        }
    }
}
