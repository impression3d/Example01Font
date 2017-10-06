using Impression;
using Impression.Graphics;
using Impression.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Example01Font
{
    public class Example01FontGame : Impression.Game
    {
		GraphicsDeviceManager graphics;

		SpriteBatch spriteBatch;
		SpriteFont spriteFont;

		string titleText = "Lorem Ipsum,";
		string bodyText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua 17. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat 08. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur 1945. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
		string formattedBodyText = null;

        public Example01FontGame()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);

			switch (FrameworkContext.Platform)
			{
				case PlatformType.Windows:
				case PlatformType.Mac:
				case PlatformType.Linux:
					{
						graphics.PreferredBackBufferWidth = 1280;
						graphics.PreferredBackBufferHeight = 720;

						this.IsMouseVisible = true;
					}
					break;
                case PlatformType.WindowsStore:
                case PlatformType.WindowsMobile:
					{
						graphics.PreferredBackBufferWidth = 1280;
						graphics.PreferredBackBufferHeight = 720;

						graphics.IsFullScreen = true;

						// Frame rate is 30 fps by default for mobile device
						TargetElapsedTime = TimeSpan.FromTicks(TimeSpan.TicksPerSecond / 30L);
					}
					break;
				case PlatformType.Android:
				case PlatformType.iOS:
					{
						graphics.PreferredBackBufferWidth = 1280;
						graphics.PreferredBackBufferHeight = 720;

						graphics.IsFullScreen = true;

						// Frame rate is 30 fps by default for mobile device
						TargetElapsedTime = TimeSpan.FromTicks(TimeSpan.TicksPerSecond / 30L);
					}
					break;
			}

            this.View.Title = "Example01Font";
        }

        protected override void Initialize()
        { 
            base.Initialize();

            spriteBatch = new SpriteBatch(graphics.GraphicsDevice);
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            spriteFont = this.Content.Load<SpriteFont>("Fonts/petangue-42");
			spriteFont.Kerning = 2;
        }

        protected override void UnloadContent()
        {
            // do something

            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
			switch (FrameworkContext.Platform)
			{
				case PlatformType.Windows:
				case PlatformType.Mac:
				case PlatformType.Linux:
					{
						if (Keyboard.GetState().IsKeyDown(Keys.Escape))
							this.Exit();
					}
					break;
				default:
					{
						// do nothings
					}
					break;
			}

			// do something
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
			graphics.GraphicsDevice.Clear(Color.BurlyWood);

			// Width limit when wrapping string
			const float wrappedWidth = 1000;

			// Allows format string
			if (string.IsNullOrEmpty(formattedBodyText))
				formattedBodyText = spriteFont.Wrap(bodyText, wrappedWidth);
			
			spriteBatch.Begin();

			// Draw title text
			spriteBatch.DrawString(spriteFont, titleText, new Vector2(64), Color.Wheat);

			// Draw body text (already formatted)
			spriteBatch.DrawString(spriteFont, formattedBodyText, new Vector2(64, 150), Color.Brown);

			spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}