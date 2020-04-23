using GPA1942.GameObjects;
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
        private Player thePlayer;
        private Lives theLives;
        public Score theScore;

        private GameObjectList theEnemies,
            theBullets;

        const int SPAWN_CHANCE_ENEMY = 100,
                  SPAWN_CHANCE_U_ENEMY = 400,
                  SPAWN_CHANCE_S_ENEMY = 700;

        public PlayingState() : base()
        {
            Add(new SpriteGameObject("BackGround"));

            Add(theEnemies = new GameObjectList());
            Add(theBullets = new GameObjectList());

            Add(thePlayer = new Player());
            Add(theLives = new Lives());
            Add(theScore = new Score());
        }

        public override void Reset()
        {
            base.Reset();

            theEnemies.Children.Clear();
            theBullets.Children.Clear();
            theScore.Reset();
            thePlayer.Reset();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            SpawnEnemies();

            foreach (Bullet bullet in theBullets.Children)
            {
                foreach (Enemy enemy in theEnemies.Children)
                {
                    if (enemy.CollidesWith(bullet) && !(bullet is EnemyBullet))
                    {
                        bullet.Visible = false;
                        enemy.Visible = false;

                        theScore.GetScore += enemy.score;
                    }
                }

                if (thePlayer.playerBody.CollidesWith(bullet) && bullet is EnemyBullet)
                {
                    bullet.Visible = false;
                    theLives.LiveAmount--;
                }
            }

            foreach (Enemy enemy in theEnemies.Children)
            {
                if (enemy is ShootingEnemy)
                {
                    if ((enemy as ShootingEnemy).fireBullet)
                        theBullets.Add(new EnemyBullet(enemy.GlobalPosition, enemy.AngularDirection));

                    (enemy as ShootingEnemy).FollowObject(thePlayer.playerBody);
                }

                if (enemy.CollidesWith(thePlayer.playerBody))
                {
                    theLives.LiveAmount--;
                    enemy.Visible = false;
                }
            }

            for (int iBullet = 0; iBullet < theBullets.Children.Count(); iBullet++)
            {
                if (!theBullets.Children[iBullet].Visible)
                {
                    theBullets.Children.RemoveAt(iBullet);
                    iBullet--;
                }
            }

            for (int iEnemy = 0; iEnemy < theEnemies.Children.Count(); iEnemy++)
            {
                if (!theEnemies.Children[iEnemy].Visible)
                {
                    theEnemies.Children.RemoveAt(iEnemy);
                    iEnemy--;
                }
            }

            if (theLives.LiveAmount <= 0)
            {
                GameEnvironment.GameStateManager.SwitchTo("DeathState");
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
            if (GameEnvironment.Random.Next(0, SPAWN_CHANCE_ENEMY) == 0)
            {
                theEnemies.Add(new Enemy());
            }

            if (GameEnvironment.Random.Next(0, SPAWN_CHANCE_U_ENEMY) == 0)
            {
                theEnemies.Add(new EnemyTypeU());
            }

            if (GameEnvironment.Random.Next(0, SPAWN_CHANCE_S_ENEMY) == 0)
            {
                theEnemies.Add(new ShootingEnemy());
            }
        }
    }
}
