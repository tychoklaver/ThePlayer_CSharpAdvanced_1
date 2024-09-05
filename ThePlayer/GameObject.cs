namespace ThePlayer;

public class GameObject : Component
{
    #region SpriteBatch Variables
    protected float _layer { get; set; }
    protected Vector2 _position;
    protected Vector2 _origin { get; set; }
    protected float _rotation { get; set; }
    protected Texture2D _texture { get; set; }
    protected Color _color { get; set; }
    #endregion

    #region Properties
    public float Layer
    {
        get => _layer;
        set => _layer = value;
    }

    public Vector2 Position
    {
        get => _position;
        set => _position = value;
    }

    public Vector2 Origin
    {
        get => _origin;
        set => _origin = value;
    }

    public float Rotation
    {
        get => _rotation;
        set => _rotation = value;
    }
    #endregion

    #region Rectangle
    public Rectangle Rectangle
    {
        get
        {   
            if (_texture != null)
                return new((int)Position.X - (int)Origin.X, (int)Position.Y - (int)Origin.Y, _texture.Width, _texture.Height);

            throw new Exception("Texture not found/invalid.");
        }
    }
    #endregion


    public GameObject(Texture2D pTexture)
    {
        _texture = pTexture;
        Origin = new(_texture.Width / 2, _texture.Height / 2);
        _color = Color.White;
    }

    public override void Update(GameTime pGameTime, GraphicsDeviceManager pGraphics, ContentManager pContent, List<GameObject> pGameObjects)
    {
        
    }

    public override void Draw(GameTime pGameTime, SpriteBatch pSpriteBatch)
    {
        if (_texture != null)
            pSpriteBatch.Draw(_texture, Position, null, _color, Rotation, Origin, 1f, SpriteEffects.None, Layer);
    }
}