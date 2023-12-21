using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
*	<copyright file="GerirFuncionarios.cs" company="IPCA">
*		Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio</author>
*   <date>18/12/2023 21:21:39</date>
*	<description></description>
**/


namespace Funcionarios
{
    /// <summary>
    /// Purpose:
    /// Created by: Fábio
    /// Created on: 18/12/2023 21:21:39
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class GerirFuncionarios
    {

        #region Attributes
        
        static int idFunc=0;
        List<Funcionario> funcionarios;

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        /// 
        public GerirFuncionarios() 
        { 
            funcionarios = new List<Funcionario>(); 
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

        public Funcionario procurarFuncionario(int id)
        {
            foreach (Funcionario func in funcionarios)
            {
                if (func.IdFunc==id) return func;
            }
            return null;
        }

        public bool adicionarFuncionario(Funcionario funcionario)
        {
            foreach(Funcionario func in funcionarios)
            {
                if(func == funcionario) return false;
            }
            funcionario.IdFunc = idFunc;
            funcionarios.Add(funcionario);
            idFunc++;
            return true;
        }

        public int calcularDespesaSalarios(string cargo) 
        {
            int salarios=0;
            foreach(Funcionario func in funcionarios)
            {
                if (func.Cargo == cargo)
                {
                    salarios = salarios + func.Salario;
                }
                else if (cargo == "Tudo")
                {
                    salarios = salarios + func.Salario;
                }
            }
            return salarios;
        }

        public List<Funcionario> listarFuncPorCargo(string cargo) 
        { 
            List<Funcionario> listaFunc = new List<Funcionario>();
            foreach (Funcionario func in funcionarios)
            {
                if(func.Cargo == cargo)
                {
                    listaFunc.Add(func);
                }
                else if(cargo == "Tudo")
                {
                    listaFunc.Add(func);
                }
            }
            return listaFunc;
        }

        public List<Funcionario> ordenarFuncAnosContarto()
        {
            List<Funcionario> listaFunc = new List<Funcionario>();
            listaFunc=funcionarios.ToList();
            listaFunc.Sort((f1, f2) => f1.AnosContrato.CompareTo(f2.AnosContrato));
            return listaFunc;
        }

        public List<Funcionario> ordenarFuncIdade()
        {
            List<Funcionario> listaFunc = new List<Funcionario>();
            listaFunc = funcionarios.ToList();
            listaFunc.Sort((f1, f2) => f1.Idade.CompareTo(f2.Idade));
            return listaFunc;
        }

        public bool removerFuncionario(Funcionario funcionario)
        {
            foreach(Funcionario func in funcionarios)
            {
                if(func == funcionario)
                {
                    funcionarios.Remove(func);
                    return true;
                }
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
