﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprites;
using BoardGraph;
using NemesisMonoUI;
using MonoGameLib;
using NemesisLibrary;

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
        BoardView boardView;

        private InputController inputController;


        public GameNemesis()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.HardwareModeSwitch = false;
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.ToggleFullScreen();
            Content.RootDirectory = "Content";


            board = new Setup().board;
            boardView = new BoardView(board,GraphicsDevice);

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            
            this.IsMouseVisible = true;
            sprites = new List<SpriteGroup>();
            inputController = new InputController(board);
            inputController.listener = boardView;
            inputController.cc.collidables.Add(boardView.roomView);
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
            graphicsBatch.DefaultFont = Content.Load<SpriteFont>("def");
            graphicsBatch.Pixel = Content.Load<Texture2D>("pixel");
            ImageLoader.LoadImages(Content, sprites);
            

            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            
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



            

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            //   graphicsBatch.Begin(SpriteSortMode.BackToFront);
               graphicsBatch.Begin();

            boardView.DrawGraphics(graphicsBatch);
            boardView.DrawText(graphicsBatch);
            

            graphicsBatch.End();
            

            base.Draw(gameTime);
        }
    }
}
