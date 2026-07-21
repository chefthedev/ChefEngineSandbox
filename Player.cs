using ChefEngine.Core;
using ChefEngine.Geometry;
using ChefEngine.Graphics;
using ChefEngine.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ChefEngineSandbox
{
    /// <summary>
    /// Player class for representing a player.
    /// </summary>
    public class Player : Entity
    {
        // The player's movement speed.
        public float MovementSpeed { get; private set; } = 50.0f;

        // The player's animated sprite.
        public AnimatedSprite AnimatedSprite { get; private set; }

        /// <summary>
        /// Constructor for the player class.
        /// </summary>
        /// <param name="position">The initial position of the player.</param>
        /// <param name="animatedSprite">The animated sprite of the player.</param>

        public Player(Vector2 position, AnimatedSprite animatedSprite)
        {
            // Initialize the player's position and animated sprite.
            Position = position;
            AnimatedSprite = animatedSprite;

            // Initialize the player's collider.
            Collider = new RectangleCollider(
                this,
                new RectangleF(0, 0, AnimatedSprite.Width, AnimatedSprite.Height)
            );
        }

        public override void Update(GameTime gameTime)
        {
            // Handle the keyboard input.
            CheckAndHandleKeyboardInput(gameTime);

            // Update the player's animated sprite.
            AnimatedSprite.Update(gameTime);
        }

        public override void Draw()
        {
            // Draw the player's animated sprite at the current position.
            AnimatedSprite.Draw(Engine.Instance.SpriteBatch, Position);
        }

        /// <summary>
        /// Checks the current keyboard state and adjusts the player.
        /// </summary>
        /// <param name="gameTime">The game time instance.</param>
        private void CheckAndHandleKeyboardInput(GameTime gameTime)
        {
            // Initialize the movement vector.
            Vector2 movement = Vector2.Zero;

            // Calculate the adjusted movement speed with delta time.
            float adjustedMovementSpeed = MovementSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // If the space bar is pressed.
            if (Engine.Instance.Input.Keyboard.IsKeyDown(Keys.Space))
            {
                // Multiply the movement speed to apply a sprint mechanic.
                adjustedMovementSpeed *= 5f;
            }
            // If the W key is pressed.
            if (Engine.Instance.Input.Keyboard.IsKeyDown(Keys.W))
            {
                // Move the player up.
                movement.Y -= 1;
            }
            // If the S key is pressed.
            if (Engine.Instance.Input.Keyboard.IsKeyDown(Keys.S))
            {
                // Move the player down.
                movement.Y += 1;
            }
            // If the A key is pressed.
            if (Engine.Instance.Input.Keyboard.IsKeyDown(Keys.A))
            {
                // Move the player left.
                movement.X -= 1;
            }
            // If the D key is pressed.
            if (Engine.Instance.Input.Keyboard.IsKeyDown(Keys.D))
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
