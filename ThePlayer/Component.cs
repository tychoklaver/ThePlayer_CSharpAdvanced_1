namespace ThePlayer;

public abstract class Component
{
    public abstract void Update(GameTime pGameTime, GraphicsDeviceManager pGraphics, ContentManager pContent, List<GameObject> pGameObjects);
    public abstract void Draw(GameTime pGameTime, SpriteBatch pSpriteBatch);
}