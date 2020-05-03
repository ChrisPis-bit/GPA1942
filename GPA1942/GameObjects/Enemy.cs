using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryClash
{
    class Enemy : RotatingSpriteGameObject
    {
        protected Vector2 baseSpeed = new Vector2(0, 120); //Speed used for standard enemies
        private const int ENEMY_SCORE = 100; //Score the enemy gives when it is killed

        public int score;

        public Enemy(string assetName = "Enemy") : base(assetName)
        {
            Origin = new Vector2(Width / 2, Height / 2);
            offsetDegrees = 90; //Turns the enemy sprites 90 degrees, so they point in the right direction

            score = ENEMY_SCORE;

            //Places the enemy on a random place on the top of the screen 
            position = new Vector2(GameEnvironment.Random.Next(0, GameEnvironment.Screen.X - BoundingBox.Width), 0 - BoundingBox.Height);

            velocity = baseSpeed;
            AngularDirection = Velocity;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (GlobalPosition.Y - Origin.Y > GameEnvironment.Screen.Y) Visible = false;
        }
    }
}
