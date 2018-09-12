using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell
{
    public static class Random
    {
        private static System.Random rand = new System.Random();

        public static Vector2 GetRandomDirection()
        {
            double angle = rand.NextDouble() * 360.0 * Mathf.DegToRad;

            double x = Math.Sin(angle);
            double y = Math.Cos(angle);

            return new Vector2((float)x, (float)y);
        }
    }
}
