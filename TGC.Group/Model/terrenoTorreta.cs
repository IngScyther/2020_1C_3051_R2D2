using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGC.Group.Model
{
    class terrenoTorreta
    {
        List<TorretaAsesina> terrenoRompible;

        public terrenoTorreta(string MediaDir) {

            terrenoRompible = new List<TorretaAsesina>();
            TorretaAsesina torreta;

            //A
            torreta = new TorretaAsesina(MediaDir, 10, 10, 15, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 10, 10, 45, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 45, 10, 15, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 45, 10, 45, 0.1f);
            terrenoRompible.Add(torreta);
            //B
            torreta = new TorretaAsesina(MediaDir, 10, 10, 15 + 80, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 10, 10, 45 + 80, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 45, 10, 15 + 80, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 45, 10, 45 + 80, 0.1f);
            terrenoRompible.Add(torreta);
            //C
            torreta = new TorretaAsesina(MediaDir, 10, 10, 15 - 80, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 10, 10, 45 - 80, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 45, 10, 15 - 80, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 45, 10, 45 - 80, 0.1f);
            terrenoRompible.Add(torreta);
            //D
            torreta = new TorretaAsesina(MediaDir, 10, 10, 15 - 80*2, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 10, 10, 45 - 80 * 2, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 45, 10, 15 - 80 * 2, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 45, 10, 45 - 80 * 2, 0.1f);
            terrenoRompible.Add(torreta);

            //E
            torreta = new TorretaAsesina(MediaDir, 10+80, 10, 15, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 10 + 80, 10, 45, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 45 + 80, 10, 15, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 45 + 80, 10, 45, 0.1f);
            terrenoRompible.Add(torreta);
            //F
            torreta = new TorretaAsesina(MediaDir, 10 + 80, 10, 15 + 80, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 10 + 80, 10, 45 + 80, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 45 + 80, 10, 15 + 80, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 45 + 80, 10, 45 + 80, 0.1f);
            terrenoRompible.Add(torreta);
            //G
            torreta = new TorretaAsesina(MediaDir, 10 + 80, 10, 15 - 80, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 10 + 80, 10, 45 - 80, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 45 + 80, 10, 15 - 80, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 45 + 80, 10, 45 - 80, 0.1f);
            terrenoRompible.Add(torreta);
            //H
            torreta = new TorretaAsesina(MediaDir, 10 + 80, 10, 15 - 80 * 2, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 10 + 80, 10, 45 - 80 * 2, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 45 + 80, 10, 15 - 80 * 2, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 45 + 80, 10, 45 - 80 * 2, 0.1f);
            terrenoRompible.Add(torreta);

            //I
            torreta = new TorretaAsesina(MediaDir, 10 + 80 * 2, 10, 15, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 10 + 80 * 2, 10, 45, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 45 + 80 * 2, 10, 15, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 45 + 80 * 2, 10, 45, 0.1f);
            terrenoRompible.Add(torreta);
            //J
            torreta = new TorretaAsesina(MediaDir, 10 + 80 * 2, 10, 15 + 80, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 10 + 80 * 2, 10, 45 + 80, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 45 + 80 * 2, 10, 15 + 80, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 45 + 80 * 2, 10, 45 + 80, 0.1f);
            terrenoRompible.Add(torreta);
            //K
            torreta = new TorretaAsesina(MediaDir, 10 + 80, 10, 15 - 80, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 10 + 80 * 2, 10, 45 - 80, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 45 + 80 * 2, 10, 15 - 80, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 45 + 80 * 2, 10, 45 - 80, 0.1f);
            terrenoRompible.Add(torreta);
            //L
            torreta = new TorretaAsesina(MediaDir, 10 + 80*2, 10, 15 - 80 * 2, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 10 + 80 * 2, 10, 45 - 80 * 2, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 45 + 80 * 2, 10, 15 - 80 * 2, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 45 + 80 * 2, 10, 45 - 80 * 2, 0.1f);
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
