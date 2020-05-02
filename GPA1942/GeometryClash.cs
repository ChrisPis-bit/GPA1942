using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GeometryClash
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GeometryClash : GameEnvironment
    {
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            base.LoadContent();
            screen = new Point(600, 800);
            ApplyResolutionSettings();

            // TODO: use this.Content to load your game content here
            GameStateManager.AddGameState("PlayingState", new PlayingState());
            GameStateManager.AddGameState("DeathState", new DeathState());

            GameStateManager.SwitchTo("PlayingState");
        }


    }
}
