using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatchingGameFrameworks
{
    public class ScoreRule
    {
        private int misMatchPenalty;

        public int MisMatchPenalty
        {
            get { return misMatchPenalty; }
            set { misMatchPenalty = value; }
        }
        private decimal timePenalty;

        public decimal TimePenalty
        {
            get { return timePenalty; }
            set { timePenalty = value; }
        }
        private int successfulMatchPointValue;

        public int SuccessfulMatchPointValue
        {
            get { return successfulMatchPointValue; }
            set { successfulMatchPointValue = value; }
        }

        private int startingPoints;

        public int StartingPoints
        {
            get { return startingPoints; }
            set { startingPoints = value; }
        }

        public ScoreRule()
        {
        }

        public ScoreRule(
            int startingPoints,
            int successfulMatchPointValue,
            int misMatchPenalty,
            decimal timePenalty)
        {
            this.startingPoints = startingPoints;
            this.successfulMatchPointValue = successfulMatchPointValue;
            this.misMatchPenalty = misMatchPenalty;
            this.timePenalty = timePenalty;
        }

        public ScoreRule(ScoreRule clone)
        {
            this.startingPoints = clone.startingPoints;
            this.successfulMatchPointValue = clone.successfulMatchPointValue;
            this.misMatchPenalty = clone.misMatchPenalty;
            this.timePenalty = clone.timePenalty;
        }
    }
}
