﻿using Microsoft.DirectX.Direct3D;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGC.Core.BoundingVolumes;
using TGC.Core.Collision;
using TGC.Core.Geometry;
using TGC.Core.Mathematica;
using TGC.Core.SceneLoader;
using TGC.Core.Shaders;

namespace TGC.Group.Model
{
    class NaveCPU
    {
        //Variables del jugador
        TgcMesh meshNave;
        TgcMesh[] meshCompleto;


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
        public TgcRay rayo1;


        public TgcMesh CrearInstanciaNave1(string MediaDir)
        {
            TgcSceneLoader loader = new TgcSceneLoader();
            //ship = loader.loadSceneFromFile(MediaDir + "StarWars-Speeder-TgcScene.xml").Meshes[0];
            TgcMesh ship = loader.loadSceneFromFile(MediaDir + "XWing\\xwing-TgcScene.xml").Meshes[0];
            // Al XWIN le falta una aleta.
            ship.Effect = TGCShaders.Instance.LoadEffect(MediaDir + "ShipRoll.fx");
            ship.Technique = "Normal";
            ship.Position = new TGCVector3(200, 7, -12);
            ship.Rotation = new TGCVector3(0, FastMath.PI / 2, 0);
            ship.Transform = TGCMatrix.Scaling(TGCVector3.One * 0.05f) * TGCMatrix.RotationYawPitchRoll(ship.Rotation.Y, ship.Rotation.X, ship.Rotation.Z) * TGCMatrix.Translation(ship.Position);
            ship.BoundingBox.transform(ship.Transform);
            //ship.UpdateMeshTransform();
            //ship.updateBoundingBox();
            meshNave = ship;


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

        public void RecibirDaño(TgcRay rayo) {

            TGCVector3 intersection;
            //meshNave.UpdateMeshTransform();
            //meshNave.updateBoundingBox();
            //Computar OBB a partir del AABB del mesh. Inicialmente genera el mismo volumen que el AABB, pero luego te permite rotarlo (cosa que el AABB no puede)
            //TgcBoundingOrientedBox obb;
            //obb = TgcBoundingOrientedBox.computeFromAABB(meshNave.BoundingBox);
            //meshNave.Rotation = new TGCVector3(0, FastMath.PI / 4, 0);
            //obb.rotate(new TGCVector3(0, FastMath.PI / 4, 0));

            bool pego = TgcCollisionUtils.intersectRayAABB(rayo, meshNave.BoundingBox, out intersection);

            if (pego)
            {
                meshNave.BoundingBox.setRenderColor(Color.Red);
            }
            else {
                meshNave.BoundingBox.setRenderColor(Color.Yellow);
            }


        }

        public void Disparar()
        {

        }

        public void Avanzar()
        {

        }

        public void PerderVida()
        {

            
        }

        public void Morir()
        {

        }

        public void Render()
        {
            meshNave.Render();
            meshNave.BoundingBox.Render();


        }





    }
}