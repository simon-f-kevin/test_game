using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game_Engine.Managers;
using Game_Engine.Systems;
using Game_Engine.Mediator;

namespace Studying
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D sprite;
        Texture2D bubbleSprite;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            GamePropertyManager.Instance.setGame(this);
            Mediator mediator = new Mediator();
            CollisionHandlingSystem collisionHandlingSystem = new CollisionHandlingSystem();
            mediator.reciever = collisionHandlingSystem;
            MovementSystem moveSystem = new MovementSystem();
            TextureRenderSystem textureRenderSystem = new TextureRenderSystem();
            CollisionDetectionSystem collisiondetection = new CollisionDetectionSystem(mediator);
            
            SystemManager.Instance().addToUpdateableQueue(moveSystem, collisiondetection);
            SystemManager.Instance().addToDrawableQueue(textureRenderSystem);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            sprite = Content.Load<Texture2D>(@"bunny2_ready");
            bubbleSprite = Content.Load<Texture2D>(@"bubble");
            int id = EntityManager.Instance.CreatePlayer(new Vector2(0, 0), new Vector2(0, 2), sprite);
            InputSystem input = new InputSystem(id);
            SystemManager.Instance().addToUpdateableQueue(input);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            SystemManager.Instance().Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            
            spriteBatch.Begin();
            SystemManager.Instance().Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
