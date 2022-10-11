using Application.Dto;
using Application.Services.Interfaces;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.MainModule.Repositories
{
    public class RolOptionsRepository : IRolOptionsRepository
    {
        private readonly DBGNVContext context;

        public RolOptionsRepository(DBGNVContext context)
        {
            this.context = context;
        }
          
        public async Task<MenuResponseDTO> GetListRolOptions(int rol)
        {
            MenuResponseDTO menuResponseDTO = new MenuResponseDTO();
            MenuDTO objMenu = new MenuDTO();

            objMenu.MenusPadre = await (from optionRol in context.RolesMenus
                                        join optionMenuPadre in context.MenuPadre on optionRol.OptionId equals optionMenuPadre.IdOpcion
                                        where optionRol.RolId == rol && optionMenuPadre.Activo == true
                                        orderby optionMenuPadre.Orden ascending
                                        select new MenuPadre { 
                                           IdPadre = optionMenuPadre.IdOpcion,
                                           DescMenu = optionMenuPadre.DescMenu,
                                           UrlImagen = optionMenuPadre.UrlImagen
                                        }).ToListAsync(); 

            objMenu.MenusPadre.ForEach(itemPadre =>
            { 
                itemPadre.MenusHijos =  (from menuHijo in context.MenuHijo
                            where menuHijo.IdMenuPadre == itemPadre.IdPadre
                            select new MenuHijo
                            {
                                IdPadre = menuHijo.IdMenuPadre,
                                IdHijo = menuHijo.IdMenuHijo,
                                IdOpcion = menuHijo.IdOpcion.Value,
                                DescMenu =  menuHijo.DescMenu,
                                Url = menuHijo.Url,
                                ActivoHijo = menuHijo.Activo
                            }).ToList();
            });
            menuResponseDTO.Menus = objMenu;
            return menuResponseDTO; 
        }
    }
}