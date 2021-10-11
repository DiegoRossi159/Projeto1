using Projeto1.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Projeto1.Controllers
{
    public class VeiculoController : Controller
    {
        VeiculoDbContext db;
        public VeiculoController()
        {
            db = new VeiculoDbContext();
        }
        // GET: Produtos
        public ActionResult Index()
        {
            var veiculos = db.Veiculos.ToList();
            return View(veiculos);
        }
        
        public ActionResult Create()
        {
            
            var model = new VeiculoViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VeiculoViewModel model)
        {
            var imageTypes = new string[]{
                    "image/gif",
                    "image/jpeg",
                    "image/pjpeg",
                    "image/png"
                };
            if (model.ImageUpload == null || model.ImageUpload.ContentLength == 0)
            {
                ModelState.AddModelError("ImageUpload", "Este campo é obrigatório");
            }
            else if (!imageTypes.Contains(model.ImageUpload.ContentType))
            {
                ModelState.AddModelError("ImageUpload", "Escolha uma iamgem GIF, JPG ou PNG.");
            }
            if (ModelState.IsValid)
            {
                var veiculo = new Veiculo();
                veiculo.Placa = model.Placa;
                veiculo.Renavan = model.Renavan;
                veiculo.Nome = model.Nome;
                veiculo.Cpf = model.Cpf;
                // Salva a imagem para a pasta e pega o caminho
                var imagemNome = String.Format("{0:yyyyMMdd-HHmmssfff}", DateTime.Now);
                var extensao = System.IO.Path.GetExtension(model.ImageUpload.FileName).ToLower();
                using (var img = System.Drawing.Image.FromStream(model.ImageUpload.InputStream))
                {
                    veiculo.Imagem = String.Format("/VeiculoImagens/{0}{1}", imagemNome, extensao);
                    // Salva imagem 
                    SalvarNaPasta(img, veiculo.Imagem);
                }
                db.Veiculos.Add(veiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            // Se ocorrer um erro retorna para pagina
            return View(model);
        }
        private void SalvarNaPasta(Image img, string caminho)
        {
            using (System.Drawing.Image novaImagem = new Bitmap(img))
            {
                novaImagem.Save(Server.MapPath(caminho), img.RawFormat);
            }
        }


        // GET: Produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = db.Veiculos.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            
            return View(veiculo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Placa,Renavan,Nome,Cpf")] Veiculo model)
        {
            if (ModelState.IsValid)
            {
                var veiculo = db.Veiculos.Find(model.Id);
                if (veiculo == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                veiculo.Placa = model.Placa;
                veiculo.Renavan = model.Renavan;
                veiculo.Nome = model.Nome;
                veiculo.Cpf = model.Cpf;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(model);
        }


        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Veiculo produto = db.Veiculos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
           
            return View(produto);
        }
        // POST: Veiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Veiculo veiculo = db.Veiculos.Find(id);
            db.Veiculos.Remove(veiculo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo produto = db.Veiculos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            
            return View(produto);
        }


    }
}