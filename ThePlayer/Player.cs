namespace ThePlayer;

public class Player : GameObject
{
    #region Movement Variables
    private KeyboardState _currentKey;
    public Input Input { get; set; }
    private float _speed { get; set; }
    Vector2 _dir = Vector2.Zero;
    #endregion

    #region Interactable Bools
    public bool HasSword {  get; private set; }
    public bool HasShield { get; private set; }
    #endregion

    public Player(Texture2D pTexture) : base(pTexture)
    {
        Position = new Vector2(Game1.ScreenWidth / 2, Game1.ScreenHeight / 2);
        _speed = 300f;

        HasSword = false;
        HasSword = false;
    }

    public override void Update(GameTime pGameTime, GraphicsDeviceManager pGraphics, ContentManager pContent, List<GameObject> pGameObjects)
    {
        _currentKey = Keyboard.GetState();
        PlayerMovement(pGameTime);

        base.Update(pGameTime, pGraphics, pContent, pGameObjects);
    }

    #region Interactable Methods
    public void EquipShield(ContentManager pContent)
    {
        HasShield = true;
        UpdateSprite(pContent);
    }

    public void EquipSword(ContentManager pContent)
    {
        HasSword = true;
        UpdateSprite(pContent);
    }

    private void UpdateSprite(ContentManager pContent)
    {
        if (HasSword && HasShield)
            _texture = pContent.Load<Texture2D>("KnightWeaponShield");
        else if (HasSword)
            _texture = pContent.Load<Texture2D>("KnightWeapon");
        else if (HasShield)
            _texture = pContent.Load<Texture2D>("KnightShield");
    }
    #endregion

    private void PlayerMovement(GameTime pGameTime)
    {
        if (_currentKey.IsKeyDown(Input.Left))
            _dir.X -= 1;
        else if (_currentKey.IsKeyDown(Input.Right))
            _dir.X += 1;

        if (_currentKey.IsKeyDown(Input.Up))
            _dir.Y -= 1;
        else if (_currentKey.IsKeyDown(Input.Down))
            _dir.Y += 1;

        if (_dir != Vector2.Zero)
            _dir.Normalize();
        
        Position += _dir * _speed * (float)pGameTime.ElapsedGameTime.TotalSeconds;
        _dir = Vector2.Zero;
    }

    public override void Draw(GameTime pGameTime, SpriteBatch pSpriteBatch)
    {
        base.Draw(pGameTime, pSpriteBatch);
    }

}
