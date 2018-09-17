using BulletHell.Projectiles;
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
        private float timer;

        public ProjectileManager(Game g) : base(g)
        {
            DrawOrder = Main.EXEC_ORDER_PROJECTILE;
        }

        public override void Update(GameTime gameTime)
        {
            timer += Time.deltaTime;
            if(timer > 0.4f)
            {
                var pos = new Vector2(Main.Bounds.Rect.X - 400, Main.Player.Position.Y + Main.Player.Height * 0.5f);
                var vel = new Vector2(600f, Random.Range(-150f, 150f));
                Projectiles.Add(new CometProjectile(pos, vel, true));
                timer = 0f;
            }

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
