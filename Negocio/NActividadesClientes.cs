using System;
using System.Collections.Generic;
using Modelos; 
using Datos;   

namespace Negocio
{
    public class NActividadesClientes
    {
        
        private DActividadesClientes datos = new DActividadesClientes();


       
        public List<ActividadesClientes> Get()
        {
           
            return datos.Get();
        }

        public void Create(ActividadesClientes ac)
        {
           

            datos.Create(ac);
        }

        public void Update(ActividadesClientes ac)
        {
            datos.Update(ac);
        }

        public void Delete(int id)
        {
              datos.Delete(id);
        }
    }
}