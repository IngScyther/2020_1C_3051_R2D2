using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGC.Group.Model
{
    class terrenoNave
    {
        List<NaveCPU> NavesEnElMundo;
        

        public terrenoNave() {
            NavesEnElMundo = new List<NaveCPU>();   
        }

        public void cargarNaves1(string DirMedia) {

            //Agregar(string DirMedia,float anguloenrad, float X, float Y, float Z)
            Agregar(DirMedia, 1.57f, 70, 43, 203);
            Agregar(DirMedia, 1.57f, 140, 43, 203);
            //
            Agregar(DirMedia, 0f, 0, 43, 203);
            Agregar(DirMedia, 0f, 0, 0, 0);


        }


        public void avanzar(float ElapsedTime) {

            foreach (NaveCPU naveCPU in NavesEnElMundo)
            {
                naveCPU.Avanzar(ElapsedTime);
            }


        }

        public void render() {

            foreach (NaveCPU naveCPU in NavesEnElMundo)
            {
                naveCPU.Render();
            }
        }

        private void Agregar(string DirMedia,float anguloenrad, float X, float Y, float Z) 
        {
            NaveCPU NuevaNave = new NaveCPU();
            NuevaNave.CrearInstanciaNave1(DirMedia, anguloenrad, X, Y, Z);
            NavesEnElMundo.Add(NuevaNave);
        }
        




    }
}
