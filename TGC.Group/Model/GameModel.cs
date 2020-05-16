using Microsoft.DirectX.DirectInput;
using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using TGC.Core.Camara;
using TGC.Core.Direct3D;
using TGC.Core.Example;
using TGC.Core.Geometry;
using TGC.Core.Input;
using TGC.Core.Mathematica;
using TGC.Core.SceneLoader;
using TGC.Core.Shaders;
using TGC.Core.Terrain;
using TGC.Core.Textures;

namespace TGC.Group.Model
{
    /// <summary>
    ///     Ejemplo para implementar el TP.
    ///     Inicialmente puede ser renombrado o copiado para hacer más ejemplos chicos, en el caso de copiar para que se
    ///     ejecute el nuevo ejemplo deben cambiar el modelo que instancia GameForm <see cref="Form.GameForm.InitGraphics()" />
    ///     line 97.
    /// </summary>
    public class GameModel : TGCExample
    {
        /// <summary>
        ///     Constructor del juego.
        /// </summary>
        /// <param name="mediaDir">Ruta donde esta la carpeta con los assets</param>
        /// <param name="shadersDir">Ruta donde esta la carpeta con los shaders</param>
        public GameModel(string mediaDir, string shadersDir) : base(mediaDir, shadersDir)
        {
            Category = Game.Default.Category;
            Name = Game.Default.Name;
            Description = Game.Default.Description;
        }

        // Jugador Arreglar Esto sacar todos estos TgcMesh
        private TgcMesh jugador;

        private TgcMesh DeathStar;
        private TgcMesh DeathStar2;
        private TgcMesh DeathStar3;
        private TgcMesh DeathStar4;
        private TgcMesh DeathStar5;

        private terrenoOffline terreno;
        ObjetoRompible unaCaja;

        private TGCVector3 posicionCamara;
        private TGCVector3 objetivo;

        TgcScene Scene;
        NaveJugador unJugador;
        TgcSkyBox skyBox;
        CamaraTPEstatica Camara0;
        CamaraTPMovimiento Camara1;
        float rotarEnY;



        

        private TgcPlane[] completarLineaDeSuelosX(int cantidadDeSuelo, string DireccionTextura, float X, float Y, float Z, float escala)
        {


            TgcPlane[] suelos = new TgcPlane[cantidadDeSuelo];


            for (int i = 0; i < cantidadDeSuelo; i++)
            {


                suelos[i] = new TgcPlane(new TGCVector3(X, Y, Z), new TGCVector3(escala, escala, escala), TgcPlane.Orientations.XZplane, TgcTexture.createTexture(DireccionTextura), 1f, 1f);
                //suelos[i].AutoAdjustUv = false;
                //suelos[i].updateValues();

                X += escala;


            }

            return suelos;

        }

        private TgcPlane[] completarLineaDeSuelosZ(int cantidadDeSuelo, string DireccionTextura, float X, float Y, float Z, float escala)
        {


            TgcPlane[] suelos = new TgcPlane[cantidadDeSuelo];


            for (int i = 0; i < cantidadDeSuelo; i++)
            {


                suelos[i] = new TgcPlane(new TGCVector3(X, Y, Z), new TGCVector3(escala, escala, escala), TgcPlane.Orientations.XZplane, TgcTexture.createTexture(DireccionTextura), 1f, 1f);

                Z += escala;


            }

            return suelos;

        }

        private TgcPlane[] completarParedZ(int cantidadDeParedes, string DireccionTextura, float X, float Y, float Z, float escala)
        {


            TgcPlane[] Paredes = new TgcPlane[cantidadDeParedes];


            for (int i = 0; i < cantidadDeParedes; i++)
            {


                Paredes[i] = new TgcPlane(new TGCVector3(X, Y, Z), new TGCVector3(escala, escala, escala), TgcPlane.Orientations.XYplane, TgcTexture.createTexture(DireccionTextura), 1f, 1f);

                X += escala;


            }

            return Paredes;

        }


        private TgcPlane[] completarParedX(int cantidadDeParedes, string DireccionTextura, float X, float Y, float Z, float escala)
        {


            TgcPlane[] Paredes = new TgcPlane[cantidadDeParedes];


            for (int i = 0; i < cantidadDeParedes; i++)
            {


                Paredes[i] = new TgcPlane(new TGCVector3(X, Y, Z), new TGCVector3(escala, escala, escala), TgcPlane.Orientations.YZplane, TgcTexture.createTexture(DireccionTextura), 1f, 1f);

                Z += escala;


            }

            return Paredes;

        }



