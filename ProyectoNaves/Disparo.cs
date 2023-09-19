using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNaves
{
    internal class Disparo : Spriteable
    {
        public int indice;
        DateTime tiempo = DateTime.Now;
        Texture2D tex;
        Texture2D tex1;
        Texture2D tex2;
        Texture2D texc;
        Texture2D texc1;
        Texture2D texc2;
        Texture2D texc3;
        public bool Choco;
        


        public bool colision = false;
       


        public override void Cargarcontenido(ContentManager manager)
        {
            tex = manager.Load<Texture2D>(@"img/Nave/Disparo/shot3_1");
            tex1 = manager.Load<Texture2D>(@"img/Nave/Disparo/shot3_2");
            tex2 = manager.Load<Texture2D>(@"img/Nave/Disparo/shot3_3");
            Textura = manager.Load<Texture2D>(@"img/Nave/Disparo/shot3_asset");
            texc = manager.Load<Texture2D>(@"img/Nave/Disparo/shot3_exp1");
            texc1 = manager.Load<Texture2D>(@"img/Nave/Disparo/shot3_exp2");
            texc2 = manager.Load<Texture2D>(@"img/Nave/Disparo/shot3_exp3");
            texc3 = manager.Load<Texture2D>(@"img/Nave/Disparo/shot3_exp4");
            coordenadas = new Vector2(200, 200);
            tamaño = new Vector2(64, 64);
        }
        public override void update()
        {   if (indice == 4)
            {
                coordenadas.X += 5;
            }
            
            TimeSpan ts = (DateTime.Now - tiempo);
            if (ts.TotalSeconds > 0.05)
            {
                indice = (indice + 1);
                if (colision == false)
                {
                    if (indice >= 4)
                    { indice = 4; }
                }
                else if (colision == true) 
                {
                    if (indice >= 8) 
                    { indice = 8; }
                }
                tiempo = DateTime.Now;
            }


        }

        public override void dibujar(SpriteBatch spriteBatch)
        {
            rec = new Rectangle((int)coordenadas.X, (int)coordenadas.Y, (int)tamaño.X, (int)tamaño.Y);
            if (colision == false)
            {
                switch (indice)
                {
                    case 1:
                        spriteBatch.Draw(tex, rec, Color.White);
                        break;
                    case 2:
                        spriteBatch.Draw(tex1, rec, Color.White);
                        break;
                    case 3:
                        spriteBatch.Draw(tex2, rec, Color.White);
                        break;
                    case 4:
                        spriteBatch.Draw(Textura, rec, Color.White);
                        break;


                }

            }else if (colision == true) 
            {
                switch (indice)
                {
                    case 5:
                        spriteBatch.Draw(texc, rec, Color.White);
                        break;
                    case 6:
                        spriteBatch.Draw(texc1, rec, Color.White);
                        break;
                    case 7:
                        spriteBatch.Draw(texc2, rec, Color.White);
                        break;
                    case 8:
                        spriteBatch.Draw(texc3, rec, Color.White);
                        break;
                }
            }



        }
    }
}
