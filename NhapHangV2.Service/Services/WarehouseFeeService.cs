using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NhapHangV2.Entities;
using NhapHangV2.Entities.Catalogue;
using NhapHangV2.Entities.DomainEntities;
using NhapHangV2.Entities.Search;
using NhapHangV2.Interface.Services;
using NhapHangV2.Interface.UnitOfWork;
using NhapHangV2.Service.Services.DomainServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Service.Services
{
    public class WarehouseFeeService : DomainService<WarehouseFee, WarehouseFeeSearch>, IWarehouseFeeService
    {
        public WarehouseFeeService(IAppUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        protected override string GetStoreProcName()
        {
            return "WarehouseFee_GetPagingData";
        }

        public override async Task<WarehouseFee> GetByIdAsync(int id)
        {
            var item = await Queryable.Where(e => e.Id == id && !e.Deleted).AsNoTracking().FirstOrDefaultAsync();
            if (item == null)
                return null;

            var warehouseFrom = await unitOfWork.CatalogueRepository<WarehouseFrom>().GetQueryable().Where(e => !e.Deleted && e.Id == item.WarehouseFromId).FirstOrDefaultAsync();
            if (warehouseFrom != null)
                item.WarehouseFromName = warehouseFrom.Name;

            var warehouse = await unitOfWork.CatalogueRepository<Warehouse>().GetQueryable().Where(e => !e.Deleted && e.Id == item.WarehouseId).FirstOrDefaultAsync();
            if (warehouse != null)
                item.WareHouseToName = warehouse.Name;

            var shippingTypeToWareHouse = await unitOfWork.CatalogueRepository<ShippingTypeToWareHouse>().GetQueryable().Where(e => !e.Deleted && e.Id == item.ShippingTypeToWareHouseId).FirstOrDefaultAsync();
            if (shippingTypeToWareHouse != null)
                item.ShippingTypeToWareHouseName = shippingTypeToWareHouse.Name;

            return item;
        }
    }
}
