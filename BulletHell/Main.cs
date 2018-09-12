using BulletHell.Arena;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BulletHell
{
    public class Main : Game
    {
        public static Texture2D Pixel;
        public static Color BackgroundColour = Color.Black;
        public static GraphicsDeviceManager Graphics;
        public static SpriteBatch SpriteBatch;

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

            // Add base components here...
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
            // Update all components.
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(BackgroundColour);

            SpriteBatch.Begin();

            // Draw all components.
            base.Draw(gameTime);

            SpriteBatch.End();
        }
    }
}
