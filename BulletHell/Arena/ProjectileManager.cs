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
        public List<IProjectile> Projectiles = new List<IProjectile>();

        public ProjectileManager(Game g) : base(g)
        {
            DrawOrder = Main.EXEC_ORDER_PROJECTILE;
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var p in Projectiles)
            {
                p.Update();
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
