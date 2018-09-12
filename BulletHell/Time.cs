using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace BulletHell
{
    public class Time : GameComponent
    {
        public const float MAX_ELAPSED_TIME = 0.5f;
        public static float deltaTime { get; private set; }
        public static float unscaledDeltaTime { get; private set; }
        public static float timeScale
        {
            get
            {
                return _timeScale;
            }
            set
            {
                _timeScale = Mathf.ClampF(value, 0f, 500f);
            }
        }
        private static float _timeScale;
        private Stopwatch watch;
        private bool hasRun;

        public Time(Game game) : base(game)
        {
            UpdateOrder = Main.EXEC_ORDER_TIME;
        }

        public override void Initialize()
        {
            // Init here.
            timeScale = 1f;
            watch = new Stopwatch();
            hasRun = false;
        }

        public override void Update(GameTime gameTime)
        {
            // Calculate elapsed time.
            if (!hasRun)
            {
                hasRun = true;

                // Make up seconds value, at a fraction of a second.
                var seconds = 1f / 60f;

                // Set real values.
                unscaledDeltaTime = (float)seconds;
                deltaTime = unscaledDeltaTime * timeScale;

                // Restart, ready for next frame.
                watch.Restart();
            }
            else
            {
                // Stop measuring time.
                watch.Stop();

                var seconds = watch.Elapsed.TotalSeconds;
                seconds = Math.Min(seconds, MAX_ELAPSED_TIME);

                // Set real values.
                unscaledDeltaTime = (float)seconds;
                deltaTime = unscaledDeltaTime * timeScale;

                // Restart, ready for next frame.
                watch.Restart();
            }
        }
    }
}
