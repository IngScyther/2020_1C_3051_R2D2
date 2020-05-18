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
            //this.completarLineaDeSuelosX(6, texturaPisoDeMetal, 0, 0, 0, escala);
            // this.completarParedZ((6 + 1), texturaEstrella, 0, 0, 0, escala);
            //this.completarParedZ(6, texturaEstrella, 0, 0, 1 * escala, escala);
            //Pasillo 2 (6x10,0,0) -> (6x10,0,6x10)
            //this.completarLineaDeSuelosZ(6, texturaPisoDeMetal, 6 * escala, 0, 0, escala);
            //this.completarParedX(6, texturaEstrella, (1 + 6) * escala, 0, 0, escala);
            //this.completarParedX(6, texturaEstrella, (0 + 6) * escala, 0, 1 * escala, escala);
            //Pasillo 3 (6x10,0,6x10) -> (6x10,0,12x10)
            //int posz = 8* escala;
            //this.completarLineaDeSuelosX(6, texturaPisoDeMetal, 6 * escala, 0, 6 * escala, escala);
            //this.completarParedZ(5, texturaEstrella, (1 + 6) * escala, 0, 6 * escala, escala);
            // this.completarParedZ((1 + 5), texturaEstrella, (0 + 6) * escala, 0, (1 + 6) * escala, escala);
            //Pared A
            //      A1
            //this.completarParedX(5, texturaEstrella, (0) * escala, 0, (1) * escala, escala);
            //      A1
            //this.completarParedX(5, texturaEstrella, (0) * escala, 0, (-5) * escala, escala);
            //      A1
            //this.completarParedX(5, texturaEstrella, (5) * escala, 0, (1) * escala, escala);
            //      A1
            //this.completarParedX(5, texturaEstrella, (5) * escala, 0, (-5) * escala, escala);


            //Pared B
            //      B1
            //this.completarParedZ((5), texturaEstrella, 0, 0, (5+1) * escala, escala);
            //      B2
            //this.completarParedZ((5), texturaEstrella, 0, 0, (0) * escala, escala);
            //      B3
            //this.completarParedZ((5), texturaEstrella, 0, 0, (1) * escala, escala);
            //      B4
            //this.completarParedZ((5), texturaEstrella, 0, 0, (-5) * escala, escala);

            // Piso 1
            //this.completarLineaDeSuelosX(5, texturaPisoDeMetal, 0, 0, 0, escala);
            // Piso 2
            //this.completarLineaDeSuelosZ(6, texturaPisoDeMetal, 6 * escala, 0, 0, escala);

            //
            this.completarLineaDeSuelosZ(29, texturaPisoDeMetal, 5 * escala, 0, -15 * escala, escala);
            this.completarLineaDeSuelosZ(29, texturaPisoDeMetal, 6 * escala, 0, -15 * escala, escala);
            this.completarLineaDeSuelosZ(29, texturaPisoDeMetal, 7 * escala, 0, -15 * escala, escala);
            this.completarLineaDeSuelosZ(29, texturaPisoDeMetal, 13 * escala, 0, -15 * escala, escala);
            this.completarLineaDeSuelosZ(29, texturaPisoDeMetal, 14 * escala, 0, -15 * escala, escala);
            this.completarLineaDeSuelosZ(29, texturaPisoDeMetal, 15* escala, 0, -15 * escala, escala);
            //this.completarLineaDeSuelosZ(6, texturaPisoDeMetal, 6 * escala, 0, 0, escala);
            //this.completarLineaDeSuelosZ(6, texturaPisoDeMetal, 6 * escala, 0, 0, escala);
            //A
            this.completarCuadrantePared(5, texturaEstrella, 0, 0, 9, escala, 5);
            this.completarCuadrantePiso(5, texturaEstrella, 0, 1, 9, escala, 5);
            this.completarLineaDeSuelosX(21, texturaPisoDeMetal, 0, 0, 0, escala);
            this.completarLineaDeSuelosX(21, texturaPisoDeMetal, 0, 0, -10, escala);
            this.completarLineaDeSuelosX(21, texturaPisoDeMetal, 0, 0, -20, escala);
            //B
            this.completarCuadrantePared(5, texturaEstrella, 0, 0, 1, escala, 5);
            this.completarCuadrantePiso(5, texturaEstrella, 0, 1, 1, escala, 5);
            this.completarLineaDeSuelosX(21, texturaPisoDeMetal, 0, 0, -80, escala);
            this.completarLineaDeSuelosX(21, texturaPisoDeMetal, 0, 0, -90, escala);
            this.completarLineaDeSuelosX(21, texturaPisoDeMetal, 0, 0, -100, escala);

            //C
            this.completarCuadrantePared(5, texturaEstrella, 0, 0, -7, escala, 5);
            this.completarCuadrantePiso(5, texturaEstrella, 0, 1, -7, escala, 5);
            this.completarLineaDeSuelosX(21, texturaPisoDeMetal, 0, 0, 60, escala);
            this.completarLineaDeSuelosX(21, texturaPisoDeMetal, 0, 0, 70, escala);
            this.completarLineaDeSuelosX(21, texturaPisoDeMetal, 0, 0, 80, escala);
            //D
            this.completarCuadrantePared(5, texturaEstrella, 0, 0, -15, escala, 5);
            this.completarCuadrantePiso(5, texturaEstrella, 0, 1, -15, escala, 5);

            //E
            this.completarCuadrantePared(5, texturaEstrella, 8, 0, 9, escala, 5);
            this.completarCuadrantePiso(5, texturaEstrella, 8, 1, 9, escala, 5);

            //F
            this.completarCuadrantePared(5, texturaEstrella, 8, 0, 1, escala, 5);
            this.completarCuadrantePiso(5, texturaEstrella, 8, 1, 1, escala, 5);

            //G
            this.completarCuadrantePared(5, texturaEstrella, 8, 0, -7, escala, 5);
            this.completarCuadrantePiso(5, texturaEstrella, 8, 1, -7, escala, 5);

            //H
            this.completarCuadrantePared(5, texturaEstrella, 8, 0, -15, escala, 5);
            this.completarCuadrantePiso(5, texturaEstrella, 8, 1, -15, escala, 5);

            //I
            this.completarCuadrantePared(5, texturaEstrella, 16, 0, 9, escala, 5);
            this.completarCuadrantePiso(5, texturaEstrella, 16, 1, 9, escala, 5);

            //J
            this.completarCuadrantePared(5, texturaEstrella, 16, 0, 1, escala, 5);
            this.completarCuadrantePiso(5, texturaEstrella, 16, 1, 1, escala, 5);

            //K
            this.completarCuadrantePared(5, texturaEstrella, 16, 0, -7, escala, 5);
            this.completarCuadrantePiso(5, texturaEstrella, 16, 1, -7, escala, 5);

            //L
            this.completarCuadrantePared(5, texturaEstrella, 16, 0, -15, escala, 5);
            this.completarCuadrantePiso(5, texturaEstrella, 16, 1, -15, escala, 5);



            //this.completarCuadrantePiso(5, texturaEstrella, 0, 1, 1, escala, 5);
            //this.completarLineaDeSuelosX(5, texturaEstrella, 0, 10, 10, escala);
            //this.completarLineaDeSuelosX(5, texturaEstrella, 0, 10, 20, escala);
            //this.completarLineaDeSuelosX(5, texturaEstrella, 0, 10, 30, escala);
            //this.completarLineaDeSuelosX(5, texturaEstrella, 0, 10, 40, escala);
            //this.completarLineaDeSuelosX(5, texturaEstrella, 0, 10, 50, escala);
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

        public void completarCuadrantePared(int cantidadDeParedes, string DireccionTextura, float X, float Y, float Z, float escala, int tamaño) {

            this.completarParedX(cantidadDeParedes, DireccionTextura, (X) * escala, (Y) * escala, (Z) * escala, escala);
            this.completarParedZ(cantidadDeParedes, DireccionTextura, (X) * escala, (Y) * escala, (Z) * escala, escala);
            this.completarParedX(cantidadDeParedes, DireccionTextura, (X+ tamaño) * escala, (Y) * escala, (Z) * escala, escala);
            this.completarParedZ(cantidadDeParedes, DireccionTextura, (X) * escala, (Y) * escala, (Z + tamaño) * escala, escala);

        }

        //this.completarCuadrantePiso(5, texturaEstrella, 0, 10, 1, escala, 5);
        public void completarCuadrantePiso(int cantidadDeFilasDePiso, string DireccionTextura, float X, float Y, float Z, float escala, int tamaño)
        {
            float contador;
            for (contador=0;contador< cantidadDeFilasDePiso; contador++) {
                float a = contador * escala;


                this.completarLineaDeSuelosX(cantidadDeFilasDePiso, DireccionTextura, (X * escala), (Y * escala), (Z*escala)+ a, escala);
                //this.completarLineaDeSuelosX(cantidadDeFilasDePiso, DireccionTextura, 0, 10, 10, escala);


            }

            //this.completarLineaDeSuelosX(5, texturaEstrella, 0, 10, 10, escala);
            //this.completarLineaDeSuelosX(5, texturaEstrella, 0, 10, 20, escala);
            //this.completarLineaDeSuelosX(5, texturaEstrella, 0, 10, 30, escala);
            //this.completarLineaDeSuelosX(5, texturaEstrella, 0, 10, 40, escala);
            //this.completarLineaDeSuelosX(5, texturaEstrella, 0, 10, 50, escala);

        }




    }
}
