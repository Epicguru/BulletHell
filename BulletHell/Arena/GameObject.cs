using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Arena
{
    public abstract class GameObject : DrawableGameComponent
    {
        public string Name { get; private set; }
        public Color Colour = Color.White;
        public Vector2 Position;
        public Vector2 Velocity;
        public int Width = 16, Height = 16;
        public bool Centered { get; set; } = false;

        public Rectangle Bounds
        {
            get
            {
                if (Centered)
                {
                    _bounds.X = (int)(Position.X - Width / 2f);
                    _bounds.Y = (int)(Position.Y - Height / 2f);
                    _bounds.Width = Width;
                    _bounds.Height = Height;
                }
                else
                {
                    _bounds.X = (int)(Position.X);
                    _bounds.Y = (int)(Position.Y);
                    _bounds.Width = Width;
                    _bounds.Height = Height;
                }
                
                return _bounds;
            }
        }
        private Rectangle _bounds;

        public GameObject(Game game, string name) : base(game)
        {
            this.Name = name;
        }

        public sealed override void Update(GameTime gameTime)
        {
            // New abstract update method, with no GameTime because I use my own Time class instead.
            this.Update();

            // Apply velocity to position.
            ApplyVelocity();

            // Late update.
            PostVelUpdate();
        }

        public sealed override void Draw(GameTime gameTime)
        {
            // Subclass draw...
            this.Draw(Main.SpriteBatch);            
        }

        public virtual void Update()
        {

        }

        public virtual void PostVelUpdate()
        {

        }

        public virtual void Draw(SpriteBatch spr)
        {
            // Default rendering.
            DoDefaultRender(Main.SpriteBatch);            
        }

        /// <summary>
        /// Adds velocity multiplied by delta time to position.
        /// </summary>
        public void ApplyVelocity()
        {
            Position += Velocity * Time.deltaTime;
        }

        public void DoDefaultRender(SpriteBatch spr)
        {
            spr.Draw(Main.Pixel, Bounds, this.Colour);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
