using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryClash
{
    class EnemyTypeU : Enemy
    {
        private const int ENEMYU_SCORE = 200;

        private float xSpeedAmpl = 300, //Defines the amplitude of the sinusoid
            xSpeed = 0.05f, //Defines how fast the enemy travels on the sinusoid
            xZigZag = 0;

        public EnemyTypeU() : base("EnemyU")
        {
            score = ENEMYU_SCORE;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            AngularDirection = Velocity;

            //This makes the enemy move in an U formation, using the sinusoid f(x) = a cos(x) for the x velocity of the enemy
            xZigZag += xSpeed;
            velocity.X = xSpeedAmpl * (float)Math.Cos(xZigZag);
        }
    }
}
