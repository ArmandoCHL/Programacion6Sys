using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace WebApp.Pages.TipoIdentificacion
{
    public class GridModel : PageModel
    {

        private readonly ITipoIdentificacionService TipoIdentificacionService;

        public GridModel(ITipoIdentificacionService TipoIdentificacionService)
        {
            this.TipoIdentificacionService = TipoIdentificacionService;
        }

        public IEnumerable<TipoIdentificacionEntity> GridList { get; set; } = new List<TipoIdentificacionEntity>();

        public string Mensaje { get; set; } = "";

        public async Task<IActionResult> OnGet()
        {

            try
            {

                GridList = await TipoIdentificacionService.Get();

                if (TempData.ContainsKey(key: "Msg"))
                {
                    Mensaje = TempData[key: "Msg"] as String;
                }

                TempData.Clear();

                return Page();

            }
            catch (Exception ex)
            {

                return Content(content: ex.Message);
            }

        }


        public async Task<IActionResult> OnGetEliminar(int id)
        {

            try
            {

                var result = await TipoIdentificacionService.Delete(entity: new() { IdTipoIdentificacion = id });

                if (result.CodeError != 0)
                {
                    throw new Exception(result.MsgError);
                }

                TempData[key: "Msg"] = "Se eliminó correctamente";

                return Redirect(url: "Grid");

            }
            catch (Exception ex)
            {

                return Content(content: ex.Message);
            }

        }



    }
}