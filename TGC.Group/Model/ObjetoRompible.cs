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

namespace TGC.Group.Model
{
    class ObjetoRompible
    {
        public bool vivo; //Si esta vivo va TRUE
        public bool reciboDaño;
        public float vida; //ValorPositivo, sino muere.
        public TgcMesh miMesh;
        public TGCBox Box; //ProbarAIM
        public TipoObjeto objeto;

        /*public ObjetoRompible() {

            vivo = true;
            vida = 100;
            Box = TGCBox.fromSize(new TGCVector3(40, 10, -10), new TGCVector3(15, 15, 15), Color.Violet);

        }*/

        public ObjetoRompible(float X, float Y, float Z, float Escala)
        {

            vivo = true;
            vida = 100;
            Box = TGCBox.fromSize(new TGCVector3(X, Y, Z), new TGCVector3(Escala, Escala, Escala), Color.Violet);

        }

        public void perdervida() {

            if (reciboDaño == true) 
            {
                Box.Color = Color.BurlyWood;
                Box.updateValues();

            }
            else {

                Box.Color = Color.Cyan;
                Box.updateValues();

            }


        }

        public void esDañado() {

            reciboDaño = true;
        }

        public void esDañadoBounding(TgcRay rayo)
        {
            TGCVector3 intersection;
            bool pego = TgcCollisionUtils.intersectRayAABB(rayo, Box.BoundingBox, out intersection);

            if (pego) { 
                
                reciboDaño = true;
                
            }


        }



        public void inicializarEstado() {
            reciboDaño = false;            
        }



        public void Render() {

            Box.Transform = TGCMatrix.Scaling(Box.Scale) *
                             TGCMatrix.RotationYawPitchRoll(Box.Rotation.Y, Box.Rotation.X, Box.Rotation.Z) *
                             TGCMatrix.Translation(Box.Position);
            Box.Render();


        }




    }
}
