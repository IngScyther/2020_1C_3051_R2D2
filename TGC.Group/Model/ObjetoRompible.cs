using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGC.Core.Geometry;
using TGC.Core.Mathematica;
using TGC.Core.SceneLoader;

namespace TGC.Group.Model
{
    class ObjetoRompible
    {
        public bool vivo; //Si esta vivo va TRUE
        public bool reviboDaño;
        public float vida; //ValorPositivo, sino muere.
        public TgcMesh miMesh;
        public TGCBox Box; //ProbarAIM

        public ObjetoRompible() {

            vivo = true;
            vida = 100;
            Box = TGCBox.fromSize(new TGCVector3(-50, 10, -20), new TGCVector3(15, 15, 15), Color.Violet);

        }

        public void perdervida() {

            if (reviboDaño == true) 
            {
                Box.Color = Color.Red;
                Box.updateValues();

            }
            else {

                Box.Color = Color.Violet;
                Box.updateValues();

            }


        }

        public void esDañado() {
            
            reviboDaño = true;
        }

        public void inicializarEstado() {
            reviboDaño = false;            
        }



        public void Render() {

            Box.Transform = TGCMatrix.Scaling(Box.Scale) *
                             TGCMatrix.RotationYawPitchRoll(Box.Rotation.Y, Box.Rotation.X, Box.Rotation.Z) *
                             TGCMatrix.Translation(Box.Position);
            Box.Render();


        }




    }
}
