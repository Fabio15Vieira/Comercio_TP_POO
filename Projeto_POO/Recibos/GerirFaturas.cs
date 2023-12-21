using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compras;
using Clientes;
using Produtos;


/*
*	<copyright file="GerirFaturas.cs" company="IPCA">
*		Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio</author>
*   <date>18/12/2023 21:46:51</date>
*	<description></description>
**/


namespace Faturas
{
    /// <summary>
    /// Purpose:
    /// Created by: Fábio
    /// Created on: 18/12/2023 21:46:51
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class GerirFaturas
    {
        List<Fatura> faturas;

        #region Attributes

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        /// 
        public GerirFaturas()
        {
            faturas = new List<Fatura>();
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
        /// 
        public bool adicionarFatura(Fatura fatura)
        {
            if (!faturas.Exists(obj => obj.IdFatura == fatura.IdFatura))
            {
                faturas.Add(fatura);
                return true;
            }
            return false;
        }

        public List<Fatura> Listarfaturas()
        {
            return faturas;
        }

        public int faturamentoAnual(DateTime ano)
        {
            int faturamento=0;
            foreach(Fatura fatura in faturas)
            {
                if(fatura.Datafatura.Year ==ano.Year)
                {
                    faturamento = faturamento + fatura.Total;
                }
            }
            return faturamento;
        }

        public int faturamentoMensal(DateTime data)
        {
            int faturamento = 0;
            foreach (Fatura fatura in faturas)
            {
                if (fatura.Datafatura.Month == data.Month && fatura.Datafatura.Year==data.Year)
                {
                    faturamento = faturamento + fatura.Total;
                }
            }
            return faturamento;
        }

        public List<Fatura> ListarfaturasCliente(Cliente cliente)
        {
            List<Fatura> listafaturas = new List<Fatura>();
            foreach (Fatura fatura in faturas)
            {
                if (fatura.Compra.Cliente==cliente) listafaturas.Add(fatura);
            }
            return listafaturas;
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
