using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryClash
{
    class DeathState : GameObjectList
    {
        TextGameObject deathText;
        const string SCORE_TEXT = "Score = ";

        public DeathState() : base()
        {
            Add(deathText = new TextGameObject("GameFont"));
            deathText.Text = SCORE_TEXT;
            deathText.Position = new Vector2(GameEnvironment.Screen.X / 2, GameEnvironment.Screen.Y/8);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            deathText.Text = SCORE_TEXT + (GameEnvironment.GameStateManager.GetGameState("PlayingState") as PlayingState).theScore.GetScore;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            if (inputHelper.KeyPressed(Keys.Space))
            {
                Restart();
            }
        }

        public void Restart()
        {
            GameEnvironment.GameStateManager.GetGameState("PlayingState").Reset();
            GameEnvironment.GameStateManager.SwitchTo("PlayingState");
        }
    }
}
