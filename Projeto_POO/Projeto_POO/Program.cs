using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Produtos;
using Compras;
using Clientes;
using Faturas;
using Funcionarios;
using Garantias;

namespace Projeto_POO
{

    
    class Program
    {
        static void menuCliente(GerirCompras gerirCompras,GerirProdutos gerirProdutos,GerirFaturas gerirFaturas ,GerirGarantias gerirGarantias,Cliente cliente) 
        {

            int id;
            string input = "";
            int opc = 0;
            Compra compra;
            List<Compra> listaCompras = new List<Compra>();
            List<Produto> listaProdutos = new List<Produto>();
            do 
            {
                input = "";
                Console.WriteLine("1. Nova compra");
                Console.WriteLine("2. Ver compras");
                Console.WriteLine("3. Continuar compra");
                Console.WriteLine("4. Remover produto da compra");
                Console.WriteLine("5. Pagar compra");
                Console.WriteLine("6. Cancelar compra");
                Console.WriteLine("7. Ver produtos");
                Console.WriteLine("0. Voltar");
                opc= int.Parse(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        compra = gerirCompras.novaCompra(new Compra(cliente));
                        listaProdutos = gerirProdutos.listarProdutos();
                        do 
                        {
                            foreach (Produto produto in listaProdutos)
                            {
                                Console.WriteLine(produto.ToString());
                            }
                            Console.WriteLine("Digite \"sair\" para sair da compra");
                            Console.WriteLine("Selecionar Produto id");
                            input = Console.ReadLine();
                            if (input != "sair")
                            {
                                id = int.Parse(input);
                                gerirCompras.adicinarProduto(compra,gerirProdutos.procurarProduto(id),cliente);
                            }

                        } while (input != "sair");
                        break;
                    case 2:
                        listaCompras= gerirCompras.listarComprasCliente(cliente,"Tudo");
                        foreach(Compra c in listaCompras)
                        {
                            Console.WriteLine(c.ToString());
                        }
                        Console.WriteLine("Ver detalhes:");
                        id = int.Parse(Console.ReadLine());
                        compra = gerirCompras.procuraCompra(id);
                        foreach (Produto produto in compra.ListaProdutos)
                            Console.WriteLine("\t" + compra.ToStringCompraProdutos(produto));
                        break;
                    case 3:
                        listaCompras = gerirCompras.listarComprasCliente(cliente, "Aberto");
                        listaProdutos = gerirProdutos.listarProdutos();
                        foreach (Compra c in listaCompras)
                        {
                            Console.WriteLine(c.ToString());
                        }
                        id = int.Parse(Console.ReadLine());
                        compra = gerirCompras.continuarCompra(id, cliente);
                        if (compra != null)
                        {
                            do 
                            {
                                foreach (Produto produto in listaProdutos)
                                {
                                    Console.WriteLine(produto.ToString());
                                }
                                Console.WriteLine("Digite \"sair\" para sair da compra");
                                Console.WriteLine("Selecionar Produto id");
                                input = Console.ReadLine();
                                if (input != "sair")
                                {
                                    id = int.Parse(input);
                                    gerirCompras.adicinarProduto(compra, gerirProdutos.procurarProduto(id), cliente);
                                    Console.WriteLine(compra.ToString());
                                    foreach (Produto produto in compra.ListaProdutos) 
                                       Console.WriteLine( "\t"+produto.ToString()); 

                                }
                            } while (input !="sair");
                        }
                        break;
                    case 4:
                        listaCompras = gerirCompras.listarComprasCliente(cliente, "Aberto");
                        listaProdutos = gerirProdutos.listarProdutos();
                        foreach (Compra c in listaCompras)
                        {
                            Console.WriteLine(c.ToString());
                        }
                        id = int.Parse(Console.ReadLine());
                        compra = gerirCompras.continuarCompra(id,cliente);
                        if (compra != null)
                        {
                            do
                            {
                                Console.WriteLine(compra.ToString());
                                foreach (Produto produto in compra.ListaProdutos)
                                {
                                    Console.WriteLine("\t"+compra.ToStringCompraProdutos(produto));
                                }
                                Console.WriteLine("Digite \"sair\" para sair da compra");
                                Console.WriteLine("Selecionar Produto que pretende remover");
                                Console.Write("id:");
                                input = Console.ReadLine();
                                if (input != "sair")
                                {
                                    id = int.Parse(input);
                                    gerirCompras.removerProduto(compra, gerirProdutos.procurarProduto(id),cliente);
                                }
                            } while (input != "sair");
                        }
                        break;
                    case 5:
                        listaCompras = gerirCompras.listarComprasCliente(cliente, "Aberto");
                        foreach (Compra c in listaCompras)
                        {
                            Console.WriteLine(c.ToString());
                        }
                        id = int.Parse(Console.ReadLine());
                        compra = gerirCompras.procuraCompra(id);
                        Console.WriteLine("Valor: ");
                        int valor = int.Parse(Console.ReadLine());
                        int concluirCompra = gerirCompras.pagarCompra(cliente, compra, valor);
                        if (concluirCompra == 1)
                        {
                            Console.WriteLine("Compra concluida");
                            gerirFaturas.adicionarFatura(new Fatura(compra));
                            gerirGarantias.adicionarGarantia(compra);
                            foreach (Produto produto in compra.ListaProdutos)
                            {
                                gerirProdutos.adicionarVenda(produto, DateTime.Now.Month, DateTime.Now.Year, 1);
                            }
                        }
                        else if(concluirCompra == -1)
                        {
                            Console.WriteLine("Não tem quantidade suficiente de porduto em stock");
                        }
                        else if (concluirCompra == 0)
                        {
                            Console.WriteLine("Não foi possivel concluir compra");
                        }

                        break;
                    case 6:
                        listaCompras = gerirCompras.listarComprasCliente(cliente, "Aberto");
                        foreach (Compra c in listaCompras)
                        {
                            Console.WriteLine(c.ToString());
                        }
                        id = int.Parse(Console.ReadLine());
                        compra = gerirCompras.procuraCompra(id);
                        gerirCompras.cancelarCompra(compra);
                        break;
                    case 7:
                        Console.WriteLine("1. Ver todos produtos");
                        Console.WriteLine("2. Procurar por categoria");
                        Console.WriteLine("3. Procurar Por Maraca");
                        id = int.Parse(Console.ReadLine());
                        switch (id)
                        {
                            case 1:
                                listaProdutos = gerirProdutos.listarProdutos();
                                foreach (Produto produto in listaProdutos)
                                    Console.WriteLine(produto.ToString());
                                break;
                            case 2:
                                List<Categoria> listaCategorias = gerirProdutos.listarCategorias();
                                foreach (var categorias in listaCategorias)
                                {
                                    Console.WriteLine(categorias.ToString());
                                }
                                id = int.Parse(Console.ReadLine());
                                listaProdutos = gerirProdutos.procurarPorCategoria(id);
                                foreach (Produto produto in listaProdutos)
                                    Console.WriteLine(produto.ToString());
                                break;
                            case 3:
                                List<Marca> listaMarcas = gerirProdutos.listarMarcas();
                                foreach (var marcas in listaMarcas)
                                {
                                    Console.WriteLine(marcas.ToString());
                                }
                                id = int.Parse(Console.ReadLine());
                                listaProdutos = gerirProdutos.procurarPorMarca(id);
                                foreach (Produto produto in listaProdutos)
                                    Console.WriteLine(produto.ToString());
                                break;
                        }
                        break;

                }

            } while (opc!=0); 
        }

