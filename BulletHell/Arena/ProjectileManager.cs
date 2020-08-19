using Microsoft.Xna.Framework;
using BulletHell.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Arena
{
    public class ProjectileManager : DrawableGameComponent
    {
        public List<Projectile> Projectiles = new List<Projectile>();
        private float timer;

        public ProjectileManager(Game g) : base(g)
        {
            DrawOrder = Main.EXEC_ORDER_PROJECTILE;
        }

        public override void Update(GameTime gameTime)
        {
            // Test projectile spawning and collision.
            timer += Time.deltaTime;
            if(timer > 0.4f)
            {
                var pos = new Vector2(Main.Bounds.Rect.X - 400, Main.Player.Position.Y + Main.Player.Height * 0.5f);
                var vel = new Vector2(600f, Random.Range(-150f, 150f));
                Projectiles.Add(new CometProjectile(pos, vel, true));
                timer = 0f;
            }
        
            var playerBounds = Main.Player.Bounds;

            Projectiles.RemoveAll(x => x.Destroyed);
            foreach (var p in Projectiles)
            {
                // Update the position, velocity, damage and stuff.
                p.Update();

                // Resolve collision with the new position of the projectile.
                float damage = p.ResolveCollisions(playerBounds);

                // TODO deal damage.
                if(damage > 0f)
                {
                    Log.Warn("Ouch! You were hit for {0} hp!".Form(damage));
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (var p in Projectiles)
            {
                p.Draw();
            }
        }
    }
}
