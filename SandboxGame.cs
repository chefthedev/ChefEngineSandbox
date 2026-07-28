using ChefEngine.Core;
using ChefEngine.Graphics;
using ChefEngineSandbox.Worlds;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChefEngineSandbox
{
    /// <summary>
    /// SandboxGame class that serves as the entry point for the ChefEngine Sandbox game.
    /// </summary>
    public class SandboxGame : Engine
    {
        // The world.
        private World _world = null!;

        // The texture atlas.
        private TextureAtlas _atlas = null!;

        /// <summary>
        /// Constructor for the SandboxGame class.
        /// </summary>
        public SandboxGame() : base("ChefEngine Sandbox", 1280, 720, false)
        {
            
        }

        protected override void Initialize()
        {
            // Call the base class's Initialize method.
            // The final task this line performs is calling LoadContent() below.
            base.Initialize();

            // Initialize the world.
            _world = new World(GraphicsDevice.Viewport);

            // Initialize the player and add it to the world entity collection.
            Player player = new(
                new Vector2(0.0f),
                new AnimatedSprite(_atlas.GetAnimation("slime-animation"))
            );
            _world.EntityCollection.Add(player);

            // Initialize the bat and add it to the world entity collection.
            Bat bat = new(
                new Vector2(100.0f),
                new AnimatedSprite(_atlas.GetAnimation("bat-animation"))
            );
            _world.EntityCollection.Add(bat);

            // Set the world camera target to the player.
            _world.SetCameraTarget(player);
        }

        protected override void LoadContent()
        {
            // Load the texture atlas from the json file.
            _atlas = TextureAtlasLoader.Load("images/atlas-definition.json");
        }

        protected override void UpdateGame(GameTime gameTime)
        {
            // Update the world.
            _world.Update(gameTime);
        }

        protected override void DrawGame(GameTime gameTime)
        {
            // Begin the sprite batch to prepare for 2D rendering with point sampling for sharp pixel art and the camera transform.
            SpriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: _world.Camera.Transform);

            // Draw the world.
            _world.Draw(SpriteBatch);

            // End the sprite batch to finish 2D rendering.
            SpriteBatch.End();
        }
    }
}
