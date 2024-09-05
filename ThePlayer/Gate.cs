namespace ThePlayer;

public class Gate : GameObject
{
    public Gate(Texture2D pTexture) : base(pTexture)
    {
        Position = new Vector2(1000, 100);
    }

    public void CheckCollision(Player pPlayer)
    {
        if (this.Rectangle.Intersects(pPlayer.Rectangle))
        {
            Environment.Exit(0);
        }
    }

    public override void Update(GameTime pGameTime, GraphicsDeviceManager pGraphics, ContentManager pContent, List<GameObject> pGameObjects)
    {
        base.Update(pGameTime, pGraphics, pContent, pGameObjects);
    }

    public override void Draw(GameTime pGameTime, SpriteBatch pSpriteBatch)
    {
        base.Draw(pGameTime, pSpriteBatch);
    }
}
