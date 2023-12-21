using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pessoas;


/*
*	<copyright file="Gerente.cs" company="IPCA">
*		Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio</author>
*   <date>15/11/2023 19:35:34</date>
*	<description></description>
**/


namespace Gerente
{
    // <summary>
    /// Purpose:
    /// Created by: Fábio
    /// Created on: 15/11/2023 19:35:34
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Gerente : Pessoa
    {
        
        #region Attributes

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        /// 
        public Gerente(string nome, string contacto, string endereço, DateTime dataNasc) 
        {
            this.Nome = nome;
            this.Contacto = contacto;
            this.Endereço = endereço;
            this.DataNasc = dataNasc;
            this.Idade = DateTime.Now.Year - dataNasc.Year;
            if (dataNasc.Date > DateTime.Now.AddYears(-Idade))
            {
                Idade--;
            }
        }
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

        #endregion

        #region Destructor

        /// <summary>
        /// The destructor.
        /// </summary>

        #endregion
        
        #endregion

    }

