using ChefEngine.Core;
using ChefEngine.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChefEngineSandbox
{
    /// <summary>
    /// SandboxGame class that serves as the entry point for the ChefEngine Sandbox game.
    /// </summary>
    public class SandboxGame : Engine
    {
        // The player and bat animated sprites.
        private AnimatedSprite _playerSprite;
        private AnimatedSprite _batSprite;

        // The player.
        private Player _player;

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

            // Adjust the properties of the player and bat animated sprites.
            _playerSprite.Scale = new Vector2(4.0f);
            _batSprite.Scale = new Vector2(4.0f);

            // Initialize the player.
            _player = new Player(new Vector2(0.0f), _playerSprite);
        }

        protected override void LoadContent()
        {
            // Load the texture atlas from the xml config file.
            TextureAtlas atlas = TextureAtlas.CreateFromFile(Content, "images/atlas-definition.xml");

            // Create the player and bat animated sprite from the atlas.
            _playerSprite = atlas.CreateAnimatedSprite("slime-animation");
            _batSprite = atlas.CreateAnimatedSprite("bat-animation");
        }

        protected override void Update(GameTime gameTime)
        {
            // Update the player.
            _player.Update(Input, gameTime);

            // Update the bat animated sprite.
            _batSprite.Update(gameTime);

            // Call the base class's Update method.
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Clear the screen with a salmon color.
            GraphicsDevice.Clear(Color.Salmon);

            // Begin the sprite batch to prepare for 2D rendering with point sampling for sharp pixel art.
            SpriteBatch.Begin(samplerState: SamplerState.PointClamp);

            // Draw the player.
            _player.Draw(SpriteBatch);

            // Draw the bat animated sprite.
            _batSprite.Draw(SpriteBatch, new Vector2(50, 0));

            // End the sprite batch to finish 2D rendering.
            SpriteBatch.End();

            // Call the base class's Draw method.
            base.Draw(gameTime);
        }
    }
}
