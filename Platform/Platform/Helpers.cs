
using Microsoft.Xna.Framework;
namespace Platform
{
    class Helpers
    {
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
