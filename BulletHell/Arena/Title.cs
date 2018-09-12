using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Arena
{
    public class Title : DrawableGameComponent
    {
        public Color Colour = Color.LawnGreen;
        public Vector2 Position;

        private StringBuilder str = new StringBuilder();
        private float timer;

        public Title(Game game) : base(game)
        {
            DrawOrder = Main.EXEC_ORDER_TITLE;
        }

        public override void Update(GameTime gameTime)
        {
            Position = Main.Camera.ScreenToWorldPosition(new Vector2(Main.Graphics.PreferredBackBufferWidth / 2f, 30f));
            timer += Time.unscaledDeltaTime;
        }

        public override void Draw(GameTime time)
        {
            var spr = Main.SpriteBatch;
            str.Clear();
            str.Append("-- Wave 0 --");

            float amplitude = 2f;
            float frequency = 6f;
            float rot = Mathf.Sin(timer * frequency * Mathf.RadToDeg) * amplitude * Mathf.DegToRad;

            spr.DrawString(Main.TitleFont, str, Position, Colour, rot, Main.TitleFont.MeasureString(str.ToString()) * 0.5f, 1f, SpriteEffects.None, 0f);
        }
    }
}
