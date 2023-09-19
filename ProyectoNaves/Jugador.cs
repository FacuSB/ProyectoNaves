using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProyectoNaves
{
    internal class Jugador:Spriteable
    {
        private int velocidadX;
        private int velocidadY;

        private int indicedisparo = 0;

        public delegate void deldisparo(Microsoft.Xna.Framework.Vector2 disparo);

        public event deldisparo disparar;

        public int vidas;

        int indice;

        Texture2D Textura1;
        Texture2D Textura2;
        Texture2D Textura3;
        Texture2D Textura4;
        Texture2D Textura5;
        Texture2D Textura6;
        Texture2D Textura7;
        Texture2D Textura8;
        Texture2D Textura9;
        Texture2D Textura10;
        Texture2D Textura11;

        DateTime tiempo = DateTime.Now;

        public Jugador()
        {
            vidas = 1;
        }
        public bool Vivo
        {
            get { return (vidas >= 0); }
        }
        public override void Cargarcontenido(ContentManager manager)
        {
            base.Cargarcontenido(manager);
            Textura1 = manager.Load<Texture2D>(@"img/Nave/Muerte/Ship3_Explosion_000");
            Textura2 = manager.Load<Texture2D>(@"img/Nave/Muerte/Ship3_Explosion_004");
            Textura3 = manager.Load<Texture2D>(@"img/Nave/Muerte/Ship3_Explosion_005");
            Textura4 = manager.Load<Texture2D>(@"img/Nave/Muerte/Ship3_Explosion_007");
            Textura5 = manager.Load<Texture2D>(@"img/Nave/Muerte/Ship3_Explosion_009");
            Textura6 = manager.Load<Texture2D>(@"img/Nave/Muerte/Ship3_Explosion_012");
            Textura7 = manager.Load<Texture2D>(@"img/Nave/Muerte/Ship3_Explosion_013");
            Textura8 = manager.Load<Texture2D>(@"img/Nave/Muerte/Ship3_Explosion_015");
            Textura9 = manager.Load<Texture2D>(@"img/Nave/Muerte/Ship3_Explosion_018");
            Textura10 = manager.Load<Texture2D>(@"img/Nave/Muerte/Ship3_Explosion_019");
            Textura11 = manager.Load<Texture2D>(@"img/Nave/Muerte/Ship3_Explosion_021");

        }
        public override void dibujar(SpriteBatch spriteBatch)
        {
            rec = new Microsoft.Xna.Framework.Rectangle((int)coordenadas.X, (int)coordenadas.Y, (int)tamaño.X, (int)tamaño.Y);
            spriteBatch.Draw(Textura, rec, Microsoft.Xna.Framework.Color.White);
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
                    spriteBatch.Draw (Textura4, rec, Microsoft.Xna.Framework.Color.White);
                    break;
                case 6:
                    spriteBatch.Draw(Textura5, rec, Microsoft.Xna.Framework.Color.White);
                    break;
                case 7:
                    spriteBatch.Draw(Textura6, rec, Microsoft.Xna.Framework.Color.White);
                    break;
                case 8:
                    spriteBatch.Draw(Textura7, rec, Microsoft.Xna.Framework.Color.White);
                    break;
                case 9:
                    spriteBatch.Draw(Textura8, rec, Microsoft.Xna.Framework.Color.White);
                    break;
                case 10:
                    spriteBatch.Draw(Textura9, rec, Microsoft.Xna.Framework.Color.White);
                    break;
                case 11:
                    spriteBatch.Draw(Textura10, rec, Microsoft.Xna.Framework.Color.White);
                    break;

            }
        }
        public override void update()
        {
            base.update();
            KeyboardState estado = Keyboard.GetState();
            if (Vivo)
            {
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


                if (estado.IsKeyDown(Keys.Space))
                {
                    if (indicedisparo == 0)
                    {
                        disparar(coordenadas);
                        indicedisparo++;
                    }


                }
                else if (estado.IsKeyUp(Keys.Escape))
                {
                    indicedisparo = 0;
                }
            }
            this.coordenadas = new Microsoft.Xna.Framework.Vector2(coordenadas.X + velocidadX, coordenadas.Y + velocidadY);
            if (coordenadas.Y<= -30)
            {
                coordenadas.Y = -30;
            }
            if (coordenadas.Y>=640)
            {
                coordenadas.Y = 640;
            }

            TimeSpan ts = (DateTime.Now - tiempo);
            if (ts.TotalSeconds > 0.5)
            {
                if (Vivo == false)
                {
                    indice = (indice + 1);
                    if (indice >= 11)
                    { indice = 11; }
                    velocidadX=0; velocidadY=0;
                }
                
                tiempo = DateTime.Now;
            }
        }

    }

}
