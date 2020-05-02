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
        public EnemyBullet(Vector2 position, Vector2 angularDirection) : base(position, "EnemyBullet")
        {
            AngularDirection = angularDirection;
            velocity = angularDirection * SPEED;
        }
    }
}
