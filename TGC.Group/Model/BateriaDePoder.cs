using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGC.Core.Collision;
using TGC.Core.Geometry;
using TGC.Core.Mathematica;

namespace TGC.Group.Model
{
    class BateriaDePoder : TipoObjeto
    {

        public bool vivo; //Si esta vivo va TRUE
        public bool reciboDaño;
        public float vida; //ValorPositivo, sino muere.
        public TGCBox Box; //ProbarAIM
        public TipoObjeto objeto;

        BateriaDePoder(float X, float Y, float Z, float Escala) {

            Box = TGCBox.fromSize(new TGCVector3(X, Y, Z), new TGCVector3(Escala, Escala, Escala), Color.Violet);

        }

        public void disparar()
        {
            throw new NotImplementedException();
        }

        public void esDañadoBounding(TgcRay rayo)
        {
            //throw new NotImplementedException();
            TGCVector3 intersection;
            bool pego = TgcCollisionUtils.intersectRayAABB(rayo, Box.BoundingBox, out intersection);

            if (pego)
            {

                reciboDaño = true;

            }

        }

        public void inicializar()
        {
            throw new NotImplementedException();
        }

        public void inicializarEstado()
        {
            //throw new NotImplementedException();
            reciboDaño = false;
        }

        public void morir()
        {
            throw new NotImplementedException();
        }

        public void perdervida()
        {
            //throw new NotImplementedException();
            if (reciboDaño == true)
            {
                Box.Color = Color.BurlyWood;
                Box.updateValues();

            }
            else
            {

                Box.Color = Color.Cyan;
                Box.updateValues();

            }
        }

        public void Render()
        {
            //throw new NotImplementedException();
            Box.Transform = TGCMatrix.Scaling(Box.Scale) *
                             TGCMatrix.RotationYawPitchRoll(Box.Rotation.Y, Box.Rotation.X, Box.Rotation.Z) *
                             TGCMatrix.Translation(Box.Position);
            Box.Render();
        }
    }
}
