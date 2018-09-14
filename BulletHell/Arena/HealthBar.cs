using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Arena
{
    public class HealthBar : UIElement
    {
        public void DrawUI(SpriteBatch spr)
        {
            const int WIDTH = 200;
            const int HEIGHT = 32;
            var bounds = new Rectangle(16, 16, WIDTH, HEIGHT);

            spr.Draw(Main.Pixel, bounds, Color.White);
        }
    }
}
