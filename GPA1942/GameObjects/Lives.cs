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
        protected const int START_LIVES = 3;
        protected int lives;

        protected const float LIVE_SPACING = 5;

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
                if (value < lives)
                {
                    for (int i = 0; i < lives - value; i++)
                    {
                        Remove(Children[Children.Count() - 1]);
                    }
                }
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
