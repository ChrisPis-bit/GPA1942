using GeometryClash;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPA1942.GameObjects
{
    class HealthDrop : Enemy
    {
        //This object will give health to the player on collision
        //It inherits from the Enemy class, because this object acts mostly the same, but has a different effect on collision
        private const float DROP_SPEED = 200;

        public HealthDrop() : base("Player")
        {
            velocity.Y = DROP_SPEED;
        }
    }
}
