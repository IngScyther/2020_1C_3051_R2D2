using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class SkyBox
    {


        // Esta funcion crea este skybox
        public TgcSkyBox crearcielo1(string MediaDir) //Hay que ver como hacer para que lea el de el archivo game del media directory
        {

            //Crear SkyBox
            TgcSkyBox skyBox = new TgcSkyBox();
            skyBox.Center = TGCVector3.Empty;
            skyBox.Size = new TGCVector3(10000, 10000, 10000);

            //Configurar color
            //skyBox.Color = Color.OrangeRed;

            //var texturesPath = MediaDir + "Texturas\\Quake\\SkyBox1\\";

            //Configurar las texturas para cada una de las 6 caras
            skyBox.setFaceTexture(TgcSkyBox.SkyFaces.Up, MediaDir + "Arriba.jpg");  //Despues vemos bien las imagenes
            skyBox.setFaceTexture(TgcSkyBox.SkyFaces.Down, MediaDir + "Arriba.jpg"); //Despues vemos bien las imagenes
            skyBox.setFaceTexture(TgcSkyBox.SkyFaces.Left, MediaDir + "Arriba.jpg"); //Despues vemos bien las imagenes
            skyBox.setFaceTexture(TgcSkyBox.SkyFaces.Right, MediaDir + "Arriba.jpg"); //Despues vemos bien las imagenes

            //Hay veces es necesario invertir las texturas Front y Back si se pasa de un sistema RightHanded a uno LeftHanded
            skyBox.setFaceTexture(TgcSkyBox.SkyFaces.Front, MediaDir + "Arriba.jpg"); //Despues vemos bien las imagenes
            skyBox.setFaceTexture(TgcSkyBox.SkyFaces.Back, MediaDir + "Arriba.jpg"); //Despues vemos bien las imagenes
            skyBox.SkyEpsilon = 25f;
            //Inicializa todos los valores para crear el SkyBox
            skyBox.Init();
            return skyBox;

        }


    }

    

    


}
