using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrimeiroProjetoMVC.Models;
using PrimeiroProjetoMVC.ViewModels;

namespace PrimeiroProjetoMVC.Controllers
{
    
    public class AlunosController : Controller
    {
      
      private static List<Aluno> _alunos = new()
      {
        new Aluno{Id = 1, Nome = "Daniel Vorcaro", Email= "contato.daniel.vorcaro@gmail.com", Idade= 43},
        new Aluno{Id = 2, Nome = "Diogo Chelles", Email= "pi.diogo@gmail", Idade= 18}
      };

      //GET /Alunos - Listar todos os alunos 
        public IActionResult Index()
        {
            return View(_alunos);
        }

        public IActionResult Detalhes(int id)
        {
            var aluno = _alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }
        // GET/Alunos/Criar => Exibir a view com todos os alunos.
        [HttpGet]

        public IActionResult Criar()
        {
            return View();
        }

        // POST/Alunos/Criar=> receber dados da view Por meio de um formulario  de cadastro para adicionar um novo Aluno.
        [HttpPost]
        public IActionResult Criar(Aluno aluno)
        {
            if (!ModelState.IsValid)//Verfificar se as validações atribuidas na Model foram cumpridas
            {
                return View(aluno);//Retornar com erros de validação

            }
                aluno.Id = _alunos.Any() ? _alunos.Max(a => a.Id) + 1 : 1;

                _alunos.Add(aluno);

                return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Buscar()
        {
            return View(new BuscaAlunoViewModel());
        }

        [HttpPost]
        public IActionResult Buscar(BuscaAlunoViewModel vm)
        {
            vm.Resultados = _alunos;//Carrega a lista de alunos na propiedade Resultados do objeto VM

            if (!string.IsNullOrEmpty(vm.TermoBusca))
            {
                // Se termo busca não for vazio pesquise o termo na lista de resultados
                vm.Resultados = _alunos.Where(a => a.Nome.Contains(vm.TermoBusca, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return View(vm);
        }

        
    }
}