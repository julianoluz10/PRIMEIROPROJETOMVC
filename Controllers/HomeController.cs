using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PrimeiroProjetoMVC.Models;

namespace PrimeiroProjetoMVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        // A view Index lê essa chave para exibir a mensagem
        ViewData["Mensagem"] = "Bem-Vindo ao sistema!";
        return View();
    }
    // Action que recebe parametro pela :/HOME/SOBRE/5
    public IActionResult Sobre (int? id)
    {
        ViewBag.Versao = "1.0";
        ViewBag.ParametroId = id;

        return View();

    }
    // Action recebe parametros via query string: /HOME/SAUDACAO?nome = KESSIA

    public IActionResult Saudacao(string nome)
    {
        // Model Binding obtem nome da URL usa "Visitante se nada for informado"
        ViewData["Nome"] = nome ?? "Visitante";
        return View(); 
    }

    
  

  
}
