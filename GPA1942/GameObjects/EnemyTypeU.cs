using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPA1942
{
    class EnemyTypeU : Enemy
    {
        private float xMovement,
            xSpeedAmpl = 300,
            xSpeed = 0.05f,
            xZigZag = 0;

        public EnemyTypeU() : base()
        {
            velocity.Y = velocity.Y / 1.5f;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            xZigZag += xSpeed;
            xMovement = xSpeedAmpl * (float)Math.Cos(xZigZag);

            velocity.X = xMovement;
        }
    }
}
