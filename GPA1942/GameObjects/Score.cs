using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPA1942
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

            score = 0;
            text = "Score = " + score;
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
