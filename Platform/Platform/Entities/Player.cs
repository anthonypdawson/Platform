

using System.Collections.Generic;
using Library.Physics.Controllers;

namespace Platform
{
    public class Player : Actor
    {

        public Player(World world) : this()
        {
            World = world;
        }
        public Player()
        {
            Controllers = new List<IPhysicsController>() {new GravityController()};    
        }

        public override void Update()
        {                        
            UpdatePosition();
            UpdateVelocity();
        }

        internal new void UpdateVelocity()
        {
            //Velocity = PhysicsHelper.DecayVelocity(Velocity);

            foreach (var c in Controllers)
            {
                Acceleration = c.ModifyAcceleration(Acceleration);
            }
            base.Update();
        }

    }
}
