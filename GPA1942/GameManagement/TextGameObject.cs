using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class TextGameObject : GameObject
{
    protected SpriteFont spriteFont;
    protected Color color;
    protected string text;
    protected Vector2 origin;
    public float scale;

    public TextGameObject(string assetname, int layer = 0, string id = "")
        : base(layer, id)
    {
        spriteFont = GameEnvironment.AssetManager.Content.Load<SpriteFont>(assetname);
        color = Color.White;
        scale = 1;
        origin = Vector2.Zero;
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        if (visible)
        {
            spriteBatch.DrawString(spriteFont, text, GlobalPosition, color, 0, origin, scale, SpriteEffects.None, layer);
        }
    }

    public Color Color
    {
        get { return color; }
        set { color = value; }
    }

    public string Text
    {
        get { return text; }
        set { text = value; }
    }

    public Vector2 Size
    {
        get
        { return spriteFont.MeasureString(text); }
    }

    public Vector2 Origin
    {
        get { return origin; }
        set { origin = value; }
    }
}