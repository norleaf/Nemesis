using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprites;
using BoardGraph;
using NemesisMonoUI;
using MonoGameLib;
using TestModule;

namespace NemesisGame
{
    

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameNemesis : Game
    {
        GraphicsDeviceManager graphics;
        GraphicsBatch graphicsBatch;
        private List<SpriteGroup> sprites;
        Board board;

        private InputController inputController;


        public GameNemesis()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.HardwareModeSwitch = false;
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.ToggleFullScreen();
            Content.RootDirectory = "Content";
            var test = new PlayerTest();
            board = test.TestTwo();

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
            this.IsMouseVisible = true;
            sprites = new List<SpriteGroup>();
            inputController = new InputController(sprites);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            graphicsBatch = new GraphicsBatch(GraphicsDevice);
            graphicsBatch.DefaultFont = Content.Load<SpriteFont>("defaultFont");
            graphicsBatch.Pixel = Content.Load<Texture2D>("pixel");
            ImageLoader.LoadImages(Content, sprites);
            

            // TODO: use this.Content to load your game content here
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



            inputController.Update();



            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            //   graphicsBatch.Begin(SpriteSortMode.BackToFront);
               graphicsBatch.Begin();

            board.Draw(graphicsBatch);
            board.DrawText(graphicsBatch);
            

            graphicsBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