        static void menuGerente(GerirProdutos gerirProdutos, GerirCompras gerirCompras, GerirClientes gerirClientes ,GerirFaturas gerirFaturas,GerirFuncionarios gerirFuncionarios , GerirGarantias gerirGarantias)
        {
            int opc = 0;
            do
            {
                Console.WriteLine("1. Gerir clientes");
                Console.WriteLine("2. Gerir Produtos");
                Console.WriteLine("3. Gerir Compras");
                Console.WriteLine("4. Gerir Faturas");
                Console.WriteLine("5. Gerir Funcionarios");
                Console.WriteLine("6. Gerir Garantias");
                Console.WriteLine("7. Guardar");
                Console.WriteLine("0. Voltar");
                opc = int.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        menuGerirClientes(gerirClientes);
                        break;
                    case 2:
                        menuGerirProdutos(gerirProdutos);
                        break;
                    case 3:
                        menuGerirCompras(gerirCompras, gerirClientes);
                        break;
                    case 4:
                        menuGerirFaturas(gerirFaturas, gerirClientes);
                        break;
                    case 5:
                        menuGerirFuncionarios(gerirFuncionarios);
                        break;
                    case 6:
                        menuGerirGarantias(gerirCompras, gerirGarantias);
                        break;
                    case 7:
                        break;
                    default:
                        break;
                }
                 


            }while (opc != 0);
        }

