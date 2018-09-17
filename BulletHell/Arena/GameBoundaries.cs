using BulletHell.Projectiles;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Arena
{
    public class GameBoundaries : DrawableGameComponent
    {
        public Rectangle Rect
        {
            get
            {
                _rect.X = (int)(Width * -0.5f);
                _rect.Y = (int)(Height * -0.5f);
                _rect.Width = Width;
                _rect.Height = Height;

                return _rect;
            }
        }
        private Rectangle _rect;

        public int Width, Height;

        public GameBoundaries(Game game) : base(game)
        {

        }

        public override void Initialize()
        {
            // 32 is the player size in pixels, just to make the units more understandable.
            Width = 32 * 30;
            Height = 32 * 30;
        }

        public override void Draw(GameTime gameTime)
        {
            var spr = Main.SpriteBatch;

            // Draw solid walls where the boundaries are...

            const int SIZE = 32;
            Color colour = Color.PaleVioletRed;

            Rectangle bounds = this.Rect;
            Rectangle r = new Rectangle();

            // Left
            r.X = bounds.X - SIZE;
            r.Y = bounds.Y - SIZE;
            r.Width = SIZE;
            r.Height = bounds.Height + SIZE * 2;
            spr.Draw(Main.Pixel, r, colour);

            // Right
            r.X = bounds.X + bounds.Width;
            r.Y = bounds.Y - SIZE;
            r.Width = SIZE;
            r.Height = bounds.Height + SIZE * 2;
            spr.Draw(Main.Pixel, r, colour);

            // Top
            r.X = bounds.X;
            r.Y = bounds.Y - SIZE;
            r.Width = bounds.Width;
            r.Height = SIZE;
            spr.Draw(Main.Pixel, r, colour);

            // Bottom
            r.X = bounds.X;
            r.Y = bounds.Y + bounds.Height;
            r.Width = bounds.Width;
            r.Height = SIZE;
            spr.Draw(Main.Pixel, r, colour);

            // EDIT - Could also just draw a box where the actualy playable bounds are, and then change the background colour when
            // the player approaches the boundaries, indicating that they will soon be out-of-bounds.
            // Probably an easier and more aesthetically pleasing solution, but this will do for now.
            // The boundaries are solid for now, so the player will not be able to go through them.
            // However projectiles will come from off-screen, out of world bounds.
        }
    }
}
