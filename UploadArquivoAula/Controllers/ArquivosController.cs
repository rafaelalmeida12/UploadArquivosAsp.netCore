using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UploadArquivoAula.Infraestrutura;
using UploadArquivoAula.Models;

namespace UploadArquivoAula.Controllers
{
    public class ArquivosController : Controller
    {
        ArquivoContext _arquivoContext;

        public ArquivosController(ArquivoContext arquivoContext)
        {
            _arquivoContext = arquivoContext;
        }

        public IActionResult Index()
        {
            var arquivos = _arquivoContext.Arquivos.ToList();
            return View(arquivos);
        }

        [HttpPost]
        public IActionResult UploadImagem(IList<IFormFile> arquivos)
        {
            IFormFile imagemCarregada = arquivos.FirstOrDefault();

            if (imagemCarregada != null)
            {
                MemoryStream ms = new MemoryStream();
                imagemCarregada.OpenReadStream().CopyTo(ms);

                Arquivos arqui = new Arquivos()
                {
                    Descricao = imagemCarregada.FileName,
                    Dados = ms.ToArray(),
                    ContentType = imagemCarregada.ContentType
                };

                _arquivoContext.Arquivos.Add(arqui);
                _arquivoContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Visualizar(int id)
        {
            var arquivosBanco = _arquivoContext.Arquivos.FirstOrDefault(a => a.Id == id);

            return File(arquivosBanco.Dados, arquivosBanco.ContentType);
        }
    }
}
