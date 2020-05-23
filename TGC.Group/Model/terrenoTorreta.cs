using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TGC.Group.Model
{
    class terrenoTorreta
    {
        List<TorretaAsesina> terrenoRompible;

        public terrenoTorreta(string MediaDir) {

            terrenoRompible = new List<TorretaAsesina>();
            //TorretaAsesina torreta;

            //A
            posicionarCuadrante(MediaDir, 10, 10, 15, 0.1f);
            //B
            posicionarCuadrante(MediaDir, 10, 10, 15+80, 0.1f);
            //C
            posicionarCuadrante(MediaDir, 10, 10, 15-80, 0.1f);
            //D
            posicionarCuadrante(MediaDir, 10, 10, 15 - 80 * 2, 0.1f);
            //E
            posicionarCuadrante(MediaDir, 10 + 80, 10, 15, 0.1f);
            //F
            posicionarCuadrante(MediaDir, 10 + 80, 10, 15 + 80, 0.1f);
            //G
            posicionarCuadrante(MediaDir, 10 + 80, 10, 15 - 80, 0.1f);
            //H
            posicionarCuadrante(MediaDir, 10 + 80, 10, 15 - 80*2, 0.1f);
            //I
            posicionarCuadrante(MediaDir, 10 + 80*2, 10, 15, 0.1f);
            //J
            posicionarCuadrante(MediaDir, 10 + 80*2, 10, 15 + 80, 0.1f);
            //K
            posicionarCuadrante(MediaDir, 10 + 80*2, 10, 15 - 80, 0.1f);
            //L
            posicionarCuadrante(MediaDir, 10 + 80*2, 10, 15 - 80*2, 0.1f);

        }

        private void posicionarCuadrante(string MediaDir, float x,float y,float z, float escala) {

            TorretaAsesina torreta;
            //torreta = new TorretaAsesina(MediaDir, 10, 10, 15, 0.1f);
            torreta = new TorretaAsesina(MediaDir, x, y, z, escala);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, x, y, z + 30, escala);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, x + 35, y, z, escala);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, x + 35, y, z + 30, escala);
            terrenoRompible.Add(torreta);


        } 

        public void disparar(float ElapsedTime) {

            foreach (TorretaAsesina torreta in terrenoRompible)
            {
                torreta.disparar(ElapsedTime);
            }

        }

        public void Render()
        {
            foreach (TorretaAsesina plano in terrenoRompible)
            {
                plano.Render();
            }
        }


    }
}
