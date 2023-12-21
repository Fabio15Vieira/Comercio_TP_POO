using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compras;
using Produtos;
using Clientes;


/*
*	<copyright file="GerirGarantias.cs" company="IPCA">
*		Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio</author>
*   <date>18/12/2023 21:22:41</date>
*	<description></description>
**/


namespace Garantias
{
    /// <summary>
    /// Purpose:
    /// Created by: Fábio
    /// Created on: 18/12/2023 21:22:41
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class GerirGarantias
    {

        #region Attributes
        static int id = 0;
        List<Garantia> garantias;
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        /// 
        public GerirGarantias()
        {
            garantias = new List<Garantia>();
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
        public bool adicionarGarantia(Compra compra)
        {
            Garantia garantia;
            if (compra != null)
            {
                foreach (Produto produto in compra.ListaProdutos)
                {
                    garantia = new Garantia(compra, produto,id);
                    garantias.Add(garantia);
                    id++;
                }
                return true;
            }
            return false;
        }

        public Garantia procurarGarantia(int id) 
        {
            if (garantias.Exists(obj => obj.IdGarantia == id))
            {
                Garantia garantia = garantias.Find(obj => obj.IdGarantia == id);
                return garantia;
            }
            return null;
        }


        public List<Garantia> garantiaCompra(Compra compra)
        {
            List<Garantia> listaGaratia = new List<Garantia>();
            if (compra != null && compra.Estado =="Concluido")
            {
                foreach (Garantia garantia in garantias)
                {
                    if (compra.IdCompra == garantia.IdCompra)
                    {
                        listaGaratia.Add(garantia);
                    }
                }
            }
            return listaGaratia;
        }

        public void verificarGarantias()
        {
            DateTime dataAtual = DateTime.Now;
            foreach(Garantia garantia in garantias)
            {
                if (dataAtual > garantia.DataFim)
                {
                    garantia.FimGarantia = true;
                }   
            }
        }

        public bool usarGarantia(Garantia garantia)
        {
            verificarGarantias();
            if (garantia != null && !garantia.GarantiaUsada && !garantia.FimGarantia)
            {
                garantia.GarantiaUsada = true;
                return true;
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
