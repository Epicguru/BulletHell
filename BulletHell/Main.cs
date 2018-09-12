using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BulletHell
{
    public class Main : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
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
            spriteBatch = new SpriteBatch(GraphicsDevice);

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
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
