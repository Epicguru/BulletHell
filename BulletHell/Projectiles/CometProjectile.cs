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
        public int Width = 8, Height = 8;

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

        public CometProjectile(Vector2 pos, Vector2 vel, bool center = true)
        {
            this.Position = pos;
            if (center)
            {
                pos.X -= Width * 0.5f;
                pos.Y -= Height * 0.5f;
            }

            this.Velocity = vel;
        }

        public void Update()
        {
            Position += Velocity * Time.deltaTime;

            // Spawn a particle.
            var rv = Random.GetRandomDirection() * Velocity.Length() * 0.05f;
            Main.Particles.AddParticle(new Particle(Position.X + Width / 2f, Position.Y + Height / 2f, rv.X, rv.Y, Colour, 2f));
        }

        public void Draw()
        {
            Main.SpriteBatch.Draw(Main.Pixel, Bounds, Colour);
        }        
    }
}
