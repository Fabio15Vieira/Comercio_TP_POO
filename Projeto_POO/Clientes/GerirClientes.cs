using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
*	<copyright file="GerirClientes.cs" company="IPCA">
*		Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio</author>
*   <date>18/12/2023 19:42:45</date>
*	<description></description>
**/


namespace Clientes
{
    /// <summary>
    /// Purpose:
    /// Created by: Fábio
    /// Created on: 18/12/2023 19:42:45
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class GerirClientes
    {

        #region Attributes
        static int idCliente = 0;
        List<Cliente> clientes;
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        /// 
        public GerirClientes()
        {
            clientes = new List<Cliente>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>

        #endregion

        #region Operators

        /// <summary>
        /// 
        /// </summary>

        #endregion

        #region Overrides

        #endregion

        #region OtherMethods

        /// <summary>
        /// 
        /// </summary>

        public Cliente procurarCliente(int id)
        {
            foreach (Cliente cliente in clientes)
            {
                if (cliente.IdCliente == id) return cliente;
            }
            return null;
        }

        public bool adicionarCliente(Cliente cliente)
        {
            foreach (Cliente c in clientes)
            {
                if (c == cliente) return false;
            }
            cliente.IdCliente = idCliente;
            clientes.Add(cliente);
            idCliente++;
            return true;
        }

        public bool removerCliente(Cliente cliente)
        {
            foreach (Cliente c in clientes)
            {
                if (c == cliente)
                {
                    clientes.Remove(cliente);
                    return true;
                }
            }
            return false;
        }

        public List<Cliente> listarClientes() { return clientes; }


        #endregion

        #region Destructor

        /// <summary>
        /// The destructor.
        /// </summary>

        #endregion

        #endregion

    }
}
