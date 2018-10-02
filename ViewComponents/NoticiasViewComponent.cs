using Fiap01.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap01.ViewComponents
{
    public class NoticiasViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(
        int total, bool noticiasUrgentes)
        {
            string view = "noticias";

            if (total > 3 && noticiasUrgentes == true)
            {
                view = "noticiasurgentes";
            }

            var items = GetItems(total);
            return View(view, items);
        }

        private IEnumerable<Noticia> GetItems(int total)
        {
            for (int i = 0; i < total; i++)
            {
                yield return new Noticia() { Id = i , Titulo = $"Noticia {i}", Link = $"http://{i}" };
            }
        }

    }
}
