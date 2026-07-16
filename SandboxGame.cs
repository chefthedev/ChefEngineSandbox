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
        // The slime texture region.
        private TextureRegion _slime;

        // The bat texture region.
        private TextureRegion _bat;

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

            // TODO: Add any initialization that is dependent on LoadContent() here.
            // This is because LoadContent() is called in the last step of base.Initialize().
        }

        protected override void LoadContent()
        {
            // Load the texture atlas from the xml config file.
            TextureAtlas atlas = TextureAtlas.CreateFromFile(Content, "images/atlas-definition.xml");

            // Retrieve the slime and bat texture regions from the atlas.
            _slime = atlas.GetRegion("slime");
            _bat = atlas.GetRegion("bat");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here.

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Clear the screen with a salmon color.
            GraphicsDevice.Clear(Color.Salmon);

            // Begin the sprite batch to prepare for 2D rendering with point sampling for sharp pixel art.
            SpriteBatch.Begin(samplerState: SamplerState.PointClamp);

            // Draw the slime texture region at a scale of 4.0.
            _slime.Draw(SpriteBatch, Vector2.Zero, Color.White, 0.0f, Vector2.One, 4.0f, SpriteEffects.None, 0.0f);

            // Draw the bat texture region 10px to the right of the slime at a scale of 4.0.
            _bat.Draw(SpriteBatch, new Vector2(_slime.Width * 4.0f + 10, 0), Color.White, 0.0f, Vector2.One, 4.0f, SpriteEffects.None, 1.0f);

            // End the sprite batch to finish 2D rendering.
            SpriteBatch.End();

            // Call the base class's Draw method.
            base.Draw(gameTime);
        }
    }
}
