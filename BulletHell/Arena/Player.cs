using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Arena
{
    public class Player : GameObject
    {
        public Player(Game game) : base(game, "Player")
        {
            base.DrawOrder = 1;
        }

        public override void Initialize()
        {
            Width = 32;
            Height = 32;
            Colour = Color.LightSeaGreen;
        }

        public override void Update()
        {
            Velocity = new Vector2(32f, 32f);
        }
    }
}
