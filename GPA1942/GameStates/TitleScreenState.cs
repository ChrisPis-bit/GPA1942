using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPA1942
{
    class TitleScreenState : GameObjectList
    {
        private const int Y_TEXT_OFFSET = 100;

        private const string TITLE_TEXT = "GeometryClash",
                             CONTINUE_TEXT = "Press Enter to play";

        private TextGameObject title,
            continueText;

        public TitleScreenState() : base()
        {
            Add(title = new TextGameObject("GameFont"));
            Add(continueText = new TextGameObject("GameFont"));

            //Sets the text and position of the text objects
            title.Text = TITLE_TEXT;
            title.Position = new Vector2(GameEnvironment.Screen.X / 2, Y_TEXT_OFFSET);
            title.Origin = title.Size / 2;

            continueText.Text = CONTINUE_TEXT;
            continueText.Position = new Vector2(GameEnvironment.Screen.X / 2, Y_TEXT_OFFSET * 2);
            continueText.Origin = continueText.Size / 2;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            if (inputHelper.KeyPressed(Keys.Enter))
            {
                Restart();
            }
        }

        //Resets the playingstate
        public void Restart()
        {
            GameEnvironment.GameStateManager.GetGameState("PlayingState").Reset();
            GameEnvironment.GameStateManager.SwitchTo("PlayingState");
        }
    }
}
