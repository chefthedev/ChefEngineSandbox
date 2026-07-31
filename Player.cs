using ChefEngine.Core;
using ChefEngine.Entities;
using ChefEngine.Geometry;
using ChefEngine.Graphics;
using ChefEngine.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ChefEngineSandbox
{
    /// <summary>
    /// Player class for representing a player.
    /// </summary>
    public class Player : Entity
    {
        // Speed of movement.
        public float MovementSpeed { get; private set; } = 50.0f;

        // Animated sprite for display.
        public AnimatedSprite AnimatedSprite { get; private set; }

        /// <summary>
        /// Constructor for the player class.
        /// </summary>
        /// <param name="position">Initial position of the player.</param>
        /// <param name="animatedSprite">Animated sprite of the player.</param>

        public Player(Vector2 position, AnimatedSprite animatedSprite)
        {
            // Initialize the player's position and animated sprite.
            Position = position;
            AnimatedSprite = animatedSprite;

            // Scale the animated sprite.
            AnimatedSprite.Scale = new Vector2(4.0f);

            // Center the animated sprite's origin.
            AnimatedSprite.SetCenterOrigin();

            // Initialize the player's collider.
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
            // Handle the keyboard input.
            CheckAndHandleKeyboardInput();

            // Update the player's animated sprite.
            AnimatedSprite.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // Draw the player's animated sprite at the current position.
            AnimatedSprite.Draw(spriteBatch, Position);

            // Draw the player's collider for debugging.
            Collider?.DebugDraw(spriteBatch, Color.LimeGreen, 1);
        }

        /// <summary>
        /// Checks the current keyboard state and adjusts the player.
        /// </summary>
        private void CheckAndHandleKeyboardInput()
        {
            // Initialize the movement vector.
            Vector2 movement = Vector2.Zero;

            // Initialize the adjusted movement speed.
            float adjustedMovementSpeed = MovementSpeed;

            // If the space bar is pressed.
            if (Engine.Instance.Input.Keyboard.IsKeyDown(Keys.Space))
            {
                // Multiply the adjusted movement speed to apply a sprint mechanic.
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
            Velocity = movement * adjustedMovementSpeed;
        }
    }
}
