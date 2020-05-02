using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class NaveJugador
    {

        //Variables del jugador
        TgcMesh meshjugador;
        private const float VELOCIDAD_DESPLAZAMIENTO = 10f;
        TGCVector3 desplazamiento;
        bool seMovio { set; get; }
        bool seRoto { set; get; }


        public TgcMesh crearInstanciaNave1(string MediaDir)
        {
            TgcSceneLoader loader = new TgcSceneLoader();
            //ship = loader.loadSceneFromFile(MediaDir + "StarWars-Speeder-TgcScene.xml").Meshes[0];
            TgcMesh ship = loader.loadSceneFromFile(MediaDir + "XWing\\xwing-TgcScene.xml").Meshes[0];
            // Al XWIN le falta una aleta.
            ship.Effect = TGCShaders.Instance.LoadEffect(MediaDir + "ShipRoll.fx");
            ship.Technique = "Normal";
            ship.Position = new TGCVector3(0, 0, 5);
            ship.Rotation = new TGCVector3(0, /*FastMath.PI / 2*/0, 0);
            ship.Transform = TGCMatrix.Scaling(TGCVector3.One * 0.05f) * TGCMatrix.RotationYawPitchRoll(ship.Rotation.Y, ship.Rotation.X, ship.Rotation.Z) * TGCMatrix.Translation(ship.Position);
            meshjugador = ship;
            return ship;

        }

        public TgcMesh crearInstanciaNave2(string MediaDir)
        {
            TgcSceneLoader loader = new TgcSceneLoader();
            //ship = loader.loadSceneFromFile(MediaDir + "StarWars-Speeder-TgcScene.xml").Meshes[0];
            TgcMesh ship = loader.loadSceneFromFile(MediaDir + "XWing\\X-Wing-TgcScene.xml").Meshes[0];
            // Al XWIN le falta una aleta.
            ship.Effect = TGCShaders.Instance.LoadEffect(MediaDir + "ShipRoll.fx");
            ship.Technique = "Normal";
            ship.Position = new TGCVector3(0, 0, 5);
            ship.Rotation = new TGCVector3(0, /*FastMath.PI / 2*/0, 0);
            ship.Transform = TGCMatrix.Scaling(TGCVector3.One * 0.05f) * TGCMatrix.RotationYawPitchRoll(ship.Rotation.Y, ship.Rotation.X, ship.Rotation.Z) * TGCMatrix.Translation(ship.Position);

            return ship;

        }

        public void inicializarMovimiento() {

            desplazamiento = TGCVector3.Empty;
            seMovio = false;
            seRoto = false;
        
        }

        public TGCVector3 avanzar(float elapsedTime)
        {
            //Hay que saber que es lo que es el adelante
            seMovio = true;
            desplazamiento.X = VELOCIDAD_DESPLAZAMIENTO* elapsedTime;
            return desplazamiento;


        }

        public TGCVector3 retroceder(float elapsedTime)
        {
            //Hay que saber que es lo que es el atras
            seMovio = true;
            desplazamiento.X = -VELOCIDAD_DESPLAZAMIENTO * elapsedTime;
            return desplazamiento;

        }

        public TGCVector3 desplazarLateralIzq(float elapsedTime)
        {
            //Hay que saber que es lo que es la izq
            seMovio = true;
            desplazamiento.Z = VELOCIDAD_DESPLAZAMIENTO * elapsedTime;
            return desplazamiento;

        }
        public TGCVector3 desplazarLateralDer(float elapsedTime)
        {
            //Hay que saber que es lo que es la derecha
            seMovio = true;
            desplazamiento.Z = -VELOCIDAD_DESPLAZAMIENTO * elapsedTime;
            return desplazamiento;

        }

        public TGCVector3 desplazarArriba(float elapsedTime)
        {
            //Hay que saber que es lo que es la derecha
            seMovio = true;
            desplazamiento.Y = VELOCIDAD_DESPLAZAMIENTO * elapsedTime;
            return desplazamiento;

        }

        public TGCVector3 desplazarAbajo(float elapsedTime)
        {
            //Hay que saber que es lo que es la derecha
            seMovio = true;
            desplazamiento.Y = -VELOCIDAD_DESPLAZAMIENTO * elapsedTime;
            return desplazamiento;

        }



        public void mover() {

            if (seMovio) {

                meshjugador.Position = meshjugador.Position + desplazamiento;
                meshjugador.Transform = TGCMatrix.Scaling(TGCVector3.One * 0.05f) * TGCMatrix.Translation(meshjugador.Position);
                meshjugador.updateBoundingBox();

            }
                     

        }

        void Render() 
        {
            meshjugador.Render();
        }

    }
}
