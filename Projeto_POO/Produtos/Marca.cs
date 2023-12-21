using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


/*
*	<copyright file="Marca.cs" company="IPCA">
*		Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio</author>
*   <date>15/11/2023 15:09:00</date>
*	<description></description>
**/


namespace Produtos
{
    /// <summary>
    /// Purpose:
    /// Created by: Fábio
    /// Created on: 15/11/2023 15:09:00
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Marca
    {

        #region Attributes

        int idMarca;
        string nome;

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        /// 
        public Marca(string nome)
        {
            this.nome = nome;
        }

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        /// 
        public int IdMaraca
        {
            get { return idMarca; }
            set { idMarca = value; }
        }
        public string Nome
        {
            get { return nome;}
            set { nome = value; }
        }



        #endregion

        #region Operators

        /// <summary>
        /// 
        /// </summary>
        /// 
        public static bool operator ==(Marca m1, Marca m2)
        {
            if ((m1.nome == m2.nome))
                return true;
            return false;
        }
        public static bool operator !=(Marca c1, Marca c2)
        {
            if (c1 == c2)
                return false;
            return true;
        }


        #endregion

        #region Overrides
        public override string ToString()
        {
            return String.Format($"Id Marca:{idMarca} -- Nome:{nome}");
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
