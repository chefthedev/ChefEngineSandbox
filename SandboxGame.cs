using ChefEngine.Core;
using ChefEngine.Graphics;
using Microsoft.Xna.Framework;

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

            // Adjust the properties of the player and bat animated sprites.
            _playerSprite.Scale = new Vector2(4.0f);
            _batSprite.Scale = new Vector2(4.0f);

            // Initialize the player and add it to the entity list.
            Entity player = new Player(new Vector2(0.0f), _playerSprite);
            Engine.Instance.Entities.Add(player);

            // Initialize the bat and add it to the entity list.
            Entity bat = new Bat(new Vector2(50.0f), _batSprite);
            Engine.Instance.Entities.Add(bat);
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
            // Call the base class's Update method.
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Call the base class's Draw method.
            base.Draw(gameTime);
        }
    }
}
