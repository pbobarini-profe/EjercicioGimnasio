using System;
using System.Collections.Generic;
using Modelos;
using Datos; // Importante que esté este

namespace Negocio
{
    public class NClientes
    {
        DClientes datos = new DClientes();

        public List<Clientes> Get()
        {
            return datos.Get();
        }

        public void Create(Clientes nuevo)
        {
            datos.Create(nuevo);
        }

        public void Update(Clientes cliente)
        {
            datos.Update(cliente);
        }

        public void Delete(int id)
        {
            datos.Delete(id);
        }
    }
}