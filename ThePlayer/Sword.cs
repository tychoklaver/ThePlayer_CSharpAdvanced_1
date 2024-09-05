namespace ThePlayer;

public class Sword : GameObject
{
    public bool IsPickedUp { get; private set; }
    public Sword(Texture2D pTexture) : base(pTexture)
    {
        Position = new Vector2(800, 550);
        IsPickedUp = false;
    }

    public override void Update(GameTime pGameTime, GraphicsDeviceManager pGraphics, ContentManager pContent, List<GameObject> pGameObjects)
    {
        base.Update(pGameTime, pGraphics, pContent, pGameObjects);
    }

    public void CheckCollision(Player pPlayer, ContentManager pContent)
    {
        if (!IsPickedUp && this.Rectangle.Intersects(pPlayer.Rectangle))
        {
            pPlayer.EquipSword(pContent);
            IsPickedUp = true;
        }
    }

    public override void Draw(GameTime pGameTime, SpriteBatch pSpriteBatch)
    {
        if (!IsPickedUp)
            base.Draw(pGameTime, pSpriteBatch);
    }
}
