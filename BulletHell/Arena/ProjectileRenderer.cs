using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Arena
{
    public class ProjectileRenderer : DrawableGameComponent
    {
        public List<IProjectile> Projectiles = new List<IProjectile>();

        public ProjectileRenderer(Game g) : base(g)
        {
            DrawOrder = Main.EXEC_ORDER_PROJECTILE;
        }
    }
}
