using Cocos2D;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNaves
{
    internal class Turbo : Spriteable
    {
        public int indice = 1;
        int velocidadX;
        int velocidadY;
        DateTime tiempo = DateTime.Now;
        Texture2D Textura1;
        Texture2D Textura2;
        Texture2D Textura3;

        public override void Cargarcontenido(ContentManager manager)
        {

            Textura = manager.Load<Texture2D>(@"img/Nave/Vuelo/exhaust1");
            Textura1 = manager.Load<Texture2D>(@"img/Nave/Vuelo/exhaust2");
            Textura2 = manager.Load<Texture2D>(@"img/Nave/Vuelo/exhaust3");
            Textura3 = manager.Load<Texture2D>(@"img/Nave/Vuelo/exhaust4");
            coordenadas = new Vector2(200, 248);
            tamaño = new Vector2(30, 30);
        }
        public override void update()
        {



            KeyboardState estado = Keyboard.GetState();
            /*if (estado.IsKeyDown(Keys.Left))
            { velocidadX = -7; }
            else if (estado.IsKeyDown(Keys.Right))
            { velocidadX = 7; }
            else { velocidadX = 0; }
            */

            if (estado.IsKeyDown(Keys.Up))
            { velocidadY = -7; }
            else if (estado.IsKeyDown(Keys.Down))
            { velocidadY = 7; }
            else { velocidadY = 0; }

            this.coordenadas = new Vector2(coordenadas.X + velocidadX, coordenadas.Y + velocidadY);

            if (coordenadas.Y <= 17)
            {
                coordenadas.Y = 17;
            }
            if (coordenadas.Y >= 690)
            {
                coordenadas.Y = 690;
            }

            TimeSpan ts = (DateTime.Now - tiempo);
            if (ts.TotalSeconds > 0.21)
            {
                indice = (indice + 1);
                if (indice > 4)
                {
                    indice = 1;
                }
                tiempo = DateTime.Now;
            }
        }

        public override void dibujar(SpriteBatch spriteBatch)
        {
            switch (indice)
            {
                case 1:
                    spriteBatch.Draw(Textura, rec, Color.White); 
                    break;
                case 2:
                    spriteBatch.Draw(Textura1, rec, Color.White);
                    break;
                case 3:
                    spriteBatch.Draw(Textura2, rec, Color.White);
                    break;
                case 4:
                    spriteBatch.Draw(Textura3, rec, Color.White);
                    break;
            }
            rec = new Rectangle((int)coordenadas.X, (int)coordenadas.Y, (int)tamaño.X, (int)tamaño.Y);
            
        }

    }
}

