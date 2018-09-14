using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Arena
{
    public abstract class Projectile
    {
        public virtual bool DestroyUponHit { get; set; } = true;
        public virtual float Damage { get; set; } = 50f;
        public virtual bool Destroyed { get; set; } = false;

        public abstract Rectangle GetBounds();
        public abstract void Update();
        public abstract void Draw();

        public virtual bool Touching(Rectangle bounds)
        {
            return GetBounds().Intersects(bounds);
        }

        public virtual float ResolveCollisions(Rectangle bounds)
        {
            if (Touching(bounds))
            {
                // Flag as destroyed if applicable to this projectile.
                if (DestroyUponHit)
                {
                    Destroyed = true;
                }

                // Upon collision, note that it is before damage is dealt but after the projectile is destroyed (if applicable).
                UponCollision(bounds);

                // Give the damage value back..
                return Damage;
            }
            else
            {
                return 0f;
            }
        }

        public virtual void UponCollision(Rectangle playerBounds)
        {

        }
    }
}
