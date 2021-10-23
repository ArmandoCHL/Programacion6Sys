using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace WebApp.Pages.Empleado
{
    public class GridModel : PageModel
    {

        private readonly IEmpleadoService empleadoService;

        public GridModel(IEmpleadoService empleadoService)
        {
            this.empleadoService = empleadoService;
        }

        public IEnumerable<EmpleadoEntity> GridList { get; set; } = new List<EmpleadoEntity>();

        public string Mensaje { get; set; } = "";

        public async Task<IActionResult> OnGet()
        {

            try
            {
                
                GridList = await empleadoService.Get();

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


        public async Task<IActionResult> OnGetEliminar( int id)
        {

            try
            {

                var result = await empleadoService.Delete( entity: new() { IdEmpleado = id});

                if (result.CodeError!=0)
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