        private void mostrarArrayPlano(TgcPlane[] planos)
        {

            foreach (TgcPlane plano in planos)
            {


                plano.Render();


            }

        }




        public override void Init()
        {

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Device de DirectX para crear primitivas.
            var d3dDevice = D3DDevice.Instance.Device;

            //Crear SkyBox
            SkyBox adminskybox = new SkyBox();
            skyBox = adminskybox.crearcielo1(MediaDir);

            //Cargar unJugador
            unJugador = new NaveJugador();
            jugador = unJugador.crearInstanciaNave1(MediaDir);

            //Parte nave1
            meshDeathStar adminave1 = new meshDeathStar();
            DeathStar = adminave1.crearInstanciaNave(MediaDir);

            //Parte torreta1
            meshTorreta adminave2 = new meshTorreta();
            DeathStar2 = adminave2.crearInstanciaTurboLaser(MediaDir);

            //Parte Q2
            meshQ2 adminave3 = new meshQ2();
            DeathStar3 = adminave3.crearInstanciaNave(MediaDir);

            //Parte nave4
            meshHierros adminave4 = new meshHierros();
            DeathStar4 = adminave4.crearInstanciaNave(MediaDir);

            //Parte nave5
            meshPipeline adminave5 = new meshPipeline();
            DeathStar5 = adminave5.crearInstanciartuveria1(MediaDir);

            //Creamos terreno
            terreno = new terrenoOffline(MediaDir);

            //CreamosObjetoRompible
            unaCaja = new ObjetoRompible();


            

            
            // Hay que arreglar esta parte.
            //Suelen utilizarse objetos que manejan el comportamiento de la camara.
            //Lo que en realidad necesitamos gráficamente es una matriz de View.
            //El framework maneja una cámara estática, pero debe ser inicializada.
            //Posición de la camara.
            //var cameraPosition = new TGCVector3(5, 5, 5);
            var cameraPosition = new TGCVector3(-20, 15, 5);
            

            //Quiero que la camara mire hacia el origen (0,0,0).
            //var lookAt = TGCVector3.Empty;
            var lookAt = new TGCVector3(10, 5, 5);
            //var lookAt = new TGCVector3(30, 0, 0);
            //Configuro donde esta la posicion de la camara y hacia donde mira.
            Camera.SetCamera(cameraPosition, lookAt);
            //Internamente el framework construye la matriz de view con estos dos vectores.
            //Luego en nuestro juego tendremos que crear una cámara que cambie la matriz de view con variables como movimientos o animaciones de escenas.
            Camara1 = new CamaraTPMovimiento();
            //Camara1.Eye = new TGCVector3(10, 5, 5);
            //Camara1.Target = new TGCVector3(0, 0, 5);
            //Camera = Camara1;
            
            //Camara1.Eye = new TGCVector3(-10, 10, 5);
            //Camara1.UpdateCamera(ElapsedTime);
            Camara1.setTargetOffset(new TGCVector3(0, 0, 5), -30, 5,0);
            //Camara1.SetCamera(new TGCVector3(-10, 10, 5), new TGCVector3(0, 0, 5));
            
            //Camara1.Eye = new TGCVector3(0, 0, 5);
            Camara0 = new CamaraTPEstatica(jugador.Position, 10,100);
            //Camara1.setOrientation(new TGCVector3(-15, 01, -15));
            Camera = Camara1;
            //Camara0.LookAt(new TGCVector3(0, 0, 5));
            TGCVector3 poscamara = new TGCVector3(1,0,0);
            //Camara0 = new CamaraTPEstatica(poscamara,10,10);
            // Camara0.rotateY(-1.6f);
            rotarEnY = 0;
            // Camera = Camara0;
        }

