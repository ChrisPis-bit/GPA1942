using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPA1942
{
    class Player : GameObjectList
    {
        float angle;

        const float ACCELERATION = 30,
            MAX_SPEED = 500,
            FRICTION = 0.90f,
            EYE_CENTER_DIST = 5;

        public SpriteGameObject playerBody;
        SpriteGameObject eyes;

        Vector2 centerPosEyes;

        public Player() : base()
        {
            Add(playerBody = new SpriteGameObject("Player"));
            Add(eyes = new SpriteGameObject("Eyes"));
            Reset();
        }

        public override void Reset()
        {
            base.Reset();
            Position = new Vector2(GameEnvironment.Screen.X / 2, GameEnvironment.Screen.Y - GameEnvironment.Screen.Y / 8);
            playerBody.Origin = new Vector2(playerBody.Width / 2, playerBody.Height / 2);

            centerPosEyes = new Vector2(eyes.Width / 2, eyes.Height / 2);
            eyes.Origin = centerPosEyes;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            //Makes sure player doesn't go above the max speed by clamping the vector x and y
            velocity = new Vector2(MathHelper.Clamp(velocity.X, -MAX_SPEED, MAX_SPEED),
                MathHelper.Clamp(velocity.Y, -MAX_SPEED, MAX_SPEED));

            //Makes sure player doesn't go out of the screen by clamping the vector x and y
            Position = new Vector2(MathHelper.Clamp(position.X, 0 + playerBody.Origin.X, GameEnvironment.Screen.X - playerBody.Sprite.Width + playerBody.Origin.X),
                MathHelper.Clamp(position.Y, 0 + playerBody.Origin.Y, GameEnvironment.Screen.Y - playerBody.Sprite.Height + playerBody.Origin.Y));

            //Slows player movement down
            velocity *= FRICTION;

            AngularDirection = velocity;

            //Makes the eyes look in the direction of the velocity
            eyes.Origin = centerPosEyes - AngularDirection * EYE_CENTER_DIST;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            if (inputHelper.IsKeyDown(Keys.Up))
            {
                velocity.Y -= ACCELERATION;
            }
            if (inputHelper.IsKeyDown(Keys.Down))
            {
                velocity.Y += ACCELERATION;
            }
            if (inputHelper.IsKeyDown(Keys.Right))
            {
                velocity.X += ACCELERATION;
            }
            if (inputHelper.IsKeyDown(Keys.Left))
            {
                velocity.X -= ACCELERATION;
            }
        }

        public float DirectionAngle
        {
            get { return (float)Math.Atan2(velocity.Y, velocity.X); }
        }

        //Used for the eyes
        public Vector2 AngularDirection
        {
            get
            {
                // calculate angular direction based on sprite angle 
                return new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
            }
            set
            {
                angle = (float)Math.Atan2(value.Y, value.X);
            }
        }
    }
}
