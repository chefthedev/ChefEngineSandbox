using ChefEngine.Entities;
using ChefEngine.Graphics;
using ChefEngine.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChefEngineSandbox.Worlds
{
    /// <summary>
    /// World class for representing a game world.
    /// </summary>
    public class World
    {
        // EntityCollection for storing all entities of the world.
        public EntityCollection EntityCollection { get; private set; }

        // Physics System for simulating the physics of the world.
        public PhysicsSystem PhysicsSystem { get; private set; }

        // Camera for moving display of the world.
        public Camera Camera { get; private set; }

        // Camera target to optionally base the cameras position on.
        public Entity? CameraTarget { get; private set; }

        /// <summary>
        /// Constructor for the World class.
        /// </summary>
        /// <param name="viewport">The viewport.</param>
        public World(Viewport viewport)
        {
            // Initialize the entity collection, physics system, and camera.
            EntityCollection = new EntityCollection();
            PhysicsSystem = new PhysicsSystem();
            Camera = new Camera(viewport);
        }

        /// <summary>
        /// Set the camera target to the specified entity.
        /// </summary>
        /// <param name="cameraTarget">The entity to target.</param>
        public void SetCameraTarget(Entity cameraTarget)
        {
            // Set the target.
            CameraTarget = cameraTarget;
        }

        /// <summary>
        /// Updates the state of the world.
        /// </summary>
        /// <param name="gameTime">The game time instance.</param>
        public void Update(GameTime gameTime)
        {
            // For each entity in the world.
            foreach (Entity entity in EntityCollection.Entities)
            {
                // Update it.
                entity.Update(gameTime);
            }

            // Update the physics system.
            PhysicsSystem.Update(gameTime, EntityCollection);

            // Apply the pending entity collection changes.
            EntityCollection.ApplyPendingChanges();

            // If the camera has a target.
            if (CameraTarget != null)
            {
                // Update the camera's position to the target.
                Camera.Position = CameraTarget.Position;
            }
        }

        /// <summary>
        /// Draws the world.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to draw the world entities in.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            // For each entity in the world.
            foreach (Entity entity in EntityCollection.Entities)
            {
                // Draw it.
                entity.Draw(spriteBatch);
            }
        }
    }
}
