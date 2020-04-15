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
        public Bullet(Vector2 position) : base("Bullet")
        {
            Origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
            this.position = position;
            velocity.Y = -500;
        }
    }
}
