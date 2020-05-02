using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class SpriteGameObject : GameObject
{
    protected SpriteSheet sprite;
    protected Vector2 origin;
    protected Color shade;
    public bool PerPixelCollisionDetection = true;

    public SpriteGameObject(string assetName, int layer = 0, string id = "", int sheetIndex = 0)
        : base(layer, id)
    {
        shade = Color.White;

        if (assetName != "")
        {
            sprite = new SpriteSheet(assetName, sheetIndex);
        }
        else
        {
            sprite = null;
        }
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        if (!visible || sprite == null)
        {
            return;
        }
        sprite.Draw(spriteBatch, this.GlobalPosition, origin, Shade);
    }

    public SpriteSheet Sprite
    {
        get { return sprite; }
    }

    public Color Shade
    {
        get { return shade; }
        set { shade = value; }
    }

    public Vector2 Center
    {
        get { return new Vector2(Width, Height) / 2; }
    }

    public int Width
    {
        get
        {
            return sprite.Width;
        }
    }

    public int Height
    {
        get
        {
            return sprite.Height;
        }
    }

    public bool Mirror
    {
        get { return sprite.Mirror; }
        set { sprite.Mirror = value; }
    }

    public Vector2 Origin
    {
        get { return origin; }
        set { origin = value; }
    }

    public override Rectangle BoundingBox
    {
        get
        {
            int left = (int)(GlobalPosition.X - origin.X);
            int top = (int)(GlobalPosition.Y - origin.Y);
            return new Rectangle(left, top, Width, Height);
        }
    }

    public bool CollidesWith(SpriteGameObject obj)
    {
        if (!visible || !obj.visible || !BoundingBox.Intersects(obj.BoundingBox))
        {
            return false;
        }
        if (!PerPixelCollisionDetection)
        {
            return true;
        }
        Rectangle b = Collision.Intersection(BoundingBox, obj.BoundingBox);
        for (int x = 0; x < b.Width; x++)
        {
            for (int y = 0; y < b.Height; y++)
            {
                int thisx = b.X - (int)(GlobalPosition.X - origin.X) + x;
                int thisy = b.Y - (int)(GlobalPosition.Y - origin.Y) + y;
                int objx = b.X - (int)(obj.GlobalPosition.X - obj.origin.X) + x;
                int objy = b.Y - (int)(obj.GlobalPosition.Y - obj.origin.Y) + y;
                if (sprite.IsTranslucent(thisx, thisy) && obj.sprite.IsTranslucent(objx, objy))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void WrapScreen()
    {
        if (Position.X > GameEnvironment.Screen.X)
        {
            position.X = 0 - sprite.Width;

        }
        else if (Position.X + sprite.Width < 0)
        {
            position.X = GameEnvironment.Screen.X;
        }

        if (Position.Y > GameEnvironment.Screen.Y)
        {
            position.Y = 0 - sprite.Height;

        }
        else if (Position.Y + sprite.Height < 0)
        {
            position.Y = GameEnvironment.Screen.Y;
        }
    }

    public bool OutOfScreen
    {
        get {
            return BoundingBox.X + BoundingBox.Width < 0 ||
              BoundingBox.X > GameEnvironment.Screen.X ||
              BoundingBox.Y + BoundingBox.Height < 0 ||
              BoundingBox.Y > GameEnvironment.Screen.Y;
        }
    }
}

