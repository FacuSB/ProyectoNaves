using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNaves
{
    internal class Fondo:Spriteable
    {
        public override void Cargarcontenido(ContentManager manager)
        {
            Textura = manager.Load<Texture2D>(@"img/Fondo/Space Background");
            coordenadas = new Vector2(0, 0);
            tamaño = new Vector2(1280, 720);
        }
        public override void update()
        {
            base.update();
            coordenadas.X -=4;
            if (coordenadas.X <= -1280)
            {
                coordenadas.X = 1280;
            }
        }
    }
}   
