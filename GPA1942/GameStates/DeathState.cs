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
        private const int Y_TEXT_OFFSET = 100;

        const string SCORE_TEXT = "Score = ",
                     CONTINUE_TEXT = "Press Enter to continue",
                     DEATH_TEXT = "Game Over";

        TextGameObject scoreText,
                       deathText,
                       continueText;

        public DeathState() : base()
        {
            Add(scoreText = new TextGameObject("GameFont"));
            Add(deathText = new TextGameObject("GameFont"));
            Add(continueText = new TextGameObject("GameFont"));

            //Sets the text and position of the text objects
            deathText.Text = DEATH_TEXT;
            deathText.Origin = deathText.Size / 2;
            deathText.Position = new Vector2(GameEnvironment.Screen.X / 2, Y_TEXT_OFFSET);

            scoreText.Text = SCORE_TEXT;
            scoreText.Origin = scoreText.Size / 2;
            scoreText.Position = new Vector2(GameEnvironment.Screen.X / 2, Y_TEXT_OFFSET * 2);

            continueText.Text = CONTINUE_TEXT;
            continueText.Origin = continueText.Size / 2;
            continueText.Position = new Vector2(GameEnvironment.Screen.X / 2, Y_TEXT_OFFSET * 3);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            //Updates the shown score on the death screen by getting the score from the playingstate
            scoreText.Text = SCORE_TEXT + (GameEnvironment.GameStateManager.GetGameState("PlayingState") as PlayingState).theScore.GetScore;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            if (inputHelper.KeyPressed(Keys.Enter))
            {
                GameEnvironment.GameStateManager.SwitchTo("TitleScreen");
            }
        }
    }
}
