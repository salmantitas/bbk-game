using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BC_Functions;
using MatchingGameFrameworks;

namespace MatchingGameFrameworks
{
    public class MatchingGamePlayerScore : PlayerScore
    {
        private decimal seconds;

        public decimal Seconds
        {
            get { return seconds; }
            set { seconds = value; }
        }

        private int misMatchCount;

        public int MisMatchCount
        {
            get { return misMatchCount; }
            set { misMatchCount = value; }
        }
        private int successfulMatchCount;

        public int SuccessfulMatchCount
        {
            get { return successfulMatchCount; }
            set { successfulMatchCount = value; }
        }

        private ScoreRule scoreRule;

        public ScoreRule ScoreRule
        {
            get { return scoreRule; }
            set { scoreRule = value; }
        }

        public MatchingGamePlayerScore()
        {
        }

        public MatchingGamePlayerScore(string name)
        {
            Name = name;
        }

        public MatchingGamePlayerScore(ScoreRule scoreRule)
        {
            this.scoreRule = scoreRule;
        }

        public MatchingGamePlayerScore(string name, ScoreRule scoreRule)
        {
            Name = name;
            this.scoreRule = scoreRule;
        }

        public override void ResetPoints()
        {
            seconds = 0;
            misMatchCount = 0;
            successfulMatchCount=0;
            BasePoints = 0;
        }

        public override int Points
        {
            get
            {
                return scoreRule.StartingPoints
                    + successfulMatchCount * scoreRule.SuccessfulMatchPointValue
                    - (int)(seconds * scoreRule.TimePenalty)
                    - misMatchCount * scoreRule.MisMatchPenalty 
                    + BasePoints;

            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
