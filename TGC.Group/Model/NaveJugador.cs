﻿using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX.DirectInput;
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
using System.Drawing;

namespace TGC.Group.Model
{
    public class NaveJugador
    {

        //Variables del jugador
        TgcMesh meshjugador;
        private const float VELOCIDAD_DESPLAZAMIENTO = 10f;
        private const float VELOCIDAD_ROTACION = 120f;
        TGCVector3 desplazamiento;
        bool seMovio { set; get; }
        bool seMoviox { set; get; }
        bool seMovioxx { set; get; }
        bool seRoto { set; get; }
        bool atacar { set; get; }
        float angulox;
        float anguloy;
        float rotacionTotalY;
        float anguloz;
        float Vuela;
        float Vuelax;
        private TgcArrow directionArrow;

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
            

            // Arma Laser

            //Crear linea para mostrar la direccion del movimiento del personaje
            directionArrow = new TgcArrow();
            directionArrow.BodyColor = Color.Red;
            directionArrow.HeadColor = Color.Red;
            directionArrow.Thickness = 0.1f;
            directionArrow.HeadSize = new TGCVector2(0.1f, 0.1f);

            angulox = 0;
            anguloy = 0;
            anguloz = 0;
            rotacionTotalY = FastMath.PI_HALF;

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
            Vuela=0;
            Vuelax = 0;
            seMovio = false;
            seMoviox = false;
            seMovioxx = false;
            seRoto = false;
            atacar = false;


        
        }

        public TGCVector3 avanzar()
        {
            //Hay que saber que es lo que es el adelante
            seMovio = true;
            //desplazamiento.X = VELOCIDAD_DESPLAZAMIENTO* elapsedTime;
            Vuela = VELOCIDAD_DESPLAZAMIENTO;
            return desplazamiento;
        }

        public TGCVector3 retroceder()
        {
            //Hay que saber que es lo que es el atras
            seMovio = true;
            //desplazamiento.X = -VELOCIDAD_DESPLAZAMIENTO;
            Vuela = -VELOCIDAD_DESPLAZAMIENTO;
            return desplazamiento;
        }

        public TGCVector3 desplazarLateralIzq()
        {
            //Hay que saber que es lo que es la izq
            seMoviox = true;
            Vuelax = VELOCIDAD_DESPLAZAMIENTO;
            //desplazamiento.Z = VELOCIDAD_DESPLAZAMIENTO;
            return desplazamiento;
        }

        public TGCVector3 desplazarLateralDer()
        {
            //Hay que saber que es lo que es la derecha
            seMoviox = true;
            Vuelax = -VELOCIDAD_DESPLAZAMIENTO;
            //desplazamiento.Z = -VELOCIDAD_DESPLAZAMIENTO;
            return desplazamiento;
        }

        public TGCVector3 desplazarArriba()
        {
            //Hay que saber que es lo que es la derecha
            seMovioxx = true;
            Vuelax = VELOCIDAD_DESPLAZAMIENTO;
            //desplazamiento.Y = VELOCIDAD_DESPLAZAMIENTO;
            return desplazamiento;

        }

        public TGCVector3 desplazarAbajo(float elapsedTime)
        {
            //Hay que saber que es lo que es la derecha
            seMovioxx = true;
            Vuelax = -VELOCIDAD_DESPLAZAMIENTO;
            //desplazamiento.Y = -VELOCIDAD_DESPLAZAMIENTO * elapsedTime;
            return desplazamiento;

        }



