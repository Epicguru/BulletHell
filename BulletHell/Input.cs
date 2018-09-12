using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BulletHell
{
    public class Input : GameComponent
    {
        public static KeyboardState LastKeyState { get; private set; }
        public static KeyboardState CurrentKeyState { get; private set; }
        public static MouseState LastMouseState { get; private set; }
        public static MouseState CurrentMouseState { get; private set; }

        public static Vector2 MouseWorldPosition { get; private set; }
        public static Vector2 MouseScreenPosition { get; private set; }

        public Input(Game game) : base(game)
        {
            base.UpdateOrder = Main.EXEC_ORDER_INPUT;
        }

        public override void Update(GameTime time)
        {
            LastKeyState = CurrentKeyState;
            CurrentKeyState = Keyboard.GetState();

            LastMouseState = CurrentMouseState;
            CurrentMouseState = Mouse.GetState();

            MouseScreenPosition = CurrentMouseState.Position.ToVector2();

            // The world position is found by translating screen space using the camera matrix.
            MouseWorldPosition = Main.Camera.ScreenToWorldPosition(MouseScreenPosition);
        }

        public static bool KeyDown(Keys key)
        {
            return LastKeyState.IsKeyUp(key) && CurrentKeyState.IsKeyDown(key);
        }

        public static bool KeyPressed(Keys key)
        {
            return CurrentKeyState.IsKeyDown(key);
        }

        public static bool LeftMouseDown()
        {
            return LastMouseState.LeftButton == ButtonState.Released && CurrentMouseState.LeftButton == ButtonState.Pressed;
        }

        public static bool LeftMouseUp()
        {
            return LastMouseState.LeftButton == ButtonState.Pressed && CurrentMouseState.LeftButton == ButtonState.Released;
        }

        public static bool RightMouseDown()
        {
            return LastMouseState.RightButton == ButtonState.Released && CurrentMouseState.RightButton == ButtonState.Pressed;
        }

        public static bool RightMouseUp()
        {
            return LastMouseState.RightButton == ButtonState.Pressed && CurrentMouseState.RightButton == ButtonState.Released;
        }

        public static bool LeftMousePressed()
        {
            return CurrentMouseState.LeftButton == ButtonState.Pressed;
        }

        public static bool RightMousePressed()
        {
            return CurrentMouseState.RightButton == ButtonState.Pressed;
        }
    }
}
