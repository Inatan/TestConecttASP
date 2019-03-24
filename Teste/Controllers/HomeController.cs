using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Teste.Models;

namespace Teste.Controllers
{
    public class HomeController : Controller
    {
        private const int IDADE_MINMA = 18;

        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// Adiciona os dados cadastrados no banco de dados
        /// A inserção foi realizada via insert pois utilizamos o campo id como identity
        /// </summary>
        /// <param name="pessoa"></param>
        public void Adicionar(Pessoa pessoa)
        {
            using (TesteBanco BD = new TesteBanco())
            {
                // Insert executado para para melhor controle, o id é auto-incremento
                string sql = String.Format(@"
                        Insert Into [dbo].[Pessoa] 
                        Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", 
                                pessoa.Nome, 
                                pessoa.CPF, 
                                pessoa.Nascimento, 
                                pessoa.Email, 
                                pessoa.Empresa, 
                                pessoa.TelefoneComercial, 
                                pessoa.TelefoneCelular);
                BD.Database.ExecuteSqlCommand(sql);
            }
        }


        /// <summary>
        /// Apresenta relatório dopp
        /// </summary>
        /// <returns></returns>
        public ActionResult Relatorio()
        {
            TesteBanco BD = new TesteBanco();
            List<Pessoa> pessoas = BD.Pessoa.ToList();
            for (int i = 0; i < pessoas.Count; i++)
            {
                pessoas[i].Idade = BuscaIdade(pessoas[i].Nascimento);
            }
            pessoas = MergeSort(pessoas);
            return View(pessoas);
        }




        /// <summary>
        /// Função para calcular idade do usuário
        /// Cálculo da idade foi escolhido para ser em tempo de execução, pois seria exigido a cada troca de idade uma rotina de atualização no banco de dados.
        /// Desta forma obtendo a data de nascimento já pode se obter a idade do inscrito.
        /// </summary>
        /// <param name="nascimento"></param>
        /// <returns></returns>
        private int BuscaIdade(DateTime nascimento)
        {
            int idade = DateTime.Today.Year - nascimento.Year;
            if (nascimento > DateTime.Today.AddYears(-idade))
                idade--;
            return idade;
        }

        /// <summary>
        /// Algoritmo implementado foi o Mergesort por possuir uma complexiadae O(Nlogn)
        /// Divide no meio a lista até sobrer listas de um elemento, logo após é executado o merge entre os elemento dividos, nessa etapa os elementos são ordenados.
        /// </summary>
        /// <param name="Pessoas"></param>
        /// <returns></returns>
        private List<Pessoa> MergeSort(List<Pessoa> Pessoas)
        {
            if (Pessoas.Count <= 1)
                return Pessoas;
            List<Pessoa> esquerda = new List<Pessoa>();
            List<Pessoa> direita = new List<Pessoa>();
            int meio = Pessoas.Count / 2;
            for (int i = 0; i < meio; i++)  //Dividing the unsorted list
            {
                esquerda.Add(Pessoas[i]);
            }
            for (int i = meio; i < Pessoas.Count; i++)
            {
                direita.Add(Pessoas[i]);
            }
            esquerda = MergeSort(esquerda);
            direita = MergeSort(direita);
            return Merge(esquerda, direita);
        }


        /// <summary>
        /// Compara duas listas, compara os elementos e os adiciona em uma nova lista de maneira ordenada.
        /// </summary>
        /// <param name="esquerda"></param>
        /// <param name="direita"></param>
        /// <returns></returns>
        private List<Pessoa> Merge(List<Pessoa> esquerda, List<Pessoa> direita)
        {
            List<Pessoa> result = new List<Pessoa>();
            while (esquerda.Count > 0 || direita.Count > 0)
            {
                if (esquerda.Count > 0 && direita.Count > 0)
                {
                    if (esquerda.First().Nascimento >= direita.First().Nascimento)  // Comparação através da data de nascimento, pois dessa forma obtemos ordenação por idade mais precisa
                    {
                        result.Add(esquerda.First());
                        esquerda.Remove(esquerda.First());      
                    }
                    else
                    {
                        result.Add(direita.First());
                        direita.Remove(direita.First());
                    }
                }
                else if (esquerda.Count > 0)
                {
                    result.Add(esquerda.First());
                    esquerda.Remove(esquerda.First());
                }
                else if (direita.Count > 0)
                {
                    result.Add(direita.First());
                    direita.Remove(direita.First());
                }
            }
            return result;
        }


        /// <summary>
        /// Valida cadastro após os testes e validações do modulo
        /// </summary>
        /// <param name="CPF"></param>
        /// <param name="Nome"></param>
        /// <param name="Nascimento"></param>
        /// <returns></returns>
        public JsonResult VerificaCadastroExistente(string CPF, string Nome, DateTime Nascimento)
        {
            TesteBanco BD = new TesteBanco();
            var SeachData = BD.Pessoa.Where(x => x.CPF == CPF || x.Nome == Nome).SingleOrDefault();
            if (SeachData != null)
            {
                return Json("Já existe usuário");
            }
            else
            {
                if (BuscaIdade(Nascimento) < IDADE_MINMA)
                    return Json("Não é possível cadastrar menores de 18 anos");
                else
                    return Json("");
            }
        }

    }
}