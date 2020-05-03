using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeometryClash.GameObjects
{
    class BackgroundObject : RotatingSpriteGameObject
    {
        Color color;
        public float rotatingSpeed, size;

        private const int MIN_TRANSPARENCY = 50,
                          MAX_TRANSPARENCY = 150,
                          MAX_COLOR_INTENSITY = 20,
                          MAX_ROTATE_SPEED = 50,
                          MAX_SIZE = 12,
                          MAX_FALLSPEED = 200,
                          MIN_FALLSPEED = 50;

        public BackgroundObject() : base("BackgroundBase")
        {
            origin = Center;

            Reset();
        }

        public override void Reset()
        {
            base.Reset();

            //Randomizes a color for the object
            color = new Color(GameEnvironment.Random.Next(0, MAX_COLOR_INTENSITY),
                GameEnvironment.Random.Next(0, MAX_COLOR_INTENSITY),
                GameEnvironment.Random.Next(0, MAX_COLOR_INTENSITY),
                GameEnvironment.Random.Next(MIN_TRANSPARENCY, MAX_TRANSPARENCY));

            //Sets a random rotation speed
            rotatingSpeed = (float)GameEnvironment.Random.Next(-MAX_ROTATE_SPEED, MAX_ROTATE_SPEED) / 100;

            //Sets a random size
            size = (float)GameEnvironment.Random.Next(0 * 100, MAX_SIZE * 100) / 100;

            //Sets a random position on the top of the screen
            Position = new Vector2(GameEnvironment.Random.Next(0 - (int)(BoundingBox.Width * size), GameEnvironment.Screen.X + (int)(BoundingBox.Width * size)), 0 - BoundingBox.Height * size);

            //Sets a random falling speed
            velocity.Y = GameEnvironment.Random.Next(MIN_FALLSPEED, MAX_FALLSPEED);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Degrees += rotatingSpeed;

            //Makes the object invisible when it goes off screen, so it can be removed
            if (BoundingBox.Y - MAX_SIZE * BoundingBox.Height > GameEnvironment.Screen.Y)
            {
                Visible = false;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (!visible || sprite == null)
                return;

            //Uses a seperate draw so it can visualize different colors and sizes
            spriteBatch.Draw(sprite.Sprite, GlobalPosition, null, color, Angle - MathHelper.ToRadians(offsetDegrees), Origin, size, SpriteEffects.None, 0);
        }
    }
}
