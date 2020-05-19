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

            torreta = new TorretaAsesina(MediaDir, 10, 10, 15, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 10, 10, 45, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 45, 10, 15, 0.1f);
            terrenoRompible.Add(torreta);
            torreta = new TorretaAsesina(MediaDir, 45, 10, 45, 0.1f);
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
