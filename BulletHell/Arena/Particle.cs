using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Arena
{
    public struct Particle
    {
        public static Dictionary<ushort, Color> ColourMap = new Dictionary<ushort, Color>();
        public static Dictionary<Color, ushort> IDMap = new Dictionary<Color, ushort>();
        private static ushort maxID;

        public float X, Y;
        public float Xvel, Yvel;
        public ushort ColourID { get; private set; }
        public Color Colour
        {
            get
            {
                return ColourMap[ColourID];
            }
        }

        public Particle(float x, float y, float xv, float yv, Color colour)
        {
            this.X = x;
            this.Y = y;
            this.Xvel = xv;
            this.Yvel = yv;

            if (IDMap.ContainsKey(colour))
            {
                ColourID = IDMap[colour];
            }
            else
            {
                ColourID = maxID++;
                IDMap.Add(colour, ColourID);
                ColourMap.Add(ColourID, colour);
            }
        }
    }
}
