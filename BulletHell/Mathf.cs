using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell
{
    public static class Mathf
    {
        public const float RadToDeg = (float)(180.0 / Math.PI);
        public const float DegToRad = (float)(Math.PI / 180.0);

        public static float Clamp(float value, float a, float b)
        {
            float min = Math.Min(a, b);
            float max = Math.Max(a, b);

            return ClampF(value, min, max);
        }

        public static float ClampF(float value, float min, float max)
        {
            if (value > max)
            {
                return max;
            }
            else if (value < min)
            {
                return min;
            }
            else
            {
                return value;
            }
        }

        public static float Clamp01(float value)
        {
            return ClampF(value, 0f, 1f);
        }

        public static float Min(params float[] values)
        {
            float min = float.MaxValue;
            foreach (var item in values)
            {
                if(item < min)
                {
                    min = item;
                }
            }

            return min;
        }

        public static float Max(params float[] values)
        {
            float max = float.MinValue;
            foreach (var item in values)
            {
                if (item > max)
                {
                    max = item;
                }
            }

            return max;
        }

        public static float Lerp(float a, float b, float p, bool clamp = false)
        {
            if (clamp)
            {
                p = Clamp01(p);
            }

            return a + (b - a) * p;
        }

        /// <summary>
        /// Gets the cosine of the angle 'r' where r is in degrees.
        /// </summary>
        /// <param name="r">The angle in degrees</param>
        /// <returns>The cosine of the angle.</returns>
        public static float Cos(float r)
        {
            return (float)Math.Cos(r * DegToRad);
        }

        /// <summary>
        /// Gets the sine of the angle 'r' where r is in degrees.
        /// </summary>
        /// <param name="r">The angle in degrees</param>
        /// <returns>The sine of the angle.</returns>
        public static float Sin(float r)
        {
            return (float)Math.Sin(r * DegToRad);
        }
    }
}
