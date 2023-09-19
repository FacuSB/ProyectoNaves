using Cocos2D;
using CocosDenshion;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace ProyectoNaves
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Jugador jugador;
        Fondo fondo;
        Fondo fondo1;
        Turbo turbo;
        List<Disparo> disparos = new List<Disparo>();
        List<Enemigo> enemigos = new List<Enemigo>();
        Texto texto;
        Texto texto1;

        int puntaje=0;

        DateTime tiempo = DateTime.Now;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";



        }


        protected override void Initialize()
        {

            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;
            graphics.ApplyChanges();

            jugador = new Jugador();
            jugador.Cargarcontenido(Content);

            fondo = new Fondo();
            fondo.Cargarcontenido(Content);

            texto = new Texto();
            texto.Cargarcontenido(Content);

            texto1 = new Texto();
            texto1.Cargarcontenido(Content);
            texto1.Text = " ";
            texto1.Font = Content.Load<SpriteFont>(@"fonts/MarkerFelt-64");
            texto1.coordenadas= new Vector2(350,300);
            texto1.color = Color.Red;

            fondo1 = new Fondo();
            fondo1.Cargarcontenido(Content);
            fondo1.coordenadas = new Vector2(1280,0);





            turbo = new Turbo();
            turbo.Cargarcontenido(Content);

            jugador.disparar += Jugador_disparar;
            
        }

        private void Jugador_disparar(Vector2 disparo)
        {
            Disparo disparoo;
            disparoo = new Disparo();
            disparoo.Cargarcontenido(Content);
            disparoo.coordenadas = new Vector2(jugador.coordenadas.X+100,jugador.coordenadas.Y+37);


            disparos.Add(disparoo);



        }



        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                ExitGame();
            }
            if (jugador.Vivo)
            {
                
                fondo.update();
                fondo1.update();

                turbo.update();
                jugador.update();

                texto.update();
                texto.Text = "Puntaje : " + puntaje.ToString();

                Window.Title="Puntos: " + puntaje.ToString();

                if ((DateTime.Now - tiempo).TotalSeconds > 1)
                {
                    Enemigo enemigo = new Enemigo();
                    enemigo = new Enemigo();
                    if (enemigo.coordenadas.X > -150)
                    {
                        enemigo.Cargarcontenido(Content);
                    }
                    enemigos.Add(enemigo);
                    tiempo = DateTime.Now;
                }
                foreach (Disparo disparoo in disparos)
                {

                    disparoo.update();


                }
                foreach (Enemigo enemigo in enemigos)
                {
                    if (enemigo.coordenadas.X > -150)
                    {
                        enemigo.update();
                        enemigo.Detectarimpacto(disparos);
                        enemigo.Dañar(jugador);
                    }

                }

                int indice = enemigos.Count - 1;
                while (indice >= 0)
                {
                    if (enemigos[indice].indice>=6)
                    {
                        enemigos.Remove(enemigos[indice]);
                        puntaje += 20;
                    }
                    indice--;
                }
                int indice2 = disparos.Count - 1;
                while (indice2 >= 0)
                {
                    if (disparos[indice2].indice >= 8)
                    {
                        disparos.Remove(disparos[indice2]);
                    }
                    indice2--;
                }

            }
            else if (!jugador.Vivo) 
            {
                Window.Title = "GAME OVER       Puntaje Final: " + puntaje.ToString();
                texto1.Text = "GAME OVER";
                jugador.update();
                turbo.coordenadas =new Vector2(jugador.coordenadas.X ,jugador.coordenadas.Y+50);
            }
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            fondo.dibujar(spriteBatch);
            fondo1.dibujar(spriteBatch);
            turbo.dibujar(spriteBatch);
            foreach (Enemigo enemigo in enemigos)
            {
                if (enemigo.coordenadas.X > -150)
                { enemigo.dibujar(spriteBatch); }

            }
            jugador.dibujar(spriteBatch);
            foreach (Disparo disparoo in disparos)
            {   
                disparoo.dibujar(spriteBatch); 
                
            }

            texto.dibujar(spriteBatch);
            texto1.dibujar(spriteBatch);
            





            spriteBatch.End();  

            base.Draw(gameTime);
        }

        private void ExitGame()
        {
            CCSimpleAudioEngine.SharedEngine.RestoreMediaState();
            Exit();
        }
    }
}
