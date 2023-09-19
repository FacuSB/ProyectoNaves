using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ProyectoNaves
{
    internal class  Spriteable
    {
        public Vector2 coordenadas;
        public Vector2 tamaño;
        public Texture2D Textura;
        public Rectangle rec;
        public virtual void Cargarcontenido(ContentManager manager)
        {
            Textura = manager.Load<Texture2D>(@"img/Nave/Ship3");
            coordenadas = new Vector2(200,200);
            tamaño = new Vector2(128, 128);
            

        }
        public virtual void dibujar(SpriteBatch spriteBatch)
        {
            rec = new Rectangle((int)coordenadas.X, (int)coordenadas.Y, (int)tamaño.X, (int)tamaño.Y);
            spriteBatch.Draw(Textura, rec, Color.White);
            
        }
        public virtual void update()
        {
            
        }

    }
}
