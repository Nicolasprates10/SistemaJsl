using SistemaCaminhoneiro.Models;
using SistemaCaminhoneiro.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaCaminhoneiro.Controllers
{
    public class CaminhoneiroController : Controller
    {
        private CaminhoneiroRepositorio _repositorio;
        [HttpGet]


        // GET: Caminhoneiro
        public ActionResult ObterCaminhoneiro()
        {
            _repositorio = new CaminhoneiroRepositorio();
            _repositorio.ObterCaminhoneiros();
            ModelState.Clear();

            return View(_repositorio.ObterCaminhoneiros());
        }
        [HttpGet]
        public ActionResult IncluiCaminhoneiro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IncluiCaminhoneiro(Motorista obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repositorio = new CaminhoneiroRepositorio();
                    if (_repositorio.AdicionarCaminhoneiro(obj))
                    {
                        ViewBag.Mensagem = "Motorista Cadastrado Com sucesso!";
                    }


                }
                return View();
            }
            catch (Exception erro)
            {
                return View("ObterCaminhoneiro");
            }
        }
        [HttpGet]
        public ActionResult EditarCaminhoneiro(int id)
        {
            _repositorio = new CaminhoneiroRepositorio();
            return View(_repositorio.ObterCaminhoneiros().Find(x => x.Cod == id));
        }

        [HttpPost]
        public ActionResult EditarCaminhoneiro(int id , Motorista obj)
        {
            try
            {
                _repositorio = new CaminhoneiroRepositorio();
                _repositorio.AtualizarCaminhoneiro(obj);
                return RedirectToAction("ObterCaminhoneiro");
            }
            catch (Exception)
            {
                return RedirectToAction("ObterCaminhoneiro");
            }
            return RedirectToAction("ObterCaminhoneiro");

        }

        public ActionResult ExcluirCaminhoneiro(int id)
        {
            try
            {
                _repositorio = new CaminhoneiroRepositorio();
                if(_repositorio.ExcluirCaminhoneiro(id))
                    {
                    ViewBag.Mensagem = "Excluido Com Sucesso!";
                    return RedirectToAction("ObterCaminhoneiro");

                }
            }
            catch
            {
                return RedirectToAction("ObterCaminhoneiro");
            }
            return RedirectToAction("ObterCaminhoneiro");

        }

    }
}