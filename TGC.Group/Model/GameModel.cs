using Microsoft.DirectX.DirectInput;
using System.Drawing;
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

        //Definimos estructuras
        private TgcPlane suelo;

        private TgcPlane[] suelos1;
        private TgcPlane[] paredes11;
        private TgcPlane[] paredes12;
        private TgcPlane[] suelos2;
        private TgcPlane[] paredes21;
        private TgcPlane[] paredes22;
        private TgcPlane[] suelos3;
        private TgcPlane[] paredes31;
        private TgcPlane[] paredes32;
        private TgcPlane pared;
        private TgcPlane pared2;
        

        private TgcMesh jugador;

        private TGCVector3 posicionCamara;
        private TGCVector3 objetivo;

        TgcSkyBox skyBox;








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
            NaveJugador adminave = new NaveJugador();
            jugador = adminave.crearInstanciaNave(MediaDir);


            // Hay que arreglar esta parte terreno offline
            //Textura de la carperta Media. Game.Default es un archivo de configuracion (Game.settings) util para poner cosas.
            //Pueden abrir el Game.settings que se ubica dentro de nuestro proyecto para configurar.
            //Esta textura despues la cambiamos.
            var pathTexturaCaja = MediaDir + Game.Default.TexturaCaja;
            var texturaPisoDeMetal = MediaDir + "//Metal-floor_.png";
            var pathTexturaCaja3 = MediaDir + "//Piso2.jpg";
            var texturaEstrella = MediaDir + "//Color_002.jpg";

            //var pathTexturaCaja3 = MediaDir + "//stones.bpn";
            // var pathTexturaCaja3 = MediaDir + Game.Default.TexturaCaja;

            //Cargamos una textura, tener en cuenta que cargar una textura significa crear una copia en memoria.
            //Es importante cargar texturas en Init, si se hace en el render loop podemos tener grandes problemas si instanciamos muchas.
            var pisoTexture = TgcTexture.createTexture(pathTexturaCaja);

            //Definimos caracteristicas del suelo
            //suelo = new TgcPlane(new TGCVector3(0, 0, 0), new TGCVector3(50, 50, 50), TgcPlane.Orientations.XZplane, pisoTexture, 10f, 10f);

            int cantidadEspacio1 = 4;
            int escala = 10;
            // Pasillo 1 (0,0,0) -> (6x10,0,0)

            suelos1 = completarLineaDeSuelosX(6, texturaPisoDeMetal, 0, 0, 0, escala);
            paredes11 = completarParedZ((6 + 1), texturaEstrella, 0, 0, 0, escala);
            paredes12 = completarParedZ(6, texturaEstrella, 0, 0, 1 * escala, escala);

            //Pasillo 2 (6x10,0,0) -> (6x10,0,6x10)

            suelos2 = completarLineaDeSuelosZ(6, texturaPisoDeMetal, 6 * escala, 0, 0, escala);
            paredes21 = completarParedX(6, texturaEstrella, (1 + 6) * escala, 0, 0, escala);
            paredes22 = completarParedX(6, texturaEstrella, (0 + 6) * escala, 0, 1 * escala, escala);

            //Pasillo 3 (6x10,0,6x10) -> (6x10,0,12x10)
            //int posz = 8* escala;

            suelos3 = completarLineaDeSuelosX(6, pathTexturaCaja, 6 * escala, 0, 6 * escala, escala);
            paredes31 = completarParedZ(5, pathTexturaCaja3, (1 + 6) * escala, 0, 6 * escala, escala);
            paredes32 = completarParedZ((1 + 5), pathTexturaCaja3, (0 + 6) * escala, 0, (1 + 6) * escala, escala);


            
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


        }

        /// <summary>
        ///     Se llama en cada frame.
        ///     Se debe escribir toda la lógica de computo del modelo, así como también verificar entradas del usuario y reacciones
        ///     ante ellas.
        /// </summary>
        public override void Update()
        {
            PreUpdate();

            posicionCamara = Camera.Position;


            //Hay que ver como calcular esto.
            objetivo = Camera.LookAt;

            if (Input.keyPressed(Key.W))
            {
                Camera.SetCamera((Camera.Position + (objetivo - Camera.Position)), Camera.LookAt + (objetivo - Camera.Position));
            }

            if (Input.keyPressed(Key.S))
            {
                Camera.SetCamera((Camera.Position - (objetivo - Camera.Position)), Camera.LookAt - (objetivo - Camera.Position));
            }

            if (Input.keyPressed(Key.A))
            {
                Camera.SetCamera(Camera.Position + new TGCVector3(0, 0, 10f), Camera.LookAt + new TGCVector3(0, 0, 10f));
            }

            if (Input.keyPressed(Key.D))
            {
                Camera.SetCamera(Camera.Position + new TGCVector3(0, 0, -10f), Camera.LookAt + new TGCVector3(0, 0, -10f));
            }

            if (Input.keyPressed(Key.Space))
            {
                Camera.SetCamera(Camera.Position + new TGCVector3(0f, 1f, 0), Camera.LookAt + new TGCVector3(0f, 1f, 0));
            }

            if (Input.keyPressed(Key.LeftControl))
            {
                Camera.SetCamera(Camera.Position + new TGCVector3(0, -1f, 0), Camera.LookAt + new TGCVector3(0, -1f, 0));
            }

            if (Input.keyPressed(Key.UpArrow))
            {
                Camera.SetCamera(Camera.Position, Camera.LookAt + new TGCVector3(0, 5f, 0));
                objetivo = Camera.LookAt;
            }

            if (Input.keyPressed(Key.DownArrow))
            {
                Camera.SetCamera(Camera.Position, Camera.LookAt + new TGCVector3(0, -5f, 0));
                objetivo = Camera.LookAt;
            }

            if (Input.keyPressed(Key.RightArrow))
            {
                Camera.SetCamera(Camera.Position, Camera.LookAt + new TGCVector3(0, 0, -5f));
                objetivo = Camera.LookAt;
            }

            if (Input.keyPressed(Key.LeftArrow))
            {
                Camera.SetCamera(Camera.Position, Camera.LookAt + new TGCVector3(0, 0, 5f));
                objetivo = Camera.LookAt;

            }

            PostUpdate();
        }

        /// <summary>
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


            mostrarArrayPlano(suelos1);
            mostrarArrayPlano(suelos2);
            mostrarArrayPlano(suelos3);
            //pared.Render();
            //pared2.Render();
            mostrarArrayPlano(paredes11);
            mostrarArrayPlano(paredes12);
            mostrarArrayPlano(paredes21);
            mostrarArrayPlano(paredes22);
            mostrarArrayPlano(paredes31);
            mostrarArrayPlano(paredes32);
            skyBox.Render();
            jugador.Render();




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