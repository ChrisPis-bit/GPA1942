using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPA1942
{
    class Enemy : RotatingSpriteGameObject
    {
        //Speed used for normal enemies
        protected Vector2 baseSpeed = new Vector2(0, 40);

        public Enemy(Vector2 position, string assetName = "Enemy") : base(assetName)
        {
            this.position = position;
            velocity = baseSpeed;
        }
    }
}
