using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Arena
{
    public class ParticleRenderer : DrawableGameComponent
    {
        public List<Particle> Particles = new List<Particle>();

        public ParticleRenderer(Game game) : base(game)
        {
            DrawOrder = Main.EXEC_ORDER_PARTICLES;
        }

        public override void Update(GameTime gameTime)
        {
            var mp = Input.MouseWorldPosition;
            Vector2 vel = Random.GetRandomDirection() * 64f;
            Particles.Add(new Particle(mp.X, mp.Y, vel.X, vel.Y, Color.MediumPurple));

            float dt = Time.deltaTime;
            for (int i = 0; i < Particles.Count; i++)
            {
                var p = Particles[i];
                p.X += p.Xvel * dt;
                p.Y += p.Yvel * dt;
                Particles[i] = p;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            const int size = 2;
            Rectangle dest = new Rectangle();
            dest.Width = size;
            dest.Height = size;
            foreach (var p in Particles)
            {
                dest.X = (int)p.X;
                dest.Y = (int)p.Y;
                Main.SpriteBatch.Draw(Main.Pixel, dest, p.Colour);
            }
        }
    }
}
