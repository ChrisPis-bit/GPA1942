using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPA1942.GameObjects
{
    class BackGround : GameObjectList
    {
        const int START_OBJECT_AMOUNT = 10,
            OBJECT_SPAWN_CHANCE = 50;

        GameObjectList objects;

        public BackGround() : base()
        {
            Add(new SpriteGameObject("BackGround"));
            Add(objects = new GameObjectList());

            Reset();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if(GameEnvironment.Random.Next(0, OBJECT_SPAWN_CHANCE) == 0)
            {
                objects.Add(new BackgroundObject());
            }
        }

        public override void Reset()
        {
            base.Reset();

            objects.Children.Clear();

            for (int i = 0; i < START_OBJECT_AMOUNT; i++)
            {
                objects.Add(new BackgroundObject());
                BackgroundObject bgObject = objects.Children[i] as BackgroundObject;

                bgObject.Position = new Vector2(GameEnvironment.Random.Next(0 - (int)(bgObject.BoundingBox.Width * bgObject.size), GameEnvironment.Screen.X + (int)(bgObject.BoundingBox.Width * bgObject.size)),
                    GameEnvironment.Random.Next(0 - (int)(bgObject.BoundingBox.Height * bgObject.size), GameEnvironment.Screen.Y + (int)(bgObject.BoundingBox.Height * bgObject.size)));
                
            }
        }
    }
}
