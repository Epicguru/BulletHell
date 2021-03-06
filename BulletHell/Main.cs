﻿using BulletHell.Arena;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace BulletHell
{
    public class Main : Game
    {
        public const int EXEC_ORDER_TITLE = 100;
        public const int EXEC_ORDER_HEALTH = 99;
        public const int EXEC_ORDER_BOUNDS = 50;
        public const int EXEC_ORDER_PROJECTILE = 99;
        public const int EXEC_ORDER_PLAYER = 0;
        public const int EXEC_ORDER_PARTICLES = -1;
        public const int EXEC_ORDER_TIME = -99;
        public const int EXEC_ORDER_INPUT = -100;

        public static Player Player;
        public static Texture2D Pixel;
        public static SpriteFont TitleFont;
        public static Color BackgroundColour = Color.Black;
        public static GraphicsDeviceManager Graphics;
        public static SpriteBatch SpriteBatch;
        public static Camera Camera;
        public static GameBoundaries Bounds;
        public static ProjectileManager Projectiles;
        public static ParticleManager Particles;
        public static CamShake CameraShake;

        public static List<UIElement> UIElements = new List<UIElement>();

        public static Vector2 CameraOffset { get; private set; } = Vector2.Zero;

        public Main()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // Start logging time.
            Log.StartTimeLog("Game Init");

            // Main class related settings, basic init.
            IsMouseVisible = true;
            Window.Title = "Bullet Hell";
            Window.AllowUserResizing = true;

            Camera = new Camera();

            // Add base components here...
            base.Components.Add(new Input(this));
            base.Components.Add(new Time(this));
            base.Components.Add(Player = new Player(this));
            base.Components.Add(new Title(this));
            base.Components.Add(Particles = new ParticleManager(this));
            base.Components.Add(Bounds = new GameBoundaries(this));
            base.Components.Add(Projectiles = new ProjectileManager(this));
            base.Components.Add(CameraShake = new CamShake(this));

            // UI Elements
            UIElements.Add(new HealthBar());

            // Initialize all components.
            base.Initialize();

            // End logging.
            Log.EndTimeLog();
        }

        protected override void LoadContent()
        {
            // Start logging time.
            Log.StartTimeLog("Game Load Content");

            // Create a new SpriteBatch, which can be used to draw textures.
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            // Load pixel texture.
            Pixel = Content.Load<Texture2D>("Pixel");

            // Load title font.
            TitleFont = Content.Load<SpriteFont>("Title");

            // End logging.
            Log.EndTimeLog();
        }

        protected override void UnloadContent()
        {
            // Unload non-content manager.
        }

        protected override void Update(GameTime gameTime)
        {
            // Update screen resolution...
            UpdateResolution();

            // Update all components.
            base.Update(gameTime);

            // Update camera offset.
            CameraOffset = Vector2.Lerp(CameraOffset, Player.Velocity * 0.2f, 5f * Time.deltaTime);
        }

        private void UpdateResolution()
        {
            // Normally, resizing window automatically changes resolution.
            // But, on windows 10 on my machine, pressing the maximize button does not make this happen, so the resolution is messed up.

            int cw = Window.ClientBounds.Width;
            int ch = Window.ClientBounds.Height;

            bool update = false;

            if(cw != Graphics.PreferredBackBufferWidth)
            {
                Graphics.PreferredBackBufferWidth = cw;
                update = true;
            }
            if(ch != Graphics.PreferredBackBufferHeight)
            {
                Graphics.PreferredBackBufferHeight = ch;
                update = true;
            }

            if (update)
            {
                Graphics.ApplyChanges();
                Log.Trace("Resized to {0}x{1} pixels.".Form(cw, ch));
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            // Update camera matrix.
            Camera.Position = Vector2.Zero + CameraOffset + CameraShake.CameraOffset;
            Camera.UpdateMatrix(GraphicsDevice);

            GraphicsDevice.Clear(BackgroundColour);

            SpriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, Camera.GetMatrix());

            // Draw all components.
            base.Draw(gameTime);

            SpriteBatch.End();

            // Draw UI elements.
            SpriteBatch.Begin();

            foreach(var ui in UIElements)
            {
                if(ui != null)
                {
                    ui.DrawUI(SpriteBatch);
                }
            }

            SpriteBatch.End();
        }
    }
}