        public void mover(CamaraTPMovimiento Camara1, float ElapsedTime) {

            if (seMovio) {

                //meshjugador.Position = meshjugador.Position + desplazamiento;
                meshjugador.Transform = TGCMatrix.Scaling(TGCVector3.One * 0.05f) * TGCMatrix.RotationYawPitchRoll(meshjugador.Rotation.Y, meshjugador.Rotation.X, meshjugador.Rotation.Z) * TGCMatrix.Translation(meshjugador.Position);
                meshjugador.updateBoundingBox();
                //Camara1.setTargetOffset(meshjugador.Position, -30, 5, 0);

                var moveF = Vuela * ElapsedTime;
                var x = (float)Math.Cos(meshjugador.Rotation.Y) * moveF;
                var z = -(float)Math.Sin(meshjugador.Rotation.Y) * moveF;

                meshjugador.Position += new TGCVector3(x, 0, z);

                meshjugador.Transform = TGCMatrix.Scaling(TGCVector3.One * 0.05f) *
                                      TGCMatrix.RotationYawPitchRoll(meshjugador.Rotation.Y, meshjugador.Rotation.X, meshjugador.Rotation.Z) *
                                      TGCMatrix.Translation(meshjugador.Position);

                Camara1.Target = meshjugador.Position;

            }

            if (seMoviox)
            {

                //meshjugador.Position = meshjugador.Position + desplazamiento;
                meshjugador.Transform = TGCMatrix.Scaling(TGCVector3.One * 0.05f) * TGCMatrix.RotationYawPitchRoll(meshjugador.Rotation.Y, meshjugador.Rotation.X, meshjugador.Rotation.Z) * TGCMatrix.Translation(meshjugador.Position);
                meshjugador.updateBoundingBox();
                //Camara1.setTargetOffset(meshjugador.Position, -30, 5, 0);

                var moveF = Vuelax * ElapsedTime;
                var z = (float)Math.Cos(meshjugador.Rotation.Y) * moveF;
                var x = (float)Math.Sin(meshjugador.Rotation.Y) * moveF;

                meshjugador.Position += new TGCVector3(x, 0, z);

                meshjugador.Transform = TGCMatrix.Scaling(TGCVector3.One * 0.05f) *
                                      TGCMatrix.RotationYawPitchRoll(meshjugador.Rotation.Y, meshjugador.Rotation.X, meshjugador.Rotation.Z) *
                                      TGCMatrix.Translation(meshjugador.Position);

                Camara1.Target = meshjugador.Position;

            }

            if (seMovioxx)
            {

                //meshjugador.Position = meshjugador.Position + desplazamiento;
                meshjugador.Transform = TGCMatrix.Scaling(TGCVector3.One * 0.05f) * TGCMatrix.RotationYawPitchRoll(meshjugador.Rotation.Y, meshjugador.Rotation.X, meshjugador.Rotation.Z) * TGCMatrix.Translation(meshjugador.Position);
                meshjugador.updateBoundingBox();
                //Camara1.setTargetOffset(meshjugador.Position, -30, 5, 0);

                var moveF = Vuelax * ElapsedTime;
                float y = moveF;
                //var z = (float)Math.Cos(meshjugador.Rotation.Y) * moveF;
                //var x = (float)Math.Sin(meshjugador.Rotation.Y) * moveF;

                meshjugador.Position += new TGCVector3(0, y, 0);

                meshjugador.Transform = TGCMatrix.Scaling(TGCVector3.One * 0.05f) *
                                      TGCMatrix.RotationYawPitchRoll(meshjugador.Rotation.Y, meshjugador.Rotation.X, meshjugador.Rotation.Z) *
                                      TGCMatrix.Translation(meshjugador.Position);

                Camara1.Target = meshjugador.Position;

            }

        }

        public void rotarArriba()
        {
            seRoto = true;
            anguloz = VELOCIDAD_ROTACION;
        }

        public void rotarAbajo()
        {
            seRoto = true;
            anguloz = -VELOCIDAD_ROTACION;
        }

        public void rotarIzq()
        {
            seRoto = true;
            anguloy = VELOCIDAD_ROTACION;
        }

        public void rotarDerecha()
        {
            seRoto = true;
            anguloy = -VELOCIDAD_ROTACION;
        }

        public void rotarz(float ElapsedTime, CamaraTPMovimiento Camera)
        {
                
            if (seRoto) { 
                var rotAngle = Geometry.DegreeToRadian(anguloz * ElapsedTime);
                meshjugador.Rotation += new TGCVector3(0, 0, rotAngle);
                Camera.rotateY(rotAngle);
                Camera.Target = meshjugador.Position;
                
            }
            
        }

        public float rotary(float ElapsedTime)
        {
            if (seRoto)
            {
                var rotAngle = Geometry.DegreeToRadian(-anguloy * ElapsedTime);
                meshjugador.Rotation += new TGCVector3(0, rotAngle, 0);
                meshjugador.Transform = TGCMatrix.Scaling(TGCVector3.One * 0.05f) *
                                      TGCMatrix.RotationYawPitchRoll(meshjugador.Rotation.Y, meshjugador.Rotation.X, meshjugador.Rotation.Z) *
                                      TGCMatrix.Translation(meshjugador.Position);

                //Camera.rotateY(rotAngle* ElapsedTime);
                float a = -anguloy * ElapsedTime;

                if (a >= 360) {

                   a = a%360;
                    a *= 360;
                }

                rotacionTotalY += rotAngle;

                return rotAngle;

            }
            else {

                return 0;

            }
            
        }

        public void disparar() {


            // 7) Tenemos un objeto que rota un cierto angulo en Y (ej: un auto) y queremos saber los componentes X,Z para donde tiene que avanzar al moverse
            //var rotacionY = FastMath.PI_HALF;
            var componenteX = FastMath.Sin(rotacionTotalY);
            var componenteZ = FastMath.Cos(rotacionTotalY);
            // float velocidadMovimiento = 100; //Ojo que este valor deberia siempre multiplicarse por el elapsedTime
            //var movimientoAdelante = new TGCVector3(componenteX * velocidadMovimiento, 0, componenteZ * velocidadMovimiento);


            atacar = true;
            directionArrow.PStart = meshjugador.Position;
            directionArrow.PEnd = meshjugador.Position + new TGCVector3(componenteX, 0, componenteZ) * 100;
            directionArrow.updateValues();


        }


        public TGCVector3 Position() {

            return meshjugador.Position;

        }






        public void Render() 
        {
            meshjugador.Render();

            if (atacar == true) {
            
                directionArrow.Render();
            
            }

        }

    }
}
