using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pessoas;
using Interfaces;

/*
*	<copyright file="Funcionario.cs" company="IPCA">
*		Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio</author>
*   <date>15/11/2023 19:37:53</date>
*	<description></description>
**/


namespace Funcionarios
{
    [Serializable]
    // <summary>
    /// Purpose:
    /// Created by: Fábio
    /// Created on: 15/11/2023 19:37:53
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Funcionario: Pessoa , IPessoa ,IFuncionario
    {
        
        #region Attributes

        int idFunc;
        DateTime dataAdmissao;
        int salario;
        int numeroCC;
        string cargo;
        [NonSerialized]
        int anosContrato;

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        /// 
        public Funcionario(int numeroCC, string nome, string contacto, DateTime dataAdmissao, int salario, string cargo, DateTime dataNasc)
        {
            this.numeroCC = numeroCC;
            this.Nome = nome;   
            this.Contacto = contacto;
            this.dataAdmissao= dataAdmissao;
            this.salario = salario;
            this.cargo = cargo;
            this.DataNasc = dataNasc;
            this.Idade = DateTime.Now.Year - dataNasc.Year;
            if (dataNasc.Date > DateTime.Now.AddYears(-Idade))
            {
                Idade--;
            }
            this.anosContrato = DateTime.Now.Year - dataAdmissao.Year;
            if (dataAdmissao.Date > DateTime.Now.AddYears(-anosContrato))
            {
                anosContrato--;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
      

        public string Cargo 
        {
            get { return cargo; }
            set { cargo = value; }
        }
        public int IdFunc
        {
            get { return idFunc; }
            set { idFunc = value; }
        }

        public int Salario
        {
            get { return salario; }
            set { salario = value; }
        }

        public int AnosContrato
        {
            get { return anosContrato; }
            set { anosContrato = value; }
        }

        public DateTime DataAdmissao
        {
            get { return dataAdmissao; }
            set { dataAdmissao = value; }
        }
        /*public int CompareTo(object obj)
        {

        }*/


        #endregion

        #region Operators

        /// <summary>
        /// 
        /// </summary>
        /// 

        public static bool operator ==(Funcionario f1, Funcionario f2)
        {
            if ((f1.idFunc == f2.idFunc) || (f1.numeroCC == f2.numeroCC ))
                return true;
            return false;
        }
        public static bool operator !=(Funcionario f1, Funcionario f2)
        {
            if (f1 == f2)
                return false;
            return true;
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return String.Format($"Id:{idFunc} -- Nome: {Nome} -- Salario:{salario} -- Data Admissao: {dataAdmissao.ToString("dd/MM/yyyy")} -- Anos de Contrato:{anosContrato} -- Idade:{Idade}");
        }

        #endregion

        #region OtherMethods

        /// <summary>
        /// 
        /// </summary>

        /*public bool Guaradardados()
        {


        }*/

        #endregion

        #region Destructor

        /// <summary>
        /// The destructor.
        /// </summary>

        #endregion

        #endregion

    }
}
