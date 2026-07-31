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
        // Animated sprite for display.
        public AnimatedSprite AnimatedSprite { get; private set; }

        /// <summary>
        /// Constructor for the bat class.
        /// </summary>
        /// <param name="position">Initial position of the bat.</param>
        /// <param name="animatedSprite">Animated sprite of the bat.</param>

        public Bat(Vector2 position, AnimatedSprite animatedSprite)
        {
            // Initialize the bat's position and animated sprite.
            Position = position;
            AnimatedSprite = animatedSprite;

            // Scale the animated sprite.
            AnimatedSprite.Scale = new Vector2(4.0f);

            // Center the animated sprite's origin.
            AnimatedSprite.SetCenterOrigin();

            // Initialize the bat's collider.
            Collider = new RectangleCollider(
                this,
                new RectangleF(
                    -AnimatedSprite.Width * 0.5f,
                    -AnimatedSprite.Height * 0.5f,
                    AnimatedSprite.Width,
                    AnimatedSprite.Height
                )
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

            // Draw the bats's collider for debugging.
            Collider?.DebugDraw(spriteBatch, Color.Red, 1);
        }
    }
}
