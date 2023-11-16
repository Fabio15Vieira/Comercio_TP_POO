using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/*
*	<copyright file="Produto.cs" company="IPCA">
*		Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio</author>
*   <date>13/11/2023 20:50:19</date>
*	<description></description>
**/


namespace Produtos
{
    // <summary>
    /// Purpose:
    /// Created by: Fábio
    /// Created on: 13/11/2023 20:50:19
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Produto
    {

        #region Attributes

        static int idProduto = 0;
        string nome;
        int preço;
        int valorGarantia;
        int quantidade;
        int totalVendas;

        Categoria c;
        Marca m;

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        
        public Produto()
        {

        }

        /*public Produto(int idProduto;) 
        {
            get
        }*/

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

        #endregion

        #region Destructor

        /// <summary>
        /// The destructor.
        /// </summary>

        #endregion

        #endregion

    }
}
