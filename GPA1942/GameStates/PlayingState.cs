using GeometryClash.GameObjects;
using GPA1942.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryClash
{
    class PlayingState : GameObjectList
    {
        private Player thePlayer;
        private Lives theLives;
        private BackGround backGround;
        private GeometryClashParticles theParticles;
        public Score theScore;

        private GameObjectList theEnemies,
            theBullets;

        //Chances of enemies spawning per frame
        private const int SPAWN_CHANCE_ENEMY = 50, //Cirkel enemy
                          SPAWN_CHANCE_U_ENEMY = 200, //Triangle enemy
                          SPAWN_CHANCE_S_ENEMY = 350, //Square enemy
                          SPAWN_HEALTH_DROP = 400; //Health drop

        private const float ENEMY_SPAWN_INCREASE = 0.0001f, //Defines how fast the enemy spawn chance increases
                            MAX_ENEMY_SPAWN_MULTIPLIER = 0.2f;

        private float enemySpawnMultiplier;

        public PlayingState() : base()
        {
            Add(backGround = new BackGround());

            Add(theParticles = new GeometryClashParticles());

            Add(theEnemies = new GameObjectList());
            Add(theBullets = new GameObjectList());

            Add(thePlayer = new Player());
            Add(theLives = new Lives());
            Add(theScore = new Score());

            Reset();
        }

        public override void Reset()
        {
            base.Reset();

            theEnemies.Children.Clear();
            theBullets.Children.Clear();

            enemySpawnMultiplier = 1;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            //Decreases the multiplier, so the enemy spawn chance increases
            enemySpawnMultiplier -= ENEMY_SPAWN_INCREASE;

            //Stops the decrease of the spawn multiplier once it reaches max difficulty
            if (enemySpawnMultiplier <= MAX_ENEMY_SPAWN_MULTIPLIER)
            {
                enemySpawnMultiplier = MAX_ENEMY_SPAWN_MULTIPLIER;
            }

            SpawnEnemies();

            //Handles all collision with bullets
            //The player collides with only EnemyBullets, and the enemies with only normal Bullets (from the player)
            foreach (Bullet bullet in theBullets.Children)
            {
                foreach (Enemy enemy in theEnemies.Children)
                {
                    //Makes enemy and bullet invisible and adds score when an enemy is hit
                    //If the object in enemies is an healthdrop, it won't disappear
                    if (enemy.CollidesWith(bullet) && !(bullet is EnemyBullet) && !(enemy is HealthDrop))
                    {
                        bullet.Visible = false;
                        enemy.Visible = false;
                        theScore.GetScore += enemy.score;
                        theParticles.SpawnEnemyParticles(enemy.GlobalPosition);
                    }
                }

                //Makes the enemy bullet invisible and removes health from the player
                if (thePlayer.playerBody.CollidesWith(bullet) && bullet is EnemyBullet)
                {
                    bullet.Visible = false;
                    theLives.LiveAmount--;
                    theParticles.SpawnPlayerParticles(thePlayer.GlobalPosition);
                }
            }


            //Handles enemy interactions with the playingstate
            //Makes the shooting enemy follow the player and shoot bullets
            //Handles collision with the player and enemies
            foreach (Enemy enemy in theEnemies.Children)
            {
                if (enemy is ShootingEnemy)
                {
                    //Adds an enemy bullet on the shooting enemy
                    if ((enemy as ShootingEnemy).fireBullet)
                        theBullets.Add(new EnemyBullet(enemy.GlobalPosition, enemy.AngularDirection));

                    //Makes the shooting enemy follow the player
                    (enemy as ShootingEnemy).FollowObject(thePlayer.playerBody);
                }

                //If an enemy collides with the player, health is removed and the enemy becomes invisible
                //If the enemy in the list is an healthdrop, it will increase the health instead
                if (enemy.CollidesWith(thePlayer.playerBody))
                {
                    if (enemy is HealthDrop)
                    {
                        theLives.LiveAmount++;
                        enemy.Visible = false;
                    }
                    else
                    {
                        theLives.LiveAmount--;
                        enemy.Visible = false;
                        theParticles.SpawnPlayerParticles(thePlayer.GlobalPosition);
                    }
                }
            }


            //The for loop removes bullets that have become invisible
            for (int iBullet = 0; iBullet < theBullets.Children.Count(); iBullet++)
            {
                if (!theBullets.Children[iBullet].Visible)
                {
                    theBullets.Children.RemoveAt(iBullet);
                    iBullet--;
                }
            }

            //The for loop removes enemies that have become invisible
            for (int iEnemy = 0; iEnemy < theEnemies.Children.Count(); iEnemy++)
            {
                if (!theEnemies.Children[iEnemy].Visible)
                {
                    theEnemies.Children.RemoveAt(iEnemy);
                    iEnemy--;
                }
            }


            //Once the player runs out of health, the game will switch to the death screen
            if (theLives.LiveAmount <= 0)
            {
                GameEnvironment.GameStateManager.SwitchTo("DeathState");
            }
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            //Shoots a bullet from the player position when space is pressed
            if (inputHelper.KeyPressed(Keys.Space))
            {
                theBullets.Add(new Bullet(thePlayer.GlobalPosition));
            }
        }

        //Spawns the enemies
        //Each frame there is a chance an certain enemy is spawned
        //This chance is defined with the constant floats SPAWN_CHANCE_ENEMY
        //The spawn chance increases when the constant floats decrease
        //Each frame the enemy spawn multiplier decreases, decreasing the spawn chance with it, making more enemies spawn further in the game
        public void SpawnEnemies()
        {
            if (GameEnvironment.Random.Next(0, (int)(SPAWN_CHANCE_ENEMY * enemySpawnMultiplier)) == 0)
            {
                theEnemies.Add(new Enemy());
            }

            if (GameEnvironment.Random.Next(0, (int)(SPAWN_CHANCE_U_ENEMY * enemySpawnMultiplier)) == 0)
            {
                theEnemies.Add(new EnemyTypeU());
            }

            if (GameEnvironment.Random.Next(0, (int)(SPAWN_CHANCE_S_ENEMY * enemySpawnMultiplier)) == 0)
            {
                theEnemies.Add(new ShootingEnemy());
            }

            //Spawn chance doesnt increase with the enemies
            if (GameEnvironment.Random.Next(0, (int)(SPAWN_HEALTH_DROP)) == 0)
            {
                theEnemies.Add(new HealthDrop());
            }
        }
    }
}
