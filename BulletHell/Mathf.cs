using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell
{
    public static class Mathf
    {
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
    }
}
