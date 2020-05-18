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

            ObjetoRompible objeto;
            //Bateria 1
            objeto = new ObjetoRompible(20,10,30,10);
            terrenoRompible.Add(objeto);
            //Bateria 2
            objeto = new ObjetoRompible(20, 10, 110, 10);
            terrenoRompible.Add(objeto);
            //Bateria 3
            objeto = new ObjetoRompible(20, 10, -50, 10);
            terrenoRompible.Add(objeto);
            //Bateria 4
            objeto = new ObjetoRompible(20, 10, -130, 10);
            terrenoRompible.Add(objeto);
            //Bateria 5
            objeto = new ObjetoRompible(100, 10, 30, 10);
            terrenoRompible.Add(objeto);
            //Bateria 6
            objeto = new ObjetoRompible(100, 10, 110, 10);
            terrenoRompible.Add(objeto);
            //Bateria 7
            objeto = new ObjetoRompible(100, 10, -50, 10);
            terrenoRompible.Add(objeto);
            //Bateria 8
            objeto = new ObjetoRompible(100, 10, -130, 10);
            terrenoRompible.Add(objeto);
            //Bateria 9
            objeto = new ObjetoRompible(180, 10, 30, 10);
            terrenoRompible.Add(objeto);
            //Bateria 10
            objeto = new ObjetoRompible(180, 10, 110, 10);
            terrenoRompible.Add(objeto);
            //Bateria 11
            objeto = new ObjetoRompible(180, 10, -50, 10);
            terrenoRompible.Add(objeto);
            //Bateria 12
            objeto = new ObjetoRompible(180, 10, -130, 10);
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
