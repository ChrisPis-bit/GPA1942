using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryClash
{
    class EnemyBullet : Bullet
    {
        //The enemy bullets will be shot from shooting enemies and will have collision with the player
        //It uses the angular direction of the enemy(which always looks at the player) so it shoots towards the player
        public EnemyBullet(Vector2 position, Vector2 angularDirection) : base(position, "EnemyBullet")
        {
            AngularDirection = angularDirection;
            velocity = angularDirection * SPEED;
        }
    }
}