        static void menuGerirClientes(GerirClientes gerirClientes)
        {
            int opc = 0;
            int id;
            string nome;
            int nif;
            string contacto;
            string endereço;
            List<Cliente> listaClientes = new List<Cliente>();
            do
            {
                Console.WriteLine("1. Adicionar cliente");
                Console.WriteLine("2. Listar clientes");
                Console.WriteLine("3. remover cliente");
                Console.WriteLine("0. Voltar");
                opc = int.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        Console.WriteLine("Nome");
                        nome = Console.ReadLine();
                        Console.WriteLine("Nif");
                        nif = int.Parse(Console.ReadLine());
                        Console.WriteLine("Contacto");
                        contacto = Console.ReadLine();
                        Console.WriteLine("Endereço");
                        endereço = Console.ReadLine();
                        Console.WriteLine("Data de Nascimento");
                        Console.Write("Dia:");
                        int dia = int.Parse(Console.ReadLine());
                        Console.Write("Mes:");
                        int mes = int.Parse(Console.ReadLine());
                        Console.Write("Ano:");
                        int ano = int.Parse(Console.ReadLine());
                        DateTime dataNasc = new DateTime(ano,mes,dia);
                        gerirClientes.adicionarCliente(new Cliente(nome,nif,contacto,endereço,dataNasc));
                        break;
                    case 2:
                        listaClientes = gerirClientes.listarClientes();
                        foreach (Cliente cliente in listaClientes)
                        {
                            Console.WriteLine(cliente.ToString());
                        }
                        break;
                    case 3:
                        listaClientes = gerirClientes.listarClientes();
                        foreach (Cliente cliente in listaClientes)
                        {
                            Console.WriteLine(cliente.ToString());
                        }
                        Console.WriteLine("id");
                        id = int.Parse(Console.ReadLine());
                        gerirClientes.removerCliente(gerirClientes.procurarCliente(id));
                        break;
                    default:
                        break;
                }
            } while (opc != 0);
        }

        static void menuGerirProdutos(GerirProdutos gerirProdutos)
        {
            int opc = 0;
            int id;
            string nome;
            int garantia;
            int quantidade;
            int preço;
            int marca;
            int categoria;
            Marca m;
            Categoria c;
            List<Produto> listaProdutos = gerirProdutos.listarProdutos();
            do
            {
                Console.WriteLine("1. Adicionar produto");
                Console.WriteLine("2. Adicionar marca");
                Console.WriteLine("3. Adicionar categoria");
                Console.WriteLine("4. adicionar preço");
                Console.WriteLine("5. adicionar vendas");
                Console.WriteLine("6. Historico de preços");
                Console.WriteLine("7. historico de Vendas");
                Console.WriteLine("0. Voltar");
                opc = int.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        Console.WriteLine("Nome");
                        nome = Console.ReadLine();
                        Console.WriteLine("Garantia");
                        garantia =int.Parse(Console.ReadLine());
                        Console.WriteLine("Quantidade");
                        quantidade =int.Parse(Console.ReadLine());
                        Console.WriteLine("Preço");
                        preço = int.Parse(Console.ReadLine());
                        Console.WriteLine("Marca");
                        List<Marca> listaMarcas= gerirProdutos.listarMarcas();
                        foreach (var marcas in listaMarcas)
                        {
                            Console.WriteLine(marcas.ToString());
                        }
                        marca = int.Parse(Console.ReadLine());
                        m = gerirProdutos.procurarMarca(marca);
                        
                        Console.WriteLine("Categoria");

                        List<Categoria> listaCategorias = gerirProdutos.listarCategorias();
                        foreach (var categorias in listaCategorias)
                        {
                            Console.WriteLine(categorias.ToString());
                        }
                        categoria = int.Parse(Console.ReadLine());
                        c = gerirProdutos.procurarCategoria(categoria);
                        gerirProdutos.adicionarProduto(new Produto(nome,garantia,quantidade,preço,m,c));
                        break;
                    case 2:
                        Console.WriteLine("Nome Marca");
                        nome = Console.ReadLine();
                        gerirProdutos.adicionarMarca(new Marca(nome));
                        break;
                    case 3:
                        Console.WriteLine("Nome Categoria");
                        nome = Console.ReadLine();
                        gerirProdutos.adicionarCategoria(new Categoria(nome));
                        break;
                    case 4:
                        foreach(Produto produto in listaProdutos)
                        {
                            Console.WriteLine(produto.ToString());
                        }
                        Console.WriteLine("Id Produto");
                        id =int.Parse(Console.ReadLine());
                        Console.WriteLine("Mes");
                        int mes = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ano");
                        int ano=int.Parse(Console.ReadLine());
                        Console.WriteLine("preço");
                        preço = int.Parse(Console.ReadLine());
                        gerirProdutos.adicionarPreço(id,mes,ano,preço);
                        break;
                    case 5:
                        foreach (Produto produto in listaProdutos)
                        {
                            Console.WriteLine(produto.ToString());
                        }
                        Console.WriteLine("Id Produto");
                        id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Mes");
                        mes = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ano");
                        ano = int.Parse(Console.ReadLine());
                        Console.WriteLine("Vendas");
                        int venda = int.Parse(Console.ReadLine());
                        Produto produto1 = gerirProdutos.procurarProduto(id);
                        gerirProdutos.adicionarVenda(produto1, mes, ano, venda);
                        break;
                    case 6:
                        foreach (Produto produto in listaProdutos)
                        {
                            Console.WriteLine(produto.ToString());
                        }
                        Console.WriteLine("Id Produto");
                        id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Mes");
                        mes = int.Parse(Console.ReadLine());
                        DateTime datames = new DateTime(DateTime.Now.Year, mes, 1);
                        Console.WriteLine("Ano");
                        ano = int.Parse(Console.ReadLine());
                        Console.WriteLine($"Preço do produto em {datames.ToString("MMMM")} de {ano}: {gerirProdutos.historicoPreço(id, mes, ano)}");
                        break;
                    case 7:
                        foreach (Produto produto in listaProdutos)
                        {
                            Console.WriteLine(produto.ToString());
                        }
                        Console.WriteLine("Id Produto");
                        id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Mes");
                        mes = int.Parse(Console.ReadLine());
                        datames = new DateTime(DateTime.Now.Year, mes, 1);
                        Console.WriteLine("Ano");
                        ano = int.Parse(Console.ReadLine());
                        Console.WriteLine($"Total de vendas no mes: {datames.ToString("MMMM")} de {ano}: {gerirProdutos.historicoVendas(id, mes, ano)}");
                        break;
                    default:
                        break;
                }
            } while (opc != 0);
        }
        static void menuGerirCompras(GerirCompras gerirCompras ,GerirClientes gerirClientes)
        {
            int opc = 0;
            int id;
            List<Compra> listacompras = new List<Compra>();
            List<Cliente> listaClientes = new List<Cliente>();
            do
            {
                Console.WriteLine("1. Listar Compras");
                Console.WriteLine("2. Procurar compra por cliente");
                Console.WriteLine("0. Voltar");
                opc = int.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        Console.WriteLine("Estado da Compra:");
                        Console.WriteLine("1. Aberto");
                        Console.WriteLine("2. Concluido");
                        Console.WriteLine("3. Tudo");
                        int x= int.Parse(Console.ReadLine());
                        switch (x)
                        {
                            case 1:
                                listacompras = gerirCompras.listarComprasEstado("Aberto");
                                break; 
                            case 2:
                                listacompras = gerirCompras.listarComprasEstado("Concluido");
                                break;
                            case 3:
                                listacompras = gerirCompras.listarComprasEstado("Tudo");
                                break;
                        }
                        foreach (Compra compra in listacompras) { 
                            Console.WriteLine(compra.ToString());
                            foreach (Produto produto in compra.ListaProdutos)
                            {
                                Console.WriteLine("\t" + compra.ToStringCompraProdutos(produto));
                            }
                        }
                        break;
                    case 2:

                        listaClientes = gerirClientes.listarClientes();
                        foreach (Cliente cliente in listaClientes) 
                        { 
                            Console.WriteLine(cliente.ToString());
                        }
                        Console.WriteLine("Id Cliente");
                        id = int.Parse(Console.ReadLine());
                        listacompras =gerirCompras.listarComprasCliente(gerirClientes.procurarCliente(id),"Tudo");
                        foreach (Compra compra in listacompras)
                        {
                            Console.WriteLine(compra.ToString());
                            foreach (Produto produto in compra.ListaProdutos)
                            {
                                Console.WriteLine("\t" + compra.ToStringCompraProdutos(produto));
                            }
                        }
                        break;
                    default:
                        break;
                }
            } while (opc != 0);
        }

        static void menuGerirFaturas(GerirFaturas gerirFaturas, GerirClientes gerirClientes)
        {
            int opc = 0;
            int ano;
            int id;
            List<Fatura> listaFaturas = new List<Fatura>();
            List<Cliente> listaClientes = new List<Cliente>();
            do
            {
                Console.WriteLine("1. Listar Faturas");
                Console.WriteLine("2. Faturamento Anual");
                Console.WriteLine("3. Faturamento Mensal");
                Console.WriteLine("4. Listar faturas do Cliente");
                Console.WriteLine("0. Voltar");
                opc = int.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        listaFaturas = gerirFaturas.Listarfaturas();
                        foreach (Fatura fatura in listaFaturas)
                        {
                            Console.WriteLine(fatura.ToString());
                        }
                        break;
                    case 2:
                        Console.WriteLine("Ano");
                        ano = int.Parse(Console.ReadLine());
                        int total = gerirFaturas.faturamentoAnual(new DateTime(ano, 1, 1));
                        Console.WriteLine($"Total faturado no ano {ano}: {total}");
                        break;
                    case 3:
                        Console.WriteLine("mes");
                        int mes = int.Parse(Console.ReadLine());
                        Console.WriteLine("ano");
                        ano = int.Parse(Console.ReadLine());
                        total = gerirFaturas.faturamentoMensal(new DateTime(ano, mes, 1));
                        Console.WriteLine($"Total faturado no mes {new DateTime(ano, mes, 1).ToString("MMMM")} de {ano}: {total}");
                        break;
                    case 4:
                        listaClientes = gerirClientes.listarClientes();
                        foreach (Cliente cliente in listaClientes)
                        {
                            Console.WriteLine(cliente.ToString());
                        }
                        Console.WriteLine("Id Cliente");
                        id = int.Parse(Console.ReadLine());
                        listaFaturas = gerirFaturas.ListarfaturasCliente(gerirClientes.procurarCliente(id));
                        foreach (Fatura fatura in listaFaturas)
                        {
                            Console.WriteLine(fatura.ToString());
                        }
                        break;
                    case 5:
                       
                        break;
                    case 6:
                        
                        break;
                    case 7:
                        break;
                    default:
                        break;
                }
            } while (opc != 0);
        }

        static void menuGerirFuncionarios(GerirFuncionarios gerirFuncionarios)
        {
            int opc = 0;
            int id;
            string nome;
            string contacto;
            int salario;
            string cargo;
            int numeroCC;
            List<Funcionario> listaFuncionarios = new List<Funcionario>();
            do
            {
                Console.WriteLine("1. Adicionar funcionario");
                Console.WriteLine("2. Calcular despesas mensais");
                Console.WriteLine("3. Remover funcionario");
                Console.WriteLine("4. Listar funcionarios por anos de contrato");
                Console.WriteLine("5. Listar funcionarios por idade");
                Console.WriteLine("0. Voltar");
                opc = int.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        Console.WriteLine("Nome");
                        nome = Console.ReadLine();
                        Console.WriteLine("Numero do Cartao de cidadao");
                        numeroCC = int.Parse(Console.ReadLine());
                        Console.WriteLine("Contacto");
                        contacto = Console.ReadLine();
                        Console.WriteLine("Cargo");
                        cargo = Console.ReadLine();
                        Console.WriteLine("Salario mensal");
                        salario = int.Parse(Console.ReadLine());
                        Console.WriteLine("Data de Nascimento");
                        Console.Write("Dia:");
                        int dia = int.Parse(Console.ReadLine());
                        Console.Write("Mes:");
                        int mes = int.Parse(Console.ReadLine());
                        Console.Write("Ano:");
                        int ano = int.Parse(Console.ReadLine());
                        DateTime dataNasc = new DateTime(ano, mes, dia);
                        Console.WriteLine("Data de Admissao");
                        Console.Write("Dia:");
                        dia = int.Parse(Console.ReadLine());
                        Console.Write("Mes:");
                        mes = int.Parse(Console.ReadLine());
                        Console.Write("Ano:");
                        ano = int.Parse(Console.ReadLine());
                        DateTime dataAdmissao = new DateTime(ano, mes, dia);
                        gerirFuncionarios.adicionarFuncionario(new Funcionario(numeroCC, nome, contacto, dataAdmissao, salario,cargo, dataNasc)) ;
                        break;
                    case 2:
                        int total = gerirFuncionarios.calcularDespesaSalarios("Tudo");
                        Console.WriteLine($"Valor total:{total}");
                        break;
                    case 3:
                        listaFuncionarios = gerirFuncionarios.listarFuncPorCargo("Tudo");
                        foreach(Funcionario funcionario in listaFuncionarios)
                        {
                            Console.WriteLine(funcionario.ToString());
                        }
                        Console.WriteLine("id");
                        id = int.Parse(Console.ReadLine());
                        gerirFuncionarios.removerFuncionario(gerirFuncionarios.procurarFuncionario(id));
                        break;
                    case 4:
                        listaFuncionarios = gerirFuncionarios.ordenarFuncAnosContarto();
                        foreach (Funcionario funcionario in listaFuncionarios)
                        {
                            Console.WriteLine(funcionario.ToString());
                        }
                        break;
                    case 5:
                        listaFuncionarios = gerirFuncionarios.ordenarFuncIdade();
                        foreach (Funcionario funcionario in listaFuncionarios)
                        {
                            Console.WriteLine(funcionario.ToString());
                        }
                        break;
                    default:
                        break;
                }
            } while (opc != 0);
        }
        static void menuGerirGarantias(GerirCompras gerirCompras,GerirGarantias gerirGarantias)
        {
            int opc = 0;
            int id;
            Compra compra;
            List<Garantia> listaGarantias = new List<Garantia>();
            List<Compra> listaCompras = new List<Compra>();
            do
            {
                Console.WriteLine("1. Listar garantias");
                Console.WriteLine("2. Listar clientes");
                Console.WriteLine("3. remover cliente");
                Console.WriteLine("0. Voltar");
                opc = int.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        listaCompras = gerirCompras.listarComprasEstado("Concluido");
                        foreach(Compra c in listaCompras)
                        {
                            Console.WriteLine( c.ToString());
                        }
                        id = int.Parse(Console.ReadLine());
                        compra = gerirCompras.procuraCompra(id);
                        listaGarantias = gerirGarantias.garantiaCompra(compra);
                        foreach (Garantia g in listaGarantias)
                        {
                            Console.WriteLine(g.ToString());
                        }
                        break;
                    case 2:
                        
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }
            } while (opc != 0);
        }

        static void Main(string[] args)
        {
            GerirProdutos gerirProdutos = new GerirProdutos();
            GerirCompras gerirCompras = new GerirCompras();
            GerirClientes gerirClientes = new GerirClientes();
            GerirFaturas gerirFaturas =new GerirFaturas();
            GerirFuncionarios gerirFuncionarios = new GerirFuncionarios();
            GerirGarantias gerirGarantias = new GerirGarantias();
            gerirClientes.adicionarCliente( new Cliente("Fabio", 132143, "email", "rua", new DateTime(2000, 11, 15)));
            gerirClientes.adicionarCliente(new Cliente("Joao", 11111111, "email", "rua", new DateTime(2000, 11, 15)));
            gerirProdutos.adicionarMarca(new Marca("Apple"));
            gerirProdutos.adicionarCategoria(new Categoria("Telemovel"));
            gerirProdutos.adicionarMarca(new Marca("Samsung"));
            gerirProdutos.adicionarCategoria(new Categoria("Tv"));
            gerirProdutos.adicionarMarca(new Marca("Lg"));
            gerirProdutos.adicionarCategoria(new Categoria("Tablet"));
            gerirProdutos.adicionarProduto(new Produto("Iphone 6", 4, 3, 500, gerirProdutos.procurarMarca(0),gerirProdutos.procurarCategoria(0)));
            gerirProdutos.adicionarProduto(new Produto("Iphone 7", 6, 100, 700, gerirProdutos.procurarMarca(0), gerirProdutos.procurarCategoria(0)));
            gerirProdutos.adicionarProduto(new Produto("Iphone 8", 3, 100, 900, gerirProdutos.procurarMarca(0), gerirProdutos.procurarCategoria(0)));
            gerirProdutos.adicionarProduto(new Produto("Iphone x", 7, 100, 1200, gerirProdutos.procurarMarca(0), gerirProdutos.procurarCategoria(0)));
            gerirProdutos.adicionarProduto(new Produto("Samsung s2", 8, 3, 500, gerirProdutos.procurarMarca(1), gerirProdutos.procurarCategoria(0)));
            gerirProdutos.adicionarProduto(new Produto("Lg tv A", 10, 100, 700, gerirProdutos.procurarMarca(2), gerirProdutos.procurarCategoria(1)));
            gerirProdutos.adicionarProduto(new Produto("lg Tablet A", 5, 100, 900, gerirProdutos.procurarMarca(2), gerirProdutos.procurarCategoria(2)));
            gerirProdutos.adicionarProduto(new Produto("Samsung tv", 5, 100, 1200, gerirProdutos.procurarMarca(1), gerirProdutos.procurarCategoria(1)));
            gerirCompras.novaCompra(new Compra(gerirClientes.procurarCliente(0)));
            gerirCompras.adicinarProduto(gerirCompras.procuraCompra(0),gerirProdutos.procurarProduto(0), gerirClientes.procurarCliente(0));
            gerirCompras.adicinarProduto(gerirCompras.procuraCompra(0), gerirProdutos.procurarProduto(1),gerirClientes.procurarCliente(0));
            gerirCompras.adicinarProduto(gerirCompras.procuraCompra(0), gerirProdutos.procurarProduto(3),gerirClientes.procurarCliente(1));
            gerirCompras.novaCompra(new Compra(gerirClientes.procurarCliente(0)));
            gerirCompras.adicinarProduto(gerirCompras.procuraCompra(1), gerirProdutos.procurarProduto(2),gerirClientes.procurarCliente(0));
            gerirCompras.adicinarProduto(gerirCompras.procuraCompra(1), gerirProdutos.procurarProduto(1), gerirClientes.procurarCliente(0));
            gerirCompras.adicinarProduto(gerirCompras.procuraCompra(1), gerirProdutos.procurarProduto(1), gerirClientes.procurarCliente(0));
            gerirFuncionarios.adicionarFuncionario(new Funcionario(122432,"ewqeqwe","fdsfdsf", new DateTime(2020, 11, 15),1000,"prog", new DateTime(2000, 11, 15)));
            Compra compra = gerirCompras.procuraCompra(1);
            if(gerirCompras.pagarCompra(gerirClientes.procurarCliente(0), compra, 2300) ==1)
            {
                gerirFaturas.adicionarFatura(new Fatura(gerirCompras.procuraCompra(1)));
                foreach (Produto produto in compra.ListaProdutos) {
                    gerirProdutos.adicionarVenda(produto, DateTime.Now.Month, DateTime.Now.Year, 1);
                }
                gerirGarantias.adicionarGarantia(gerirCompras.procuraCompra(1));
            }
            gerirGarantias.verificarGarantias();
            gerirGarantias.verificarGarantias();
            gerirGarantias.verificarGarantias();
            menuGerente(gerirProdutos, gerirCompras, gerirClientes, gerirFaturas, gerirFuncionarios,gerirGarantias);
            menuCliente(gerirCompras, gerirProdutos, gerirFaturas, gerirGarantias, gerirClientes.procurarCliente(0));
            menuGerente(gerirProdutos, gerirCompras, gerirClientes, gerirFaturas, gerirFuncionarios,gerirGarantias);
            /* GerirProdutos gerir= new GerirProdutos();
             GerirFaturas gerirFaturas= new GerirFaturas();
             gerir.adicionarMarca( new Marca(1, "apple"));
             gerir.adicionarMarca( new Marca(2, "samsung"));
             gerir.adicionarCategoria( new Categoria(1, "Telemovel"));
             Marca marca = gerir.procurarMarca(1);
             Categoria categoria = gerir.procurarCategoria(1);
             gerir.adicionarProduto(new Produto("iphone", 10, 100, 8999,marca,categoria));
             marca = gerir.procurarMarca(2);
             gerir.adicionarProduto(new Produto("samsung", 10, 600, 400,marca,categoria));
             gerir.adicionarProduto(new Produto("iphone", 10, 600, 400, marca, categoria));
             gerir.adicionarProduto(new Produto("samsung s2", 10, 600, 400, marca, categoria));
             gerir.adicionarProduto(new Produto("iphone X", 10, 600, 400, marca, categoria));
             gerir.adicionarPreço(0, 12, 2024, 1000);
             gerir.adicionarPreço(2, 12, 2022, 1000);
             Console.WriteLine(gerir.historicoPreço(0, 12, 2024));
             GerirCompras gerirCompras = new GerirCompras();
             Cliente cliente = new Cliente(0,"fabio");
             Cliente cliente2 = new Cliente(1,"pedro");
             gerirCompras.novaCompra(new Compra(cliente));
             gerirCompras.adicinarProduto(0, gerir.procurarProduto(0));
             gerirCompras.adicinarProduto(0, gerir.procurarProduto(1));
             List<Produto> porcategoria = gerir.procurarPorCategoria(1);
             gerirCompras.novaCompra(new Compra(cliente));
             gerirCompras.adicinarProduto(1, gerir.procurarProduto(2));
             gerirCompras.adicinarProduto(1, gerir.procurarProduto(3));
             gerirCompras.novaCompra(new Compra(cliente2));
             gerirCompras.adicinarProduto(2, gerir.procurarProduto(1));
             gerirCompras.adicinarProduto(2, gerir.procurarProduto(1));
             gerirCompras.removerProduto(2, gerir.procurarProduto(1));
             gerirCompras.removerProduto(2, gerir.procurarProduto(2));
             /*if (gerirCompras.pagarCompra(2, 400))
             {
                 gerirFaturas.adicionarFatura(new Fatura(gerirCompras.procuraCompra(2)));
             }

             foreach (var produto in porcategoria)
             {
                 Console.WriteLine($"Id: {produto.IdProduto} - Nome {produto.Nome} - preço {produto.PreçoAtual} - Categoria: {produto.C.Nome}");
             }
             gerir.procurarCategoria(1);
             foreach(var produto in gerir.Produtos)
             {
                 Console.WriteLine($"Id: {produto.IdProduto} - Nome {produto.Nome} - Quantidade {produto.Quantidade}");
             }
            /* List<Compra> compras = gerirCompras.listarComprasEstado("Cancelado");
             foreach (var compra in compras)
             {
                 Console.WriteLine($"Idcompra: {compra.IdCompra} -Total {compra.Total}");
                 foreach (Produto produto in compra.ListaProdutos)
                 {
                     Console.WriteLine($"\tIdproduto: {produto.IdProduto} -Preço {produto.PreçoAtual}");
                 }
             }*/
            /*List<Compra> comprascliente = gerirCompras.listarComprasCliente(cliente2,"Concluido");
            foreach (var compra in comprascliente)
            {
                Console.WriteLine($"Idcompra: {compra.IdCompra} -Total {compra.Total}");
                foreach (Produto produto in compra.ListaProdutos)
                {
                    Console.WriteLine($"\tIdproduto: {produto.IdProduto} -Preço {produto.PreçoAtual}");
                }
            }

            List<Fatura> faturasCliente = gerirFaturas.ListarfaturasCliente(cliente2);
            foreach (var fatura in faturasCliente)
            {
                Console.WriteLine($"Idcompra: {fatura.IdFatura} -Total {fatura.Total} Dia pagamento{fatura.Datafatura}");
                foreach (Produto produto in fatura.Compra.ListaProdutos)
                {
                    Console.WriteLine($"\tIdproduto: {produto.IdProduto} -Preço {produto.PreçoAtual}");
                }
            }*/
            do 
            { 
            
            }
            while (true);


        }
    }
}
