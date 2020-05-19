using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGC.Core.Collision;
using TGC.Core.Geometry;
using TGC.Core.Mathematica;
using TGC.Core.SceneLoader;
using TGC.Core.Shaders;

namespace TGC.Group.Model
{
    class TorretaAsesina : TipoObjeto
    {


        TgcMesh torreta;
        private TgcArrow directionArrow;
        bool atacar;
        float tiempoDeDisparo;
        float tiempoDeRescarga;
        float rotacionTotalY;
        float rotacionTotalXZ;
        Random random;

        public TorretaAsesina(string MediaDir,float X,float Y,float Z,float escala) {

            TgcSceneLoader loader = new TgcSceneLoader();
            //ship = loader.loadSceneFromFile(MediaDir + "StarWars-Speeder-TgcScene.xml").Meshes[0];
            torreta = loader.loadSceneFromFile(MediaDir + "XWing\\Turbolaser-TgcScene.xml").Meshes[0];
            // Al XWIN le falta una aleta.
            torreta.Effect = TGCShaders.Instance.LoadEffect(MediaDir + "ShipRoll.fx");
            torreta.Technique = "Normal";
            torreta.Position = new TGCVector3(X, Y, Z);
            torreta.Rotation = new TGCVector3(0, /*FastMath.PI / 2*/0, 0);
            torreta.Transform = TGCMatrix.Scaling(TGCVector3.One * escala) * TGCMatrix.RotationYawPitchRoll(torreta.Rotation.Y, torreta.Rotation.X, torreta.Rotation.Z) * TGCMatrix.Translation(torreta.Position);
            directionArrow = new TgcArrow();
            directionArrow.BodyColor = Color.Red;
            directionArrow.HeadColor = Color.Red;
            directionArrow.Thickness = 0.1f;
            directionArrow.HeadSize = new TGCVector2(0.1f, 0.1f);
            random = new Random();

        }
        
        
        
        public void disparar(float ElapsedTime)
        {
            //throw new NotImplementedException();

            if (tiempoDeRescarga > 0)
            {
                atacar = false;
                tiempoDeRescarga -= ElapsedTime;
                tiempoDeDisparo = 0.5f;
                rotacionTotalY+= (float)random.Next(0,10)*0.1f;
                rotacionTotalXZ= (float)random.Next(3, 10)*0.1f;

            }
            else if(tiempoDeRescarga <= 0) {

                if (tiempoDeDisparo >= 0)
                {
                    atacar = true;
                    tiempoDeDisparo -= ElapsedTime;
                    
                    
                    // 7) Tenemos un objeto que rota un cierto angulo en Y (ej: un auto) y queremos saber los componentes X,Z para donde tiene que avanzar al moverse
                    //var rotacionY = FastMath.PI_HALF;
                    var componenteX = FastMath.Sin(rotacionTotalY)* FastMath.Sin(rotacionTotalXZ);
                    var componenteZ = FastMath.Cos(rotacionTotalY)* FastMath.Sin(rotacionTotalXZ);
                    var componeteY = FastMath.Cos(rotacionTotalXZ);
                    if (componeteY < 0)  componeteY= componeteY * -1 ;
                    // float velocidadMovimiento = 100; //Ojo que este valor deberia siempre multiplicarse por el elapsedTime
                    //var movimientoAdelante = new TGCVector3(componenteX * velocidadMovimiento, 0, componenteZ * velocidadMovimiento);
                    atacar = true;
                    directionArrow.PStart = torreta.Position;
                    directionArrow.PEnd = torreta.Position + new TGCVector3(componenteX, componeteY, componenteZ) * 100;
                    directionArrow.updateValues();
                    //rayo1 = new TgcRay(meshjugador.Position, new TGCVector3(componenteX, 0, componenteZ) * 100);
                    //return rayo1;

                }
                else {
                    atacar = false;
                    //var random = new Random();
                    
                    tiempoDeRescarga = 1 * (float)random.Next(1, 7);
                }


            }
            
            
        }

        public void disparar()
        {
            throw new NotImplementedException();
        }

        public void esDañadoBounding(TgcRay rayo)
        {
            throw new NotImplementedException();
        }

        public void inicializar()
        {
            throw new NotImplementedException();
        }

        public void inicializarEstado()
        {
            throw new NotImplementedException();
        }

        public void morir()
        {
            throw new NotImplementedException();
        }

        public void perdervida()
        {
            throw new NotImplementedException();
        }

        public void Render()
        {
            //throw new NotImplementedException();
            torreta.Render();

            if (atacar == true)
            {

                directionArrow.Render();

            }


        }
    }
}
