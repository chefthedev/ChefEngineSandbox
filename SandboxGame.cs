using ChefEngine.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ChefEngineSandbox
{
    public class SandboxGame : Engine
    {
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
            // TODO: use this.Content to load your game content here.

            base.LoadContent();
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
            GraphicsDevice.Clear(Color.Salmon);
            
            // TODO: Add your drawing code here.

            base.Draw(gameTime);
        }
    }
}
