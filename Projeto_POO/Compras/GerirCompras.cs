using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Produtos;
using Clientes;


/*
*	<copyright file="GerirCompras.cs" company="IPCA">
*		Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio</author>
*   <date>17/12/2023 20:09:29</date>
*	<description></description>
**/


namespace Compras
{
    /// <summary>
    /// Purpose:
    /// Created by: Fábio
    /// Created on: 17/12/2023 20:09:29
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class GerirCompras
    {

        #region Attributes
        List<Compra> ComprasList;
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        /// 
        public GerirCompras() 
        { 
            ComprasList = new List<Compra>();
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
        ///

        #endregion

        #region Overrides



        #endregion

        #region OtherMethods

        /// <summary>
        /// 
        /// </summary>
        /// 
        public Compra procuraCompra(int id)
        {
            if (ComprasList.Exists(obj => obj.IdCompra == id))
            {
                Compra compra = ComprasList.Find(obj => obj.IdCompra == id);
                return compra;
            }
            return null;
        }

        public Compra continuarCompra(int id,Cliente cliente)
        {
            Compra compra = procuraCompra(id);
            if ((compra != null) && (compra.Estado =="Aberto") && (compra.Cliente == cliente) ) 
            { 
             return compra;
            }
            return null;
        }

        public Compra novaCompra(Compra compra)
        {
            ComprasList.Add(compra);
            return (compra);
        }

        public bool adicinarProduto(Compra compra, Produto p, Cliente cliente)
        {
            int count = 0;
            if (compra != null && p != null && cliente == compra.Cliente)
            {
                foreach (Produto produto in compra.ListaProdutos)
                {
                    if (produto == p) count++;
                }
                if (count >= p.Quantidade ) return false;
                compra.ListaProdutos.Add(p);
                compra.Total = compra.Total + p.PreçoAtual;
                return true;
            }
            return false;
        }

        public bool cancelarCompra(Compra compra)
        {
            if (compra != null && compra.Estado=="Aberto")
            {
                ComprasList.Remove(compra);
                return true;
            }
            return false;
        }

        public int pagarCompra(Cliente cliente,Compra compra, int pago)
        {
            if (compra != null && cliente == compra.Cliente)
            {
                if (compra.Total == pago && compra.Estado == "Aberto")
                {
                    foreach (Produto produto in compra.ListaProdutos)
                    {
                        if (contarProduto(compra, produto) > produto.Quantidade) 
                        {
                            return -1; 
                        }
                    }
                    compra.Pago = pago;
                    compra.DataPagamento = DateTime.Now;
                    foreach (Produto produto in compra.ListaProdutos)
                    {
                        produto.PreçoPago = produto.PreçoAtual;
                        produto.Quantidade = produto.Quantidade - 1;
                    }
                    compra.Estado = "Concluido";
                    return 1;
                }
            }
            return 0;
        }

        public int contarProduto(Compra compra,Produto produto)
        {
            int cont = 0;
            foreach (Produto p in compra.ListaProdutos) 
            {
                if (p==produto) cont++;
            }
            return cont;
        }

        public List<Compra> listarComprasEstado(string estado)
        {
            List<Compra> listarcompras = new List<Compra>();
            foreach (Compra c in ComprasList)
            {
                if (c.Estado == estado) listarcompras.Add(c);
                else if (estado == "Tudo") listarcompras.Add(c);
            }
            listarcompras.OrderBy(c => c.Estado).ToList();
            return listarcompras;
        }

        public List<Compra> listarComprasCliente(Cliente clientes, string estado)
        {
            List<Compra> listarcompras = new List<Compra>();
            foreach (Compra compra in ComprasList)
            {
                if (compra.Cliente == clientes && compra.Estado == estado) listarcompras.Add(compra);
                else if (compra.Cliente == clientes && estado == "Tudo") listarcompras.Add(compra);
            }
            listarcompras.OrderBy(c => c.Estado).ToList();
            return listarcompras;
        }
        public bool removerProduto(Compra compra, Produto p, Cliente cliente)
        {
            if ((compra != null) && (p != null) && (compra.Estado == "Aberto") && (compra.Cliente==cliente))
            {
                if (compra.ListaProdutos.Exists(obj => obj.IdProduto == p.IdProduto))
                {
                    compra.ListaProdutos.Remove(p);
                    compra.Total = compra.Total - p.PreçoAtual;
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Destructor

        /// <summary>
        /// The destructor.
        /// </summary>

        #endregion

        #endregion

    }
}
