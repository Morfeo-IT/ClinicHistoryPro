using ClinicHistoryPro.Application.Services.Interfaces;
using ClinicHistoryPro.Domain.Models;
using ClinicHistoryPro.Infraestructure.Ports;
using Microsoft.EntityFrameworkCore;

namespace ClinicHistoryPro.Application.Services
{
    public class MenuItemAppService : IMenuItemAppService
    {
        private readonly IUnitOfWork unitOfWork;
        public MenuItemAppService(IUnitOfWork unitOfWork) => (this.unitOfWork) = (unitOfWork);
        public async Task<List<MenuItem>> GetMenuHierarchy()
        {
            var menuItems = await unitOfWork.Repository<MenuItem>().GetManyAsync(
                    selector: menu => new MenuItem
                    {
                        MenuItemId = menu.MenuItemId,
                        CreatedAt = menu.CreatedAt,
                        DeletedAt = menu.DeletedAt,
                        DisplayOrder = menu.DisplayOrder,
                        GuidId = menu.GuidId,
                        Name = menu.Name,
                        Status = menu.Status,
                        Url = menu.Url,
                        InverseParentMenuItem = menu.InverseParentMenuItem
                    },
                    predicate: menu => menu.ParentMenuItemId == null,
                    orderBy: menu => menu.OrderBy(o => o.DisplayOrder)
                );


            //var menuItems = await _context.MenuItems
            //.Include(mi => mi.SubMenuItems)
            //.Where(mi => mi.ParentMenuItemID == null)
            //.OrderBy(mi => mi.DisplayOrder)
            //.ToListAsync();

            await LoadSubMenuItems(menuItems);
            return menuItems;
        }

        private async Task LoadSubMenuItems(IEnumerable<MenuItem> menuItems)
        {
            foreach (var menuItem in menuItems)
            {
                //_context.Entry(menuItem)
                //    .Collection(mi => mi.SubMenuItems)
                //    .Query()
                //    .OrderBy(mi => mi.DisplayOrder)
                //    .Load();

                menuItem.InverseParentMenuItem = await GetMenuItems(menuItem.MenuItemId);

                if (menuItem.InverseParentMenuItem != null && menuItem.InverseParentMenuItem.Any())
                {
                    await LoadSubMenuItems(menuItem.InverseParentMenuItem);
                }
            }
        }

        private async Task<List<MenuItem>> GetMenuItems(int id)
        {
            return await unitOfWork.Repository<MenuItem>().GetManyAsync(
                   selector: menu => new MenuItem
                   {
                       MenuItemId = menu.MenuItemId,
                       CreatedAt = menu.CreatedAt,
                       DeletedAt = menu.DeletedAt,
                       DisplayOrder = menu.DisplayOrder,
                       GuidId = menu.GuidId,
                       Name = menu.Name,
                       Status = menu.Status,
                       Url = menu.Url,
                       InverseParentMenuItem = menu.InverseParentMenuItem
                   },
                   predicate: menu => menu.ParentMenuItemId == id,
                   orderBy: menu => menu.OrderBy(o => o.DisplayOrder)
               );
        }
    }
}
