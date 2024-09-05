global using System;
global using System.Collections.Generic;
global using Microsoft.Xna.Framework.Content;
global using Microsoft.Xna.Framework;
global using Microsoft.Xna.Framework.Graphics;
global using Microsoft.Xna.Framework.Input;

namespace ThePlayer;

public class Game1 : Game
{
    #region Game Variables
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    #endregion

    #region Class Instances
    private Player _player;
    private Gate _gate;
    private Shield _shield;
    private Sword _sword;
    #endregion

    #region Screen Variables
    public static int ScreenWidth = 1280;
    public static int ScreenHeight = 720;
    #endregion

    private List<GameObject> _objects = new();

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _graphics.PreferredBackBufferWidth = ScreenWidth;
        _graphics.PreferredBackBufferHeight = ScreenHeight;
        _graphics.ApplyChanges();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        _player = new Player(Content.Load<Texture2D>("Knight"))
        {
            Input = new()
            {
                Up = Keys.W,
                Down = Keys.S,
                Left = Keys.A,
                Right = Keys.D,
            }
        };
        _gate = new Gate(Content.Load<Texture2D>("Gate"));
        _shield = new Shield(Content.Load<Texture2D>("Shield"));
        _sword = new Sword(Content.Load<Texture2D>("Weapon"));

        _objects.Add(_player);
        _objects.Add(_gate);
        _objects.Add(_shield);
        _objects.Add(_sword);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        for (int i = 0; i < _objects.Count; i++)
        {
            _objects[i].Update(gameTime, _graphics, Content, _objects);
        }

        _sword.CheckCollision(_player, Content);
        _shield.CheckCollision(_player, Content);
        _gate.CheckCollision(_player);

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime pGameTime)
    {
        GraphicsDevice.Clear(Color.MediumVioletRed);

        _spriteBatch.Begin(SpriteSortMode.FrontToBack);
        for (int i = 0; i < _objects.Count; i++)
        {
            _objects[i].Draw(pGameTime, _spriteBatch);
        }
        _spriteBatch.End();

        // TODO: Add your drawing code here

        base.Draw(pGameTime);
    }
}