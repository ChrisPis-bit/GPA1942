using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryClash.GameObjects
{
    class ShootingEnemy : Enemy
    {
        const float ACCELERATION = 5,
                    MAX_SPEED = 100;
        const int SHOOTING_FREQ = 100,
            ENEMYS_SCORE = 250;

        private int frameCounter;
        public bool fireBullet;  
        Vector2 acceleration;

        public ShootingEnemy() : base("EnemyS")
        {
            score = ENEMYS_SCORE;
            frameCounter = 0;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            frameCounter++;

            if (frameCounter % SHOOTING_FREQ == 0)
            {
                fireBullet = true;
            }
            else
                fireBullet = false;

            //Makes sure the enemy doesn't go above the max speed by clamping the vector x and y
            Velocity = new Vector2(MathHelper.Clamp(velocity.X, -MAX_SPEED, MAX_SPEED),
                MathHelper.Clamp(velocity.Y, -MAX_SPEED, MAX_SPEED));

            acceleration = AngularDirection * ACCELERATION;

            Velocity += acceleration;
        }

        public void FollowObject(SpriteGameObject following)
        {
            AngularDirection = following.GlobalPosition - GlobalPosition;
        }
    }
}
