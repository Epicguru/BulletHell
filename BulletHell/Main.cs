using BulletHell.Arena;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BulletHell
{
    public class Main : Game
    {
        public const int EXEC_ORDER_PLAYER = 0;
        public const int EXEC_ORDER_TIME = -99;
        public const int EXEC_ORDER_INPUT = -100;

        public static Texture2D Pixel;
        public static Color BackgroundColour = Color.Black;
        public static GraphicsDeviceManager Graphics;
        public static SpriteBatch SpriteBatch;
        public static Camera Camera;

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
            base.Components.Add(new Player(this));

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
            Camera.UpdateMatrix(GraphicsDevice);

            GraphicsDevice.Clear(BackgroundColour);

            SpriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, Camera.GetMatrix());

            // Draw all components.
            base.Draw(gameTime);

            SpriteBatch.End();
        }
    }
}
