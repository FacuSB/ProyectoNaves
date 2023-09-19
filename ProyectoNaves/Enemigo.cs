using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNaves
{
    internal class Enemigo : Spriteable
    {
        public static Random Random = new Random();
        public int vidas;
        Texture2D Textura1;
        Texture2D Textura2;
        Texture2D Textura3;
        Texture2D Textura4;
        Texture2D Textura5;
        public int indice=1;
        DateTime tiempo = DateTime.Now;
        public Enemigo()
        {
            vidas = 3;
            
        }
        public bool Vivo
        {
            get { return (vidas >= 0); }
        }
        public override void Cargarcontenido(ContentManager manager)
        {

            Textura = manager.Load<Texture2D>(@"img/Asteroide/Asteroide (1)");
            Textura1 = manager.Load<Texture2D>(@"img/Asteroide/Asteroide (2)");
            Textura2 = manager.Load<Texture2D>(@"img/Asteroide/Asteroide (3)");
            Textura3 = manager.Load<Texture2D>(@"img/Asteroide/Asteroide (4)");
            Textura4 = manager.Load<Texture2D>(@"img/Asteroide/Asteroide (5)");
            Textura5 = manager.Load<Texture2D>(@"img/Asteroide/Asteroide (6)");

            coordenadas = new Microsoft.Xna.Framework.Vector2(2000, Random.Next(50, 600));
            tamaño = new Microsoft.Xna.Framework.Vector2(200, 200);
        }
        public override void update()
        {
            coordenadas.X -= 5;
            TimeSpan ts = (DateTime.Now - tiempo);
            if (ts.TotalSeconds > 0.1)
            {
                indice = (indice + 1);
                if (Vivo == true)
                {
                    if (indice >= 1)
                    { indice = 1; }
                }
                if (Vivo == false)
                {
                    if (indice >= 6)
                    { indice = 6; }
                }
                tiempo = DateTime.Now;
            }
        }
        public override void dibujar(SpriteBatch spriteBatch)
        {
            rec = new Microsoft.Xna.Framework.Rectangle((int)coordenadas.X, (int)coordenadas.Y, (int)tamaño.X, (int)tamaño.Y);
            switch (indice)
            {
                case 1:
                    spriteBatch.Draw(Textura, rec, Microsoft.Xna.Framework.Color.White);
                    break;
                case 2:
                    spriteBatch.Draw(Textura1, rec, Microsoft.Xna.Framework.Color.White);
                    break;
                case 3:
                    spriteBatch.Draw(Textura2, rec, Microsoft.Xna.Framework.Color.White);
                    break;
                case 4:
                    spriteBatch.Draw(Textura3, rec, Microsoft.Xna.Framework.Color.White);
                    break;
                case 5:
                    spriteBatch.Draw(Textura4, rec, Microsoft.Xna.Framework.Color.White);
                    break;
                case 6:
                    spriteBatch.Draw(Textura5, rec, Microsoft.Xna.Framework.Color.White);
                    break;


            }

            
        }
        public  void Detectarimpacto(List<Disparo> disparos)
        {
            float X2 = (rec.X + rec.Width);
            float Y2 = (rec.Y + rec.Height);
            foreach (Disparo disparoo in disparos) 
            {
                if (rec.X <= disparoo.coordenadas.X && X2 >= disparoo.coordenadas.X)
                {
                    if (rec.Y <= disparoo.coordenadas.Y && Y2 >= disparoo.coordenadas.Y)
                    {
                        vidas--;
                        disparoo.colision = true;
                    }
                }
            }
            
        }
        public void Dañar(Jugador jugador)
        {
            float X2 = (rec.X + rec.Width);
            float Y2 = (rec.Y + rec.Height);
            if (rec.X <= jugador.coordenadas.X && X2 >= jugador.coordenadas.X)
            {
                if (rec.Y <= jugador.coordenadas.Y && Y2 >= jugador.coordenadas.Y)
                {
                    jugador.vidas--; 
                }
            }
        }
    }
}
