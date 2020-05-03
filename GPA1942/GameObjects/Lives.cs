using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryClash.GameObjects
{
    class Lives : GameObjectList
    {
        private const int START_LIVES = 3;
        private int lives;

        private const float LIVE_SPACING = 5; //Space between each displayed live

        public Lives() : base()
        {
            Reset();

            Position = new Vector2(GameEnvironment.Screen.X - ((Children[0] as SpriteGameObject).Width + LIVE_SPACING), LIVE_SPACING);
        }

        public override void Reset()
        {
            base.Reset();

            Children.Clear();

            lives = START_LIVES;

            //Adds 3 player sprites to visualise the player lives
            for (int iLive = 0; iLive < START_LIVES; iLive++)
            {
                Add(new SpriteGameObject("Player"));
                Children[iLive].Position = new Vector2(0 - iLive * (LIVE_SPACING + (Children[iLive] as SpriteGameObject).Width), 0);
            }
        }

        public int LiveAmount
        {
            get { return lives; }
            set
            {
                //Removes a live if the new value is under the original value
                if (value < lives)
                {
                    for (int i = 0; i < lives - value; i++)
                    {
                        Remove(Children[Children.Count() - 1]);
                    }
                }

                //Adds a live if the new value is above the original value
                else if (value > lives)
                {
                    for (int i = 0; i < value - lives; i++)
                    {
                        Vector2 position = Children[Children.Count() - 1].Position - new Vector2(LIVE_SPACING + (Children[Children.Count() - 1] as SpriteGameObject).Width, 0);
                        Add(new SpriteGameObject("Player"));
                        Children[Children.Count() - 1].Position = new Vector2(0 - Children.Count() - 1 * (LIVE_SPACING + (Children[Children.Count() - 1] as SpriteGameObject).Width), 0);
                    }
                }

                lives = value;
            }
        }
    }
}
