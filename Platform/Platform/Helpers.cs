
using Library.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Platform
{
    public static class Helpers
    {
        public static void Draw(this SpriteBatch spriteBatch, Texture2D texture, Vector position, Color color)
        {
            spriteBatch.Draw(texture, position.Vector2, color);
        }
    }

    static class PhysicsHelper
    {
        private const float Drag = 0.1f;

        public static float DecayVelocity(float speed)
        {
            if (speed*Drag > 0 && speed*Drag < 1)
                return 0;

            return speed - (speed * Drag);
        }

        public static Vector2  DecayVelocity(Vector2 velocity)
        {
            velocity.X = DecayVelocity(velocity.X);
            velocity.Y = DecayVelocity(velocity.Y);
            return velocity;
        }
    }    
}
