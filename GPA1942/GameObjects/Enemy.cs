﻿using Microsoft.Xna.Framework;
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
        protected Vector2 baseSpeed = new Vector2(0, 80);
        const int ENEMY_SCORE = 100;

        public int score;

        public Enemy(string assetName = "Enemy") : base(assetName)
        {
            score = 100;

            position = new Vector2(GameEnvironment.Random.Next(0, GameEnvironment.Screen.X - BoundingBox.Width), 0 - BoundingBox.Height);
            velocity = baseSpeed;
        }
    }
}
