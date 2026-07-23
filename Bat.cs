using ChefEngine.Entities;
using ChefEngine.Geometry;
using ChefEngine.Graphics;
using ChefEngine.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChefEngineSandbox
{
    /// <summary>
    /// Bat class for representing a bat.
    /// </summary>
    public class Bat : Entity
    {
        // The bat's animated sprite.
        public AnimatedSprite AnimatedSprite { get; private set; }

        /// <summary>
        /// Constructor for the bat class.
        /// </summary>
        /// <param name="position">The initial position of the bat.</param>
        /// <param name="animatedSprite">The animated sprite of the bat.</param>

        public Bat(Vector2 position, AnimatedSprite animatedSprite)
        {
            // Initialize the bat's position and animated sprite.
            Position = position;
            AnimatedSprite = animatedSprite;

            // Initialize the bat's collider.
            Collider = new RectangleCollider(
                this,
                new RectangleF(0, 0, AnimatedSprite.Width, AnimatedSprite.Height)
            );
        }

        public override void Update(GameTime gameTime)
        {
            // Update the bat's animated sprite.
            AnimatedSprite.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // Draw the bat's animated sprite at the current position.
            AnimatedSprite.Draw(spriteBatch, Position);
        }
    }
}
