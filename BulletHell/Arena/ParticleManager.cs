using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Arena
{
    public class ParticleManager : DrawableGameComponent
    {
        private List<Particle> particles = new List<Particle>();

        public ParticleManager(Game game) : base(game)
        {
            DrawOrder = Main.EXEC_ORDER_PARTICLES;
        }

        public void AddParticle(Particle p)
        {
            particles.Add(p);
        }

        public override void Update(GameTime gameTime)
        {
            float dt = Time.deltaTime;
            for (int i = 0; i < particles.Count; i++)
            {
                var p = particles[i];
                p.X += p.Xvel * dt;
                p.Y += p.Yvel * dt;
                p.Time -= Time.deltaTime;
                particles[i] = p;
            }
            particles.RemoveAll(x => x.Time <= 0f);
        }

        public override void Draw(GameTime gameTime)
        {
            const int size = 2;
            Rectangle dest = new Rectangle();
            dest.Width = size;
            dest.Height = size;
            foreach (var p in particles)
            {
                dest.X = (int)p.X;
                dest.Y = (int)p.Y;
                Main.SpriteBatch.Draw(Main.Pixel, dest, p.Colour);
            }
        }
    }
}
