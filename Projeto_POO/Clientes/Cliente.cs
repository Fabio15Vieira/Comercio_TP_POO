using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pessoas;

/*
*	<copyright file="Cliente.cs" company="IPCA">
*		Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio</author>
*   <date>15/11/2023 19:40:49</date>
*	<description></description>
**/


namespace Clientes
{
    // <summary>
    /// Purpose:
    /// Created by: Fábio
    /// Created on: 15/11/2023 19:40:49
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Cliente : Pessoa
    {

        #region Attributes

        int idCliente = 0;
        int nif;

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public Cliente(string nome, int nif, string contacto, string endereço, DateTime dataNasc )
        {
            this.Nome = nome;
            this.nif = nif;
            this.Contacto= contacto;
            this.Endereço= endereço;
            this.DataNasc = dataNasc;
            this.Idade = DateTime.Now.Year - dataNasc.Year;
            if (dataNasc.Date > DateTime.Now.AddYears(-Idade))
            {
                Idade--;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>

        public int Nif { get { return nif; } set { nif = value; } }

        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }
        #endregion

        #region Operators

        /// <summary>
        /// 
        /// </summary>
        /// 
        public static bool operator ==(Cliente c1, Cliente c2)
        {
            if ((c1.nif == c2.nif))
                return true;
            return false;
        }
        public static bool operator !=(Cliente c1, Cliente c2)
        {
            if (c1 == c2)
                return false;
            return true;
        }

        #endregion

        #region Overrides
        public override string ToString()
        {
            return String.Format($"Id:{idCliente} -- Nome: {Nome}");
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
