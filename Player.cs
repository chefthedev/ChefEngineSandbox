using ChefEngine.Graphics;
using ChefEngine.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ChefEngineSandbox
{
    /// <summary>
    /// Player class for representing the player.
    /// </summary>
    public class Player
    {
        // The player's position.
        public Vector2 Position { get; private set; }

        // The player's movement speed.
        public float MovementSpeed { get; private set; } = 50.0f;

        // The player's animated sprite.
        public AnimatedSprite AnimatedSprite { get; private set; }

        /// <summary>
        /// Constructor for the player class.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="animatedSprite"></param>

        public Player(Vector2 position, AnimatedSprite animatedSprite)
        {
            // Initialize the player's position and animated sprite.
            Position = position;
            AnimatedSprite = animatedSprite;
        }

        /// <summary>
        /// Updates the state of the player based on the parameters.
        /// </summary>
        /// <param name="input">The input manager instance.</param>
        /// <param name="gameTime">The game time instance.</param>
        public void Update(InputManager input, GameTime gameTime)
        {
            // Handle the keyboard input.
            CheckAndHandleKeyboardInput(input, gameTime);

            // Update the player's animated sprite.
            AnimatedSprite.Update(gameTime);
        }

        /// <summary>
        /// Submit the player for drawing to the current sprite batch.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to draw the player in.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the player's animated sprite at the current position.
            AnimatedSprite.Draw(spriteBatch, Position);
        }

        /// <summary>
        /// Checks the current keyboard state and adjusts the player.
        /// </summary>
        /// <param name="input">The input manager instance.</param>
        /// <param name="gameTime">The game time instance.</param>
        private void CheckAndHandleKeyboardInput(InputManager input, GameTime gameTime)
        {
            // Initialize the movement vector.
            Vector2 movement = Vector2.Zero;

            // Calculate the adjusted movement speed with delta time.
            float adjustedMovementSpeed = MovementSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // If the space bar is pressed.
            if (input.Keyboard.IsKeyDown(Keys.Space))
            {
                // Multiply the movement speed to apply a sprint mechanic.
                adjustedMovementSpeed *= 5f;
            }
            // If the W key is pressed.
            if (input.Keyboard.IsKeyDown(Keys.W))
            {
                // Move the player up.
                movement.Y -= 1;
            }
            // If the S key is pressed.
            if (input.Keyboard.IsKeyDown(Keys.S))
            {
                // Move the player down.
                movement.Y += 1;
            }
            // If the A key is pressed.
            if (input.Keyboard.IsKeyDown(Keys.A))
            {
                // Move the player left.
                movement.X -= 1;
            }
            // If the D key is pressed.
            if (input.Keyboard.IsKeyDown(Keys.D))
            {
                // Move the player right.
                movement.X += 1;
            }

            // If the player will move.
            if (movement != Vector2.Zero)
            {
                // Normalize the movement vector.
                movement.Normalize();
            }

            // Apply the movement.
            Position += movement * adjustedMovementSpeed;
        }
    }
}
