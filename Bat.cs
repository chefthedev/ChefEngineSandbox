using ChefEngine.Core;
using ChefEngine.Graphics;
using Microsoft.Xna.Framework;

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
        }

        public override void Update(GameTime gameTime)
        {
            // Update the bat's animated sprite.
            AnimatedSprite.Update(gameTime);
        }

        public override void Draw()
        {
            // Draw the bat's animated sprite at the current position.
            AnimatedSprite.Draw(Engine.SpriteBatch, Position);
        }
    }
}
