using Compras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clientes;
using Produtos;
using System.Net.Http.Headers;
using Pessoas;
/*
*	<copyright file="Fatura.cs" company="IPCA">
*		Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio</author>
*   <date>15/11/2023 19:51:01</date>
*	<description></description>
**/


namespace Faturas
{
    // <summary>
    /// Purpose:
    /// Created by: Fábio
    /// Created on: 15/11/2023 19:51:01
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Fatura
    {

        #region Attributes

        int idFatura;
        int nif;
        Compra compra;
        int total;
        DateTime datafatura;


        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        /// 
        public Fatura(Compra compra)
        {
            this.idFatura = compra.IdCompra;
            this.nif = compra.Cliente.Nif;
            this.compra = compra;
            this.datafatura=compra.DataPagamento;
            this.total = compra.Total;
        }

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        /// 
        public Compra Compra
        {
            get { return compra; }
            set { compra = value; }
        }

        public DateTime Datafatura 
        {
            get { return datafatura; }
            set { datafatura = value; }
        }

        public int Total
        {
            get { return total; }
            set { total = value; }
        }
        public int IdFatura 
        {
            get { return idFatura;}
            set { idFatura = value; }
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
            return String.Format($"Id Fatura:{idFatura} -- Nome do cliente: {compra.Cliente.Nome}--Nif {nif} -- Total:{total} -- Data: {datafatura}");
        }


        #endregion

        #region OtherMethods

        /// <summary>
        /// 
        /// </summary>

        #endregion

        #region Destructor

        /// <summary>
        /// The destructor.
        /// </summary>

        #endregion

        #endregion

    }
}
