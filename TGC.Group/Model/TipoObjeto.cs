using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGC.Core.Collision;

namespace TGC.Group.Model
{
    interface TipoObjeto
    {

        //void TipoObjeto();
        void inicializar();
        void perdervida();
        void esDañadoBounding(TgcRay rayo);
        void inicializarEstado();
        void Render();
        void morir();
        void disparar();


    }
}
