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

        public float Speed = 32f * 15f; // Player width * X per second.
        public float VelocityFalloff = 12f;

        public Player(Game game) : base(game, "Player")
        {
            base.DrawOrder = Main.EXEC_ORDER_PLAYER;
        }

        public override void Initialize()
        {
            Width = 32;
            Height = 32;
            Colour = Color.LightGreen;
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


            // Set velocity based on individual axis.
            if (vel.X != 0f)
            {
                this.Velocity.X = vel.X;
            }
            else
            {
                this.Velocity.X = Mathf.Lerp(this.Velocity.X, 0f, Time.deltaTime * VelocityFalloff);
            }

            if (vel.Y != 0f)
            {
                this.Velocity.Y = vel.Y;
            }
            else
            {
                this.Velocity.Y = Mathf.Lerp(this.Velocity.Y, 0f, Time.deltaTime * VelocityFalloff);
            }
        }
    }
}
