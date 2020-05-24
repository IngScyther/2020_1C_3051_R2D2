using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGC.Core.Collision;
using TGC.Core.Mathematica;

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
            
            //Adelante
            Agregar(DirMedia, 0, 0, 70, 0);
            Agregar(DirMedia, 0, 0, 70, -150);
            //DER
            Agregar(DirMedia, FastMath.PI * 1 / 2, 140, 30, 203);
            //Atras
            Agregar(DirMedia, FastMath.PI, 160, 70, 0);
            Agregar(DirMedia, FastMath.PI, 160, 70, 150);
            //IZQ
            Agregar(DirMedia, FastMath.PI*3/2, 30, 30, -160);


        }


        public void Avanzar(float ElapsedTime) {

            foreach (NaveCPU naveCPU in NavesEnElMundo)
            {
                naveCPU.Avanzar(ElapsedTime);
            }
        }

        public void RecibirDaño(float ElapsedTime, TgcRay rayo)
        {

            foreach (NaveCPU naveCPU in NavesEnElMundo)
            {
                naveCPU.RecibirDaño(rayo);
            }
        }

        public void Render() {

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
