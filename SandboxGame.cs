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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Update the slime and bat animated sprites.
            _slime.Update(gameTime);
            _bat.Update(gameTime);

            // Call the base class's Update method.
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Clear the screen with a salmon color.
            GraphicsDevice.Clear(Color.Salmon);

            // Begin the sprite batch to prepare for 2D rendering with point sampling for sharp pixel art.
            SpriteBatch.Begin(samplerState: SamplerState.PointClamp);

            // Draw the slime and bat animated sprites.
            _slime.Draw(SpriteBatch, Vector2.Zero);
            _bat.Draw(SpriteBatch, new Vector2(_slime.Width + 10, 0));

            // End the sprite batch to finish 2D rendering.
            SpriteBatch.End();

            // Call the base class's Draw method.
            base.Draw(gameTime);
        }
    }
}
