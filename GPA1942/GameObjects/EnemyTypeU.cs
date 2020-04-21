﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPA1942
{
    class EnemyTypeU : Enemy
    {
        const int ENEMYU_SCORE = 200;

        private float xMovement,
            xSpeedAmpl = 300,
            xSpeed = 0.05f,
            xZigZag = 0;

        public EnemyTypeU() : base("EnemyU")
        {
            score = ENEMYU_SCORE;

            velocity.Y = velocity.Y / 1.5f;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            AngularDirection = Velocity;

            xZigZag += xSpeed;
            xMovement = xSpeedAmpl * (float)Math.Cos(xZigZag);

            velocity.X = xMovement;
        }
    }
}
