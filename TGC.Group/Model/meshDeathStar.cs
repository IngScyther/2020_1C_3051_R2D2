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
    class meshDeathStar
    {

        TgcMesh[] meshCompleto;
        
        public void crearInstanciaNave(string MediaDir)
        {
            meshCompleto= new TgcMesh[4];

            TgcSceneLoader loader = new TgcSceneLoader();
            //ship = loader.loadSceneFromFile(MediaDir + "StarWars-Speeder-TgcScene.xml").Meshes[0];

            for (int i = 0; i < 4; i++) {
                meshCompleto[i] = loader.loadSceneFromFile(MediaDir + "XWing\\death+star-TgcScene.xml").Meshes[i];
                // Al XWIN le falta una aleta.
                meshCompleto[i].Effect = TGCShaders.Instance.LoadEffect(MediaDir + "ShipRoll.fx");
                meshCompleto[i].Technique = "Normal";
                meshCompleto[i].Position = new TGCVector3(0, 20, 5);
                meshCompleto[i].Rotation = new TGCVector3(0, /*FastMath.PI / 2*/0, 0);
                meshCompleto[i].Transform = TGCMatrix.Scaling(TGCVector3.One * 10f) 
                    * TGCMatrix.RotationYawPitchRoll(meshCompleto[i].Rotation.Y, meshCompleto[i].Rotation.X, meshCompleto[i].Rotation.Z) 
                    * TGCMatrix.Translation(meshCompleto[i].Position);        
            }

        }

        public void Render() {

            foreach (TgcMesh mesh in meshCompleto)
            {
                mesh.Render();
            }

        }


    }
}
