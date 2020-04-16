using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPA1942
{
    class PlayingState : GameObjectList
    {
        Player thePlayer;

        GameObjectList theEnemies,
            theBullets;

        const int SPAWN_CHANCE_ENEMY = 100,
                  SPAWN_CHANCE_U_ENEMY = 500;

        public PlayingState() : base()
        {
            Add(new SpriteGameObject("BackGround"));

            Add(theEnemies = new GameObjectList());
            Add(theBullets = new GameObjectList());

            Add(thePlayer = new Player());
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            SpawnEnemies();

            foreach (Bullet bullet in theBullets.Children)
            {
                foreach (Enemy enemy in theEnemies.Children)
                {
                    if (enemy.CollidesWith(bullet))
                    {
                        bullet.Visible = false;
                        enemy.Visible = false;
                    }
                }

                if (bullet.OutOfScreen)
                {
                    bullet.Visible = false;
                }
            }

            for(int iBullet = 0; iBullet < theBullets.Children.Count(); iBullet++)
            {
                if (!theBullets.Children[iBullet].Visible)
                {
                    theBullets.Children.RemoveAt(iBullet);
                    iBullet--;
                }
            }
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            if (inputHelper.KeyPressed(Keys.Space))
            {
                theBullets.Add(new Bullet(thePlayer.GlobalPosition));
            }
        }

        //Spawns the enemies
        public void SpawnEnemies()
        {
            if(GameEnvironment.Random.Next(0, SPAWN_CHANCE_ENEMY) == 0)
            {
                theEnemies.Add(new Enemy());
            }

            if (GameEnvironment.Random.Next(0, SPAWN_CHANCE_U_ENEMY) == 0)
            {
                theEnemies.Add(new EnemyTypeU());
            }
        }
    }
}
