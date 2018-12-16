using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConsumirWSCorreios.Correios;
using ConsumirWSCorreios.Models;

namespace ConsumirWSCorreios.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

       public PartialViewResult ObterCep(string cep)
        {

            var cli = new Cliente();

            try
            {

                var ConsultaCorreios = new AtendeClienteClient().consultaCEP(cep);

                //Binding with my Model     
                cli.CEP = ConsultaCorreios.cep;
                cli.Bairro = ConsultaCorreios.bairro;
                cli.Cidade = ConsultaCorreios.cidade;
                cli.Endereco = ConsultaCorreios.end;
                cli.UF = ConsultaCorreios.uf;
                


            }

            catch (System.Exception a)
            {

                ViewData["Erro"] = a.Message;

                return PartialView("Error");
              
            }
       
            //Chamei o método principal da Classe do nosso cliente terceiro e bem como chamei o método consultaCep();
            return PartialView(cli);
        }

    }
}