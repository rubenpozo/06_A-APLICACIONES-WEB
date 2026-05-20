using Microsoft.AspNetCore.Mvc;
using Web_Clientes.Models;
using System.Collections.Generic;
using System.Linq;

namespace Web_Clientes.Controllers
{
    public class ClientesController : Controller
    {
        // Lista en memoria (quemada en código)
        private static List<ClienteModel> _lista_Clientes = new List<ClienteModel>()
        {
            new ClienteModel{
                Id = 1,
                Nombres="Luis Antonio",
                Apellidos = "LLerena Ocaña",
                Direccion = "Ambato",
                Telefono = "0987654321",
                Correo = "llerecl@gmail.com"
            },
            new ClienteModel{
                Id = 2,
                Nombres="Carlos Antonio",
                Apellidos = "Perez Ocaña",
                Direccion = "Ambato",
                Telefono = "0987654321",
                Correo = "carlos@gmail.com"
            }
        };

        // GET: ClientesController
        public ActionResult Index()
        {
            return View(_lista_Clientes);
        }

        // GET: ClientesController/Details/5
        public ActionResult Details(int id)
        {
            var cliente = _lista_Clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        // GET: ClientesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteModel cliente)
        {
            if (ModelState.IsValid)
            {
                cliente.Id = _lista_Clientes.Any() ? _lista_Clientes.Max(c => c.Id) + 1 : 1;
                _lista_Clientes.Add(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: ClientesController/Edit/5
        public ActionResult Edit(int id)
        {
            var cliente = _lista_Clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        // POST: ClientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ClienteModel clienteEditado)
        {
            if (ModelState.IsValid)
            {
                var cliente = _lista_Clientes.FirstOrDefault(c => c.Id == id);
                if (cliente == null) return NotFound();

                // Actualizar datos
                cliente.Nombres = clienteEditado.Nombres;
                cliente.Apellidos = clienteEditado.Apellidos;
                cliente.Direccion = clienteEditado.Direccion;
                cliente.Telefono = clienteEditado.Telefono;
                cliente.Correo = clienteEditado.Correo;

                return RedirectToAction(nameof(Index));
            }
            return View(clienteEditado);
        }

        // GET: ClientesController/Delete/5
        public ActionResult Delete(int id)
        {
            var cliente = _lista_Clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        // POST: ClientesController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var cliente = _lista_Clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null) return NotFound();

            _lista_Clientes.Remove(cliente);
            return RedirectToAction(nameof(Index));
        }
    }
}
