using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;


/*
*	<copyright file="GerirProdutos.cs" company="IPCA">
*		Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio</author>
*   <date>17/12/2023 16:51:44</date>
*	<description></description>
**/


namespace Produtos
{
    /// <summary>
    /// Purpose:
    /// Created by: Fábio
    /// Created on: 17/12/2023 16:51:44
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class GerirProdutos
    {
        string nome;
        string website;
        string contacto;
        static int idProduto =0;
        static int idMarca =0;
        static int idCategoria = 0;
        List<Produto> produtos;
        List<Categoria> categorias;
        List<Marca> marcas;

        #region Attributes

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        /// 
        public GerirProdutos()
        {
            produtos = new List<Produto>();
            categorias = new List<Categoria>();
            marcas = new List<Marca>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        /// 

        public List<Produto> Produtos
        {
            get { return produtos; }
            set { produtos = value; }
        }
        public List<Categoria> Categorias
        {
            get { return categorias; }
            set { categorias = value; }
        }
        public List<Marca> Marcas
        {
            get { return marcas; }
            set { Marcas = value; }
        }

        #endregion

        #region Operators

        /// <summary>
        /// 
        /// </summary>
        /// 

        #endregion

        #region Overrides

        #endregion

        #region OtherMethods

        /// <summary>
        /// 
        /// </summary>
        /// 
        public Produto procurarProduto(int id)
        {
            if (produtos.Exists(obj => obj.IdProduto == id))
            {
                Produto p = produtos.Find(obj => obj.IdProduto == id);
                return p;
            }
            return null;
        }
        public bool adicionarProduto(Produto p)
        {
            if (!produtos.Exists(obj => obj.Nome == p.Nome))
            {
                p.IdProduto = idProduto;
                produtos.Add(p);
                idProduto++;
                return true;
            }
            return false;
        }

        public bool atualizarQuantidade(Produto produto, int quantidade)
        {
            if (produto != null)
            {
                produto.Quantidade = quantidade;
                return true;
            }
            return false;
        }
        public bool adicionarPreço(int id, int mes, int ano, int preço)
        {
            Produto p = procurarProduto(id);
            if (p != null) {
                int key = int.Parse($"{mes}{ano}");
                if (!p.Preço.ContainsKey(key))
                {
                    p.Preço.Add(key, preço);
                    key = p.Preço.Keys.Max();
                    p.PreçoAtual = p.Preço[key];
                    return true;
                }
                else if (p.Preço.ContainsKey(key))
                {
                    p.Preço[key] = preço;
                    key = p.Preço.Keys.Max();
                    p.PreçoAtual = p.Preço[key];
                    return true;
                }
            }
            return false;
        }
        public int historicoPreço(int id, int mes, int ano)
        {
            Produto p = procurarProduto(id);
            if (p != null)
            {
                int key = int.Parse($"{mes}{ano}");
                if (p.Preço.ContainsKey(key))
                {
                    return p.Preço[key];
                }
            }
            return -1;
        }
        public bool adicionarVenda(Produto p,int mes, int ano, int v)
        {
            if (p != null)
            {
                int key = int.Parse($"{mes}{ano}");
                if (!p.TotalVendas.ContainsKey(key))
                {
                    p.TotalVendas.Add(key, v);
                    return true;
                }
                else if (p.TotalVendas.ContainsKey(key))
                {
                    p.TotalVendas[key] = p.TotalVendas[key] + v;
                    return true;
                }
            }
            return false;
        }
        public int historicoVendas(int id, int mes, int ano)
        {
            Produto p = procurarProduto(id);
            if (p != null)
            {
                int key = int.Parse($"{mes}{ano}");
                if (p.TotalVendas.ContainsKey(key))
                {
                    return p.TotalVendas[key];
                }
            }
            return -1;
        }

        public Marca procurarMarca(int id)
        {
            if (marcas.Exists(obj => obj.IdMaraca == id))
            {
                Marca m = marcas.Find(obj => obj.IdMaraca == id);
                return m;
            }
            return null;
        }
        public bool adicionarMarca(Marca m)
        {
            foreach (Marca marca in marcas)
            {
                if  (marca == m) return false;
            }
                m.IdMaraca = idMarca;
                marcas.Add(m);
                idMarca++;
                return true;
        }

        public Categoria procurarCategoria(int id)
        {
            if (marcas.Exists(obj => obj.IdMaraca == id))
            {
                Categoria c = Categorias.Find(obj => obj.IdCategoria == id);
                return c;
            }
            return null;
        }
        public bool adicionarCategoria(Categoria c)
        {
            foreach (Categoria categoria in categorias)
            {
                if (categoria == c) return false;
            }
                c.IdCategoria = idCategoria;
                categorias.Add(c);
                idCategoria++;
                return true;
        }

        public List<Produto> procurarPorCategoria(int idCategoria)
        {
            List<Produto> porCategorias = new List<Produto>();
            foreach (Produto p in produtos)
            {
                if (p.C.IdCategoria == idCategoria) porCategorias.Add(p);
            }
            return porCategorias;
        }

        public List<Produto> procurarPorMarca(int idMarca)
        {
            List<Produto> porMarca = new List<Produto>();
            foreach (Produto p in produtos)
            {
                if (p.M.IdMaraca == idMarca) porMarca.Add(p);
            }
            return porMarca;
        }

        public List<Produto> listarProdutos()
        {
            return produtos;
        }

        public List<Categoria> listarCategorias()
        {
            List<Categoria> listaCategorias = new List<Categoria>();
            listaCategorias = categorias.ToList();
            return listaCategorias;
        }
        public List<Marca> listarMarcas()
        {
            List<Marca> listaMarcas = new List<Marca>();
            listaMarcas = marcas.ToList();
            return listaMarcas;
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
