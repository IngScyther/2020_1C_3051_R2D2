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
    public class terrenoOffline
    {


        private List <TgcPlane> terreno;

        public terrenoOffline(string MediaDir) {
            terreno = new List<TgcPlane>();
            var pathTexturaCaja = MediaDir + Game.Default.TexturaCaja;
            var texturaPisoDeMetal = MediaDir + "//Metal-floor_.png";
            var pathTexturaCaja3 = MediaDir + "//Piso2.jpg";
            var texturaEstrella = MediaDir + "//Color_002.jpg";
            int cantidadEspacio1 = 4;
            int escala = 10;
            // Pasillo 1 (0,0,0) -> (6x10,0,0)
            this.completarLineaDeSuelosX(6, texturaPisoDeMetal, 0, 0, 0, escala);
            this.completarParedZ((6 + 1), texturaEstrella, 0, 0, 0, escala);
            this.completarParedZ(6, texturaEstrella, 0, 0, 1 * escala, escala);
            //Pasillo 2 (6x10,0,0) -> (6x10,0,6x10)
            this.completarLineaDeSuelosZ(6, texturaPisoDeMetal, 6 * escala, 0, 0, escala);
            this.completarParedX(6, texturaEstrella, (1 + 6) * escala, 0, 0, escala);
            this.completarParedX(6, texturaEstrella, (0 + 6) * escala, 0, 1 * escala, escala);
            //Pasillo 3 (6x10,0,6x10) -> (6x10,0,12x10)
            //int posz = 8* escala;
            this.completarLineaDeSuelosX(6, texturaPisoDeMetal, 6 * escala, 0, 6 * escala, escala);
            this.completarParedZ(5, texturaEstrella, (1 + 6) * escala, 0, 6 * escala, escala);
            this.completarParedZ((1 + 5), texturaEstrella, (0 + 6) * escala, 0, (1 + 6) * escala, escala);

        }

        public void completarLineaDeSuelosX(int cantidadDeSuelo, string DireccionTextura, float X, float Y, float Z, float escala)
        {
            //TgcPlane[] suelos = new TgcPlane[cantidadDeSuelo];
            TgcPlane sueloX;
            for (int i = 0; i < cantidadDeSuelo; i++)
            {
                //sueloX = new TgcPlane();
                sueloX = new TgcPlane(new TGCVector3(X, Y, Z), new TGCVector3(escala, escala, escala), TgcPlane.Orientations.XZplane, TgcTexture.createTexture(DireccionTextura), 1f, 1f);
                //suelos[i].AutoAdjustUv = false;
                //suelos[i].updateValues();
                X += escala;
                terreno.Add(sueloX);
            }
        }

        public void completarLineaDeSuelosZ(int cantidadDeSuelo, string DireccionTextura, float X, float Y, float Z, float escala)
        {
            TgcPlane sueloZ;
            //TgcPlane[] suelos = new TgcPlane[cantidadDeSuelo];
            for (int i = 0; i < cantidadDeSuelo; i++)
            {
                sueloZ = new TgcPlane(new TGCVector3(X, Y, Z), new TGCVector3(escala, escala, escala), TgcPlane.Orientations.XZplane, TgcTexture.createTexture(DireccionTextura), 1f, 1f);
                Z += escala;
                terreno.Add(sueloZ);
            }
        }

        public void completarParedZ(int cantidadDeParedes, string DireccionTextura, float X, float Y, float Z, float escala)
        {

            //TgcPlane[] Paredes = new TgcPlane[cantidadDeParedes];
            TgcPlane paredZ;
            for (int i = 0; i < cantidadDeParedes; i++)
            {
                //Paredes[i] = new TgcPlane(new TGCVector3(X, Y, Z), new TGCVector3(escala, escala, escala), TgcPlane.Orientations.XYplane, TgcTexture.createTexture(DireccionTextura), 1f, 1f);
                paredZ = new TgcPlane(new TGCVector3(X, Y, Z), new TGCVector3(escala, escala, escala), TgcPlane.Orientations.XYplane, TgcTexture.createTexture(DireccionTextura), 1f, 1f);
                X += escala;
                terreno.Add(paredZ);
            }
        }


        public void completarParedX(int cantidadDeParedes, string DireccionTextura, float X, float Y, float Z, float escala)
        {
            //TgcPlane[] Paredes = new TgcPlane[cantidadDeParedes];
            TgcPlane paredX;
            for (int i = 0; i < cantidadDeParedes; i++)
            {
                /*Paredes[i]*/
                paredX = new TgcPlane(new TGCVector3(X, Y, Z), new TGCVector3(escala, escala, escala), TgcPlane.Orientations.YZplane, TgcTexture.createTexture(DireccionTextura), 1f, 1f);
                Z += escala;
                terreno.Add(paredX);
            }
        }



        public void mostrarTerreno(/*TgcPlane[] planos*/)
        {
            foreach (TgcPlane plano in terreno)
            {
                plano.Render();
            }
        }
    }
}
