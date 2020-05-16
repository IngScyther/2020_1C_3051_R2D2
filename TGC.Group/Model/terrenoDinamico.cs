using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGC.Core.Collision;

namespace TGC.Group.Model
{
    class terrenoDinamico
    {
        List<ObjetoRompible> terrenoRompible;


        public terrenoDinamico() {

            

            terrenoRompible = new List<ObjetoRompible>();

            //Bateria 1
            ObjetoRompible objeto = new ObjetoRompible(30,10,-20,10);
            terrenoRompible.Add(objeto);
            //Bateria 2
            objeto = new ObjetoRompible(40, 10, -20, 10);
            terrenoRompible.Add(objeto);
            //Bateria 3
            objeto = new ObjetoRompible(60, 10, 20, 10);
            terrenoRompible.Add(objeto);

        }


        public void agregar(ObjetoRompible objetoRompible) { 
        
        
        }

        public void quitar(ObjetoRompible objetoRompible)
        {


        }

        //inicializamos un par de objetos para romper asi se gana el juego.
        public void inicializarObjetosRompibles() {



            //return this;
        }

        public void mostrarObjetosRompibles()
        {
            foreach (ObjetoRompible plano in terrenoRompible)
            {
                plano.Render();
            }
        }

        public void dañarBounding(TgcRay rayo)
        {
            foreach (ObjetoRompible objeto in terrenoRompible)
            {
                objeto.esDañadoBounding(rayo);
            }
        }

        public void perderVida()
        {
            foreach (ObjetoRompible objeto in terrenoRompible)
            {
                objeto.perdervida();
            }
        }

        public void inicializarEstadoInternoDeLosObjetos()
        {
            foreach (ObjetoRompible objeto in terrenoRompible)
            {
                objeto.inicializarEstado();
            }
        }

    }
}
