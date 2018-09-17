using Microsoft.Xna.Framework;
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

        public ProjectileManager(Game g) : base(g)
        {
            DrawOrder = Main.EXEC_ORDER_PROJECTILE;
        }

        public override void Update(GameTime gameTime)
        {
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
