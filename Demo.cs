using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Vektor
{
    //Deklarace smeru
    enum Smer
    {
        Doprava,
        Dolu,
        Doleva,
        Nahoru,
    }
    public class Demo : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        
        //Deklarace
        private int _SirkaOkna = 800;
        private int _VyskaOkna = 600;
        
        //Deklarace 2D textury
        private Texture2D _textura;
        //Deklerace promennych
        private int x, y, w, h;
        private Smer d;

        public Demo()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //Titulek okna
            Window.Title = "Ping Pong";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            //Rozmery okna promenne (_SirkaOkna, _VyskaOkna)
            _graphics.PreferredBackBufferWidth = _SirkaOkna;
            _graphics.PreferredBackBufferHeight = _VyskaOkna; 
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //Nastaveni hodnot promennych
            w = h = 100;
            x = 0;
            y = 0;
            d = Smer.Doprava;
            //Zde jsem pripravil data pro texturu
            _textura = new Texture2D(GraphicsDevice, 1, 1);
            _textura.SetData<Color>(new Color[] { Color.Black });
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Tady definuji smery (doprava, doleva, nahoru, dolu) 
            if (d == Smer.Doprava)
            {
                x += 10;
                
            }

            else if (d == Smer.Doleva)
            {
                x -= 10;
            }

            else if (d == Smer.Nahoru)
            {
                y -= 10;
            }

            else if (d == Smer.Dolu)
            {
                y += 10;
            }

            
            
            
            if (x + w  == 200 && y == 0)
            {
                d = Smer.Dolu;
                
            }

            else if (y + h == 600 && x + w == 200)
            {
                d = Smer.Doprava;
            }

            else if (y + h == 600 && x + w == 400)
            { 
                d = Smer.Nahoru;
            }

            else if (x + w == 400 && y  == 0)
            {
                d = Smer.Doprava;
            }

            else if (x + w == 600 && y == 0)
            {
                d = Smer.Dolu;
            }

            else if (y + h == 600 && x + w == 600)
            {
                d = Smer.Doprava;
            }

            else if (y + h == 600 && x + w == 800)
            {
                d = Smer.Nahoru;
            }

            else if (x + w == 800 && y == 0)
            {
                d = Smer.Dolu;
            }

            else if (x + w == 800 && y == 10)
            {
                d = Smer.Doleva;
            }

            else if (x + w == 100 && y == 10)
            {
                d = Smer.Dolu;
            }

            else if (y + h == 600 && x  == 0)
            {
                d = Smer.Doprava;
            }

 

           


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //Zmenim barvu okna
            GraphicsDevice.Clear(Color.GreenYellow);

            //Zde je vykresleni textury 
            _spriteBatch.Begin();
            _spriteBatch.Draw(_textura, new Rectangle(x, y, w, h), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
