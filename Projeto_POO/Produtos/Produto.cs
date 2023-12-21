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

        //static int id = 0;
        int idProduto;
        string nome;
        Dictionary<int, int> preço;
        Dictionary<int, int> totalVendas;
        int preçoAtual;
        int preçoPago;
        int valorGarantia;
        int quantidade;
        Categoria c;
        Marca m;

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        
        public Produto(string nome, int garantia,int quantidade,int p, Marca m, Categoria c)
        {
            this.nome = nome;
            this.valorGarantia = garantia;
            this.quantidade = quantidade;
            preço = new Dictionary<int, int>();
            totalVendas = new Dictionary<int, int>();
            this.m = m;
            this.c= c;
            int key = int.Parse($"{DateTime.Now.Month}{DateTime.Now.Year}");
            preço.Add(key, p);
            totalVendas.Add(key, 0);
            key = preço.Keys.Max();
            preçoAtual = preço[key];
        }



        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        /// 
        public int IdProduto { 
            get { return idProduto; } 
            set { idProduto = value; } 
        }
        public string Nome { 
            get { return nome; } 
            set { nome = value; }
        }
        public int ValorGarantia
        {
            get { return valorGarantia; }
            set { valorGarantia = value; }
        }

        public int Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }

        public int PreçoAtual
        {
            get { return preçoAtual; }
            set { preçoAtual = value; }
        }

        public int PreçoPago
        {
            get { return preçoPago; }
            set { preçoPago = value; }
        }
        public Dictionary<int,int> Preço
        {
            get { return preço; }
            set { preço = value; }
        }
        public Dictionary<int, int> TotalVendas
        {
            get { return totalVendas; }
            set { totalVendas = value; }
        }
        public Marca M
        {
            get { return m; }
            set { m = value; }
        }
        public Categoria C
        {
            get { return c; }
            set { c = value; }
        }
        #endregion


        #region Operators

        /// <summary>
        /// 
        /// </summary>
        /// 


        #endregion

        #region Overrides

        public override string ToString()
        {
            return String.Format($"Id:{idProduto} -- Nome:{nome} -- Preço:{preçoAtual} -- Quantidade:{quantidade} -- Marca:{m.Nome} Categoria:{c.Nome}");
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
