using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPA1942
{
    class Bullet : RotatingSpriteGameObject
    {
        protected const float SPEED = 300;

        public Bullet(Vector2 position, string assetName = "Bullet") : base(assetName)
        {
            offsetDegrees = 90;
            Origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
            this.position = position;
            velocity.Y = -SPEED;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (OutOfScreen)
            {
                Visible = false;
            }
        }
    }
}
