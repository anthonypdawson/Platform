

namespace Platform
{
    public class Player : Actor
    {
        public override void Update()
        {            
            UpdateVelocity();
            UpdatePosition();
        }

        internal new void UpdateVelocity()
        {
            Velocity = PhysicsHelper.DecayVelocity(Velocity);
            base.Update();
        }

    }
}
