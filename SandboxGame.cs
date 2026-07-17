using ChefEngine.Core;
using ChefEngine.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ChefEngineSandbox
{
    /// <summary>
    /// SandboxGame class that serves as the entry point for the ChefEngine Sandbox game.
    /// </summary>
    public class SandboxGame : Engine
    {
        // The slime and bat animated sprites.
        private AnimatedSprite _slime;
        private AnimatedSprite _bat;

        // The slime's current position.
        private Vector2 _slimePosition;

        // Constant for the slime's movement speed.
        private const float MOVEMENT_SPEED = 100.0f;

        /// <summary>
        /// Constructor for the SandboxGame class.
        /// </summary>
        public SandboxGame() : base("ChefEngine Sandbox", 1280, 720, false)
        {
            
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here.

            base.Initialize();

            // Adjust the properties of the slime and bat animated sprites.
            _slime.Scale = new Vector2(4.0f);
            _bat.Scale = new Vector2(4.0f);
        }

        protected override void LoadContent()
        {
            // Load the texture atlas from the xml config file.
            TextureAtlas atlas = TextureAtlas.CreateFromFile(Content, "images/atlas-definition.xml");

            // Create the slime and bat animated sprite from the atlas.
            _slime = atlas.CreateAnimatedSprite("slime-animation");
            _bat = atlas.CreateAnimatedSprite("bat-animation");
        }

        protected override void Update(GameTime gameTime)
        {
            // Update the slime and bat animated sprites.
            _slime.Update(gameTime);
            _bat.Update(gameTime);

            // Check and handle keyboard input events.
            CheckAndHandleKeyboardInput(gameTime);

            // Call the base class's Update method.
            base.Update(gameTime);
        }

        /// <summary>
        /// Checks the current keyboard state and moves the slime character.
        /// </summary>
        /// <param name="gameTime">The game time instance.</param>
        private void CheckAndHandleKeyboardInput(GameTime gameTime)
        {
            // Calculate the adjusted movement speed with delta time.
            float adjustedMovementSpeed = MOVEMENT_SPEED * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // If the space bar is pressed.
            if (Input.Keyboard.IsKeyDown(Keys.Space))
            {
                // Multiply the movement speed to apply a sprint mechanic.
                adjustedMovementSpeed *= 5f;
            }
            // If the W key is pressed.
            if (Input.Keyboard.IsKeyDown(Keys.W))
            {
                // Move the slime up.
                _slimePosition.Y -= adjustedMovementSpeed;
            }
            // If the S key is pressed.
            if (Input.Keyboard.IsKeyDown(Keys.S))
            {
                // Move the slime down.
                _slimePosition.Y += adjustedMovementSpeed;
            }
            // If the A key is pressed.
            if (Input.Keyboard.IsKeyDown(Keys.A))
            {
                // Move the slime left.
                _slimePosition.X -= adjustedMovementSpeed;
            }
            // If the D key is pressed.
            if (Input.Keyboard.IsKeyDown(Keys.D))
            {
                // Move the slime right.
                _slimePosition.X += adjustedMovementSpeed;
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            // Clear the screen with a salmon color.
            GraphicsDevice.Clear(Color.Salmon);

            // Begin the sprite batch to prepare for 2D rendering with point sampling for sharp pixel art.
            SpriteBatch.Begin(samplerState: SamplerState.PointClamp);

            // Draw the slime and bat animated sprites.
            _slime.Draw(SpriteBatch, _slimePosition);
            _bat.Draw(SpriteBatch, new Vector2(_slime.Width + 10, 0));

            // End the sprite batch to finish 2D rendering.
            SpriteBatch.End();

            // Call the base class's Draw method.
            base.Draw(gameTime);
        }
    }
}
