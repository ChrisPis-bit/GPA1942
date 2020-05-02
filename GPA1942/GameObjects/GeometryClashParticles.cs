using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryClash
{
    //Inherits from particle object list
    //This class is used to have less constants in the playing state by putting all particle information in this class
    class GeometryClashParticles : ParticleObjectList
    {
        //Particle constants
        protected const int ENEMY_PARTICLE_AMOUNT = 30,
                            ENEMY_PARTICLE_FADE_TIME = 40,
                            PLAYER_PARTICLE_AMOUNT = 10,
                            PLAYER_PARTICLE_FADE_TIME = 20;

        protected const float ENEMY_PARTICLE_SPEED = 100,
                              PLAYER_PARTICLE_SPEED = 100,
                              PLAYER_PARTICLE_GRAVITY = 10;

        protected const string ENEMY_PARTICLE_ASSETNAME = "EnemyDeathParticle",
                               PLAYER_PARTICLE_ASSETNAME = "PlayerHitParticle";

        public override void Reset()
        {
            base.Reset();

            Children.Clear();
        }

        //Spawns enemy death particles
        public void SpawnEnemyParticles(Vector2 position)
        {
            SpawnSpriteParticles(ENEMY_PARTICLE_ASSETNAME, position, new Vector2(ENEMY_PARTICLE_SPEED), ENEMY_PARTICLE_AMOUNT, ENEMY_PARTICLE_FADE_TIME);
        }

        //Spawns player hit particles
        public void SpawnPlayerParticles(Vector2 position)
        {
            SpawnSpriteParticles(PLAYER_PARTICLE_ASSETNAME, position, new Vector2(PLAYER_PARTICLE_SPEED), PLAYER_PARTICLE_AMOUNT, PLAYER_PARTICLE_FADE_TIME, PLAYER_PARTICLE_GRAVITY);
        }
    }
}
