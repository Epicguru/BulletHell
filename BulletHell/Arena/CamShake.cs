using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Arena
{
    public class CamShake : GameComponent
    {
        public float CurrentMagnitude { get; private set; }
        public Vector2 CameraOffset { get; private set; }
        public float Frequency = 20f;
        public float LerpSpeed = 15f;
        public float DecaySpeed = 10f;

        private Vector2 internalCameraOffset;
        private float timer;

        public CamShake(Game game) : base(game)
        {

        }

        public void Shake(float amount)
        {
            if(CurrentMagnitude < amount)
                CurrentMagnitude = amount;
        }

        public override void Update(GameTime gameTime)
        {
            if (Input.LeftMouseDown())
            {
                LerpSpeed = 20;
                Frequency = 35;
                Shake(200f);
            }

            timer += Time.deltaTime;
            float interval = 1f / Frequency;

            if(timer >= interval)
            {
                timer = 0f;
                // TODO use DOT.
                internalCameraOffset = Random.GetRandomDirection() * CurrentMagnitude;
            }

            CameraOffset = Vector2.Lerp(CameraOffset, internalCameraOffset, Time.deltaTime * LerpSpeed);
            CurrentMagnitude = Mathf.Lerp(CurrentMagnitude, 0f, Time.deltaTime * DecaySpeed);
        }
    }
}
