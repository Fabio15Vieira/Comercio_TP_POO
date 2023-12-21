using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Produtos;
using Clientes;
using Pessoas;

/*
*	<copyright file="Compra.cs" company="IPCA">
*		Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio</author>
*   <date>15/11/2023 19:46:20</date>
*	<description></description>
**/


namespace Compras
{
    // <summary>
    /// Purpose:
    /// Created by: Fábio
    /// Created on: 15/11/2023 19:46:20
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Compra
    {
        
        #region Attributes
        static int id = 0;  
        int idCompra;
        int total;
        int pago;
        string estado;
        Cliente cliente;
        List<Produto> listaProdutos;
        DateTime dataPagamento;

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        /// 
        public Compra(Cliente cliente)
        {
            idCompra=id;
            this.cliente = cliente;
            estado="Aberto";
            listaProdutos = new List<Produto>();
            id++;
        }

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        
        public int IdCompra
        {
            get { return idCompra; }
            set { idCompra = value; }
        }

        public List<Produto> ListaProdutos
        {
            get { return listaProdutos; }
            set { listaProdutos = value; }
        }

        public int Total
        {
            get { return total; }
            set { total = value; }
        }

        public int Pago
        {
            get { return pago; }
            set { pago = value; }
        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        public DateTime DataPagamento
        {
            get { return dataPagamento; }
            set { dataPagamento = value; }
        }
        #endregion

        #region Operators

        /// <summary>
        /// 
        /// </summary>





        #endregion

        #region Overrides

        public override string ToString()
        {
            if (estado == "Concluido")
                return String.Format($"Id:{idCompra} -- Nome do cliente: {cliente.Nome} -- Total:{total} -- Estado: {estado} -- Data Pagamento: {dataPagamento.ToString("dd/MM/yyyy")}");
            return String.Format($"Id:{idCompra} -- Nome do cliente: {cliente.Nome} -- Total:{total} -- Estado: {estado}");
        }


        #endregion

        #region OtherMethods

        /// <summary>
        /// 
        /// </summary>
        /// 
        public string ToStringCompraProdutos(Produto produto)
        {
            if (produto != null)
            {
                int key = int.Parse($"{dataPagamento.Month}{dataPagamento.Year}");
                if (estado == "Concluido")
                    return String.Format($"IdProduto:{produto.IdProduto} -- Nome:{produto.Nome} -- Preço Pago:{produto.PreçoPago} -- Marca:{produto.M.Nome} Categoria:{produto.C.Nome}");
                else if (estado == "Aberto")
                    return String.Format($"IdProduto:{produto.IdProduto} -- Nome:{produto.Nome} -- Preço:{produto.PreçoAtual} -- Marca:{produto.M.Nome} Categoria:{produto.C.Nome}");
            }
            return null;
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
