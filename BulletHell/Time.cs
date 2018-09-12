using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BulletHell
{
    public class Time : GameComponent
    {
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

        public Time(Game game) : base(game)
        {
        }

        public override void Initialize()
        {
            Log.StartTimeLog("time module init");

            // Init here.
            timeScale = 1f;

            // TODO HERE FIXME!
            Thread.Sleep(5);

            Log.EndTimeLog();
        }
    }
}
