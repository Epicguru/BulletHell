using BulletHell.Arena;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Projectiles
{
    public class CometProjectile : IProjectile
    {
        public Color Colour = Color.Red;
        public Vector2 Position;
        public Vector2 Velocity;
        public int Width = 16, Height = 16;

        public virtual Rectangle Bounds
        {
            get
            {
                _bounds.X = (int)Position.X;
                _bounds.Y = (int)Position.Y;
                _bounds.Width = Width;
                _bounds.Height = Height;

                return _bounds;
            }
        }
        private Rectangle _bounds;

        public void Update()
        {
            Position += Velocity * Time.deltaTime;
        }

        public void Draw()
        {
            Main.SpriteBatch.Draw(Main.Pixel, Bounds, Colour);
        }        
    }
}
