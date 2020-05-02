using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryClash
{
    class Score : TextGameObject
    {
        protected int score;

        public Score() : base("GameFont")
        {
            Reset();
        }

        public override void Reset()
        {
            base.Reset();

            GetScore = 0;
        }

        public int GetScore
        {
            get { return score; }
            set
            {
                score = value;
                text = "Score = " + score;
            }
        }
    }
}
