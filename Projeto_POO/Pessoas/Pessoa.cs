using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

/*
*	<copyright file="Pessoa.cs" company="IPCA">
*		Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio</author>
*   <date>15/11/2023 19:28:41</date>
*	<description></description>
**/


namespace Pessoas
{
    // <summary>
    /// Purpose:
    /// Created by: Fábio
    /// Created on: 15/11/2023 19:28:41
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Pessoa : IPessoa
    {

        #region Attributes
        
        string nome;
        DateTime dataNasc;
        int idade;
        string contacto;
        string endereço;
        
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        /// 
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Contacto
        {
            get { return contacto; }
            set { contacto = value; }
        }
        public DateTime DataNasc
        {
            get { return dataNasc; }
            set { dataNasc = value; }
        }

        public int Idade {
            get { return idade; }
            set { idade = value; }
        }


        public string Endereço
        {
            get { return endereço; }
            set { endereço = value; }
        }
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
