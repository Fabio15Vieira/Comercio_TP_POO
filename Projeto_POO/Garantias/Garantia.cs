using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Compras;
using Faturas;
using Produtos;
using Clientes;


/*
*	<copyright file="Garantia.cs" company="IPCA">
*		Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio</author>
*   <date>15/11/2023 19:56:15</date>
*	<description></description>
**/


namespace Garantias
{
    // <summary>
    /// Purpose:
    /// Created by: Fábio
    /// Created on: 15/11/2023 19:56:15
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Garantia
    {

        #region Attributes

        int idGarantia;
        int idProduto;
        int idCompra;
        int idCliente;
        bool garantiaUsada;
        bool fimGarantia;
        DateTime dataPag;
        int garantiaProd;
        DateTime dataFim;

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        /// 
        public Garantia(Compra compra, Produto produto,int id)
        {
            this.idGarantia = id;
            this.idCompra = compra.IdCompra;
            this.idProduto = produto.IdProduto;
            this.idCliente = compra.Cliente.IdCliente;
            this.dataPag = compra.DataPagamento;
            this.garantiaProd = produto.ValorGarantia;
            this.garantiaUsada = false;
            this.fimGarantia = false;
            this.dataFim = dataPag.AddYears(garantiaProd);
        }

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        /// 
        public int IdGarantia
        {
            get { return idGarantia; }
            set { idGarantia = value; }
        }

        public int IdCompra
        {
            get { return idCompra; }
            set { idCompra = value; }
        }

        public int IdProduto
        {
            get { return idProduto; }
            set { idProduto= value; }
        }

        public bool GarantiaUsada
        {
            get { return garantiaUsada; }
            set { garantiaUsada = value; }
        }

        public bool FimGarantia
        {
            get { return fimGarantia; }
            set { fimGarantia = value; }
        }

        public DateTime DataFim
        {
            get { return dataFim; }
            set { dataFim = value; }
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
            if(garantiaUsada)
                return String.Format($"Id Garatia:{idGarantia} -- Id Compra: {idCompra} -- Id Produto:{idProduto} -- Fim da garantia: {dataFim.ToString("dd/MM/yyyy")} -- Garantia ja foi usada");
            else if(!garantiaUsada && !fimGarantia)
                return String.Format($"Id Garatia:{idGarantia} -- Id Compra: {idCompra} -- Id Produto:{idProduto} -- Fim da garantia: {dataFim.ToString("dd/MM/yyyy")} -- Garantia disponivel");
            else
                return String.Format($"Id Garatia:{idGarantia} -- Id Compra: {idCompra} -- Id Produto:{idProduto} -- Fim da garantia: {dataFim.ToString("dd/MM/yyyy")} -- Garantia fora de validade");
        }

        #endregion

        #region OtherMethods

        /// <summary>
        /// 
        /// </summary>
        /// 

        #endregion

        #region Destructor

        /// <summary>
        /// The destructor.
        /// </summary>

        #endregion

        #endregion

    }
}