        /// <summary>
        ///     Se llama en cada frame.
        ///     Se debe escribir toda la lógica de computo del modelo, así como también verificar entradas del usuario y reacciones
        ///     ante ellas.
        /// </summary>
        public override void Update()
        {
            PreUpdate();


            unJugador.inicializarMovimiento();
            unaCaja.inicializarEstado();
            //rotarEnY = 0;
            //Meterlo en un procedimiento.
            //jugador.Transform = TGCMatrix.Scaling(TGCVector3.One * 0.05f) * TGCMatrix.RotationYawPitchRoll(jugador.Rotation.Y, jugador.Rotation.X, jugador.Rotation.Z) * TGCMatrix.Translation(jugador.Position);

            
            if (Input.buttonDown(TgcD3dInput.MouseButtons.BUTTON_LEFT))
            {
                //Camera.SetCamera((Camera.Position + (objetivo - Camera.Position)), Camera.LookAt + (objetivo - Camera.Position));
                //jugador.Position+= new TGCVector3(0.1f, 0, 0);
                //Camara1.setTargetOffset(jugador.Position, -10, 5, 0);
                unJugador.disparar();
                unaCaja.esDañado();
            }

            // Mover Nave
            if (Input.keyDown(Key.W))
            {
                unJugador.avanzar();
            }

            if (Input.keyDown(Key.S))
            {
                unJugador.retroceder();
            }

            if (Input.keyDown(Key.A))
            {
                unJugador.desplazarLateralIzq();
            }

            if (Input.keyDown(Key.D))
            {
                unJugador.desplazarLateralDer();
            }


            if (Input.keyDown(Key.Space))
            {
                unJugador.desplazarArriba();
            }

            if (Input.keyDown(Key.LeftControl))
            {
                unJugador.desplazarAbajo(ElapsedTime);
            }
            unJugador.mover(Camara1, ElapsedTime);

            // Botones raros. No se por que no rota-

            if (Input.keyDown(Key.Q))
            {
                Camara1.rotateY(+10000*ElapsedTime);
                Camara1.UpdateCamera(ElapsedTime);
            }

            if (Input.keyDown(Key.E))
            {
                Camara1.rotateY(-10000* ElapsedTime);
                Camara1.UpdateCamera(ElapsedTime);
            }

            if (Input.keyDown(Key.I))
            {
                Camara1.setTargetOffset(jugador.Position, -10, 5, 0);
            }

            if (Input.keyDown(Key.U))
            {

                Camara1.setTargetOffset(jugador.Position, -30, 5, 0);
            }


            // RotarNave
            if (Input.keyDown(Key.UpArrow))
            {
                unJugador.rotarArriba();
                //Camara1.rotateY(100 * ElapsedTime);
            }

            //Camara1.rotateY(10 * ElapsedTime);

            if (Input.keyDown(Key.DownArrow))
            {
                unJugador.rotarAbajo();
            }

            if (Input.keyDown(Key.RightArrow))
            {
                unJugador.rotarDerecha();
                //rotarEnY += 120f;
                //Camara1.rotateY(120f * ElapsedTime);
            }

            if (Input.keyDown(Key.LeftArrow))
            {
                unJugador.rotarIzq();
                //rotarEnY -= 120f;
                //Camara1.rotateY(rotarEnY);
            }

            //Arreglar
            float X = (Camera.Position.X - unJugador.Position().X);
            float Z = (Camera.Position.Z - unJugador.Position().Z);
            double sqrt = Math.Sqrt(X * X + Z * Z);
            Camara1.rotateY(((float)sqrt * 9f * unJugador.rotary(ElapsedTime)));
            
            unaCaja.perdervida();

            PostUpdate();
        }
        
        ///     Se llama cada vez que hay que refrescar la pantalla.
        ///     Escribir aquí todo el código referido al renderizado.
        ///     Borrar todo lo que no haga falta.
        /// </summary>
        public override void Render()
        {
            //Inicio el render de la escena, para ejemplos simples. Cuando tenemos postprocesado o shaders es mejor realizar las operaciones según nuestra conveniencia.
            PreRender();

            //Dibuja un texto por pantalla
            DrawText.drawText("Con la tecla F NO se dibuja el bounding box.", 0, 20, Color.LightSalmon);
            DrawText.drawText("Botones W A S D CTRL SPACE Y las Fechas.\n Al actualizar el Core dejo de funcionar: " + TGCVector3.PrintTGCVector3(Camera.Position), 0, 35, Color.LightSalmon);

            terreno.mostrarTerreno();
        
            skyBox.Render();
            
            unJugador.Render();
            DeathStar.Render();
            DeathStar2.Render();
            unaCaja.Render();

            //Finaliza el render y presenta en pantalla, al igual que el preRender se debe para casos puntuales es mejor utilizar a mano las operaciones de EndScene y PresentScene
            PostRender();
        }

        /// <summary>
        ///     Se llama cuando termina la ejecución del ejemplo.
        ///     Hacer Dispose() de todos los objetos creados.
        ///     Es muy importante liberar los recursos, sobretodo los gráficos ya que quedan bloqueados en el device de video.
        /// </summary>
        public override void Dispose()
        {
            //Dispose del mesh.
            //suelo.Dispose();
        }
    }
}