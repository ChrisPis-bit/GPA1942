using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryClash.GameManagement
{
    class ParticleObject : SpriteGameObject
    {
        protected int fadeTime;

        protected float gravity;

        public ParticleObject(string assetname, Vector2 spawnPosition, Vector2 velocity, int fadeTime, float gravity = 0) : base(assetname)
        {
            this.fadeTime = fadeTime;
            this.gravity = gravity;

            Position = spawnPosition;
            Velocity = velocity;

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            fadeTime--;

            if (fadeTime < 0) Visible = false;

            velocity.Y += gravity;
        }
    }
}
