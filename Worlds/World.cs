using ChefEngine.Entities;
using ChefEngine.Graphics;
using ChefEngine.Physics;
using ChefEngine.Tilemaps;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChefEngineSandbox.Worlds
{
    /// <summary>
    /// World class for representing a game world.
    /// </summary>
    public class World
    {
        // Entities of the world.
        public EntityCollection EntityCollection { get; private set; }

        // Simulates the physics of the world.
        public PhysicsSystem PhysicsSystem { get; private set; }

        // Moving display of the world.
        public Camera Camera { get; private set; }

        // Optional target to base the cameras position on.
        public Entity? CameraTarget { get; private set; }

        // Set of tiles used in the world.
        public TileSet TileSet { get; private set; }

        // Tile map of the world.
        public TileMap TileMap { get; private set; }

        /// <summary>
        /// Constructor for the World class.
        /// </summary>
        /// <param name="viewport">Viewport of the screen.</param>
        /// <param name="tileSet">Tile set for the world.</param>
        /// <param name="width">Width of the world tile map.</param>
        /// <param name="height">Height of the world tile map.</param>
        public World(Viewport viewport, TileSet tileSet, int width, int height)
        {
            // Initialize the entity collection, physics system, camera, and tile map.
            EntityCollection = new EntityCollection();
            PhysicsSystem = new PhysicsSystem(Vector2.Zero);
            Camera = new Camera(viewport);
            TileSet = tileSet;
            TileMap = new TileMap(width, height);
        }

        /// <summary>
        /// Set the camera target to the specified entity.
        /// </summary>
        /// <param name="cameraTarget">Entity to target.</param>
        public void SetCameraTarget(Entity cameraTarget)
        {
            // Set the target.
            CameraTarget = cameraTarget;
        }

        /// <summary>
        /// Updates the state of the world.
        /// </summary>
        /// <param name="gameTime">Game time instance.</param>
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
        /// <param name="spriteBatch">Sprite batch to draw the world entities in.</param>
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
