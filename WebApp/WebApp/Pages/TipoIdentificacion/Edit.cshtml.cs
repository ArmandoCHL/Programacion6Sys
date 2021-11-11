using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entity;
using WBL;

namespace WebApp.Pages.TipoIdentificacion
{
    public class EditModel : PageModel
    {
        private readonly ITipoIdentificacionService TipoIdentificacionService;

        public EditModel(ITipoIdentificacionService TipoIdentificacionService)
        {
            this.TipoIdentificacionService = TipoIdentificacionService;
        }

        [BindProperty]
        public TipoIdentificacionEntity Entity { get; set; } = new TipoIdentificacionEntity();

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await TipoIdentificacionService.GetById(new() { IdTipoIdentificacion = id });
                }

                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }


        }

        public async Task<IActionResult> OnPostAsync()
        {

            try
            {
                //Metodo Actualizar
                if (Entity.IdTipoIdentificacion.HasValue)
                {
                    var result = await TipoIdentificacionService.Update(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "El registro se ha actualizado";
                }
                else
                {
                    var result = await TipoIdentificacionService.Create(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "El registro se ha insertado";
                }

                return RedirectToPage("Grid");
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }


        }

    }






}