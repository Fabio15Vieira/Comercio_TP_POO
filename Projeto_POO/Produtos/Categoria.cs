using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
*	<copyright file="Categoria.cs" company="IPCA">
*		Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio</author>
*   <date>15/11/2023 15:09:57</date>
*	<description></description>
**/


namespace Produtos
{
    /// <summary>
    /// Purpose:
    /// Created by: Fábio
    /// Created on: 15/11/2023 15:09:57
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Categoria
    {

        #region Attributes

        int idCategoria;
        string nome;

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        /// 
        public Categoria(string nome)
        {
            this.nome = nome;
        }

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        /// 
        public int IdCategoria { 
            get { return idCategoria; } 
            set { idCategoria = value; } 
        }
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        #endregion

        #region Operators

        /// <summary>
        /// 
        /// </summary>
        /// 
        public static bool operator ==(Categoria c1, Categoria c2)
        {
            if ((c1.nome == c2.nome))
                return true;
            return false;
        }
        public static bool operator !=(Categoria c1, Categoria c2)
        {
            if (c1 == c2)
                return false;
            return true;
        }

        #endregion

        #region Overrides
        public override string ToString()
        {
            return String.Format($"Id:{idCategoria} -- Nome:{nome}");
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
