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

        const int MIN_TRANSPARENCY = 50,
            MAX_TRANSPARENCY = 150,
            MAX_COLOR_INTENSITY = 20,
            MAX_ROT_SPEED = 50,
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
            color = new Color(GameEnvironment.Random.Next(0, MAX_COLOR_INTENSITY),
                GameEnvironment.Random.Next(0, MAX_COLOR_INTENSITY),
                GameEnvironment.Random.Next(0, MAX_COLOR_INTENSITY),
                GameEnvironment.Random.Next(MIN_TRANSPARENCY, MAX_TRANSPARENCY));

            rotatingSpeed = (float)GameEnvironment.Random.Next(-MAX_ROT_SPEED, MAX_ROT_SPEED) / 100;

            size = (float)GameEnvironment.Random.Next(0 * 100, MAX_SIZE * 100) / 100;

            Position = new Vector2(GameEnvironment.Random.Next(0 - (int)(BoundingBox.Width * size), GameEnvironment.Screen.X + (int)(BoundingBox.Width * size)), 0 - BoundingBox.Height * size);

            velocity.Y = GameEnvironment.Random.Next(MIN_FALLSPEED, MAX_FALLSPEED);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Degrees += rotatingSpeed;

            if (BoundingBox.Y - MAX_SIZE * BoundingBox.Height > GameEnvironment.Screen.Y)
            {
                Visible = false;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (!visible || sprite == null)
                return;

            spriteBatch.Draw(sprite.Sprite, GlobalPosition, null, color, Angle - MathHelper.ToRadians(offsetDegrees), Origin, size, SpriteEffects.None, 0);
        }
    }
}
