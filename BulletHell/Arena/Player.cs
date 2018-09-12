using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Arena
{
    public class Player : GameObject
    {
        public const Keys UP = Keys.W;
        public const Keys DOWN = Keys.S;
        public const Keys RIGHT = Keys.D;
        public const Keys LEFT = Keys.A;

        public float Speed = 128f;
        public float VelocityFalloff = 2f;

        public Player(Game game) : base(game, "Player")
        {
            base.DrawOrder = Main.EXEC_ORDER_PLAYER;
        }

        public override void Initialize()
        {
            Width = 32;
            Height = 32;
            Colour = Color.LightSeaGreen;
        }

        public override void Update()
        {
            Vector2 input = new Vector2();

            if (Input.KeyPressed(UP))
            {
                input.Y -= 1;
            }
            if (Input.KeyPressed(DOWN))
            {
                input.Y += 1;
            }
            if (Input.KeyPressed(RIGHT))
            {
                input.X += 1;
            }
            if (Input.KeyPressed(LEFT))
            {
                input.X -= 1;
            }

            // Normalize.
            if(input != Vector2.Zero)
                input.Normalize();

            // Scale by speed.
            Vector2 vel = input * Speed;

            // If there is active input...
            if(input != Vector2.Zero)
            {
                // Set velocity.
                this.Velocity = vel;
            }
            else
            {
                // Otherwise decrease velocity.
                this.Velocity = Vector2.Lerp(this.Velocity, Vector2.Zero, Time.deltaTime * VelocityFalloff);
            }
        }
    }
}
