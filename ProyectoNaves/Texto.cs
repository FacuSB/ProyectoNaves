using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNaves
{
    internal class Texto:Spriteable
    {
        public SpriteFont Font;
        public string Text="Puntaje : ";
        public Color color= Color.White;
        public override void Cargarcontenido(ContentManager manager)
        {
            Font = manager.Load<SpriteFont>(@"fonts/MarkerFelt-22");
            coordenadas = new Vector2(10, 0);
            tamaño = new Vector2(128, 128);

        }
        public override void dibujar(SpriteBatch spriteBatch)
        {
            rec = new Rectangle((int)coordenadas.X, (int)coordenadas.Y, (int)tamaño.X, (int)tamaño.Y);
            spriteBatch.DrawString(Font, Text, coordenadas, color);
            
        }
    }
    
}
