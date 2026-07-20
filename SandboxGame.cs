using ChefEngine.Core;
using ChefEngine.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace ChefEngineSandbox
{
    /// <summary>
    /// SandboxGame class that serves as the entry point for the ChefEngine Sandbox game.
    /// </summary>
    public class SandboxGame : Engine
    {
        // The entity list.
        private List<Entity> _entities;

        // The player and bat animated sprites.
        private AnimatedSprite _playerSprite;
        private AnimatedSprite _batSprite;

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

            // Initialize the entity list.
            _entities = new List<Entity>();

            // Adjust the properties of the player and bat animated sprites.
            _playerSprite.Scale = new Vector2(4.0f);
            _batSprite.Scale = new Vector2(4.0f);

            // Initialize the player and add it to the entity list.
            Entity player = new Player(new Vector2(0.0f), _playerSprite);
            _entities.Add(player);

            // Initialize the bat and add it to the entity list.
            Entity bat = new Bat(new Vector2(50.0f), _batSprite);
            _entities.Add(bat);
        }

        protected override void LoadContent()
        {
            // Load the texture atlas from the json file.
            TextureAtlas atlas = TextureAtlasLoader.Load("images/atlas-definition.json");

            // Load the player and bat animated sprites from the atlas.
            _playerSprite = new AnimatedSprite(atlas.GetAnimation("slime-animation"));
            _batSprite = new AnimatedSprite(atlas.GetAnimation("bat-animation"));
        }

        protected override void Update(GameTime gameTime)
        {
            // Update all the entities.
            foreach (Entity entity in _entities)
            {
                entity.Update(gameTime);
            }

            // Call the base class's Update method.
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Clear the screen with a salmon color.
            GraphicsDevice.Clear(Color.Salmon);

            // Begin the sprite batch to prepare for 2D rendering with point sampling for sharp pixel art.
            SpriteBatch.Begin(samplerState: SamplerState.PointClamp);

            // Draw all the entities.
            foreach (Entity entity in _entities)
            {
                entity.Draw();
            }

            // End the sprite batch to finish 2D rendering.
            SpriteBatch.End();

            // Call the base class's Draw method.
            base.Draw(gameTime);
        }
    }
}
