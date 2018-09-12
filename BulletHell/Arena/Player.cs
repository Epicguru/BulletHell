using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Arena
{
    public class Player : DrawableGameComponent
    {
        public Vector2 Position;
        public int Width, Height;
        public Color Colour;

        private Rectangle dest;

        public Player(Game game) : base(game)
        {
            base.DrawOrder = 1;
        }

        public override void Initialize()
        {
            Width = 32;
            Height = 32;
            Colour = Color.LightSeaGreen;
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public Rectangle GetDrawPos()
        {
            dest.X = (int)(Position.X - Width / 2f);
            dest.Y = (int)(Position.Y - Height / 2f);
            dest.Width = Width;
            dest.Height = Height;

            return dest;
        }

        public override void Draw(GameTime gameTime)
        {
            var dest = GetDrawPos();
            Main.SpriteBatch.Draw(Main.Pixel, dest, this.Colour);
        }
    }
}
