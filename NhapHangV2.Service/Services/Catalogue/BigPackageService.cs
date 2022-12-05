﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NhapHangV2.Entities;
using NhapHangV2.Entities.Catalogue;
using NhapHangV2.Entities.DomainEntities;
using NhapHangV2.Interface.Services.Catalogue;
using NhapHangV2.Interface.UnitOfWork;
using NhapHangV2.Service.Services.DomainServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Service.Services.Catalogue
{
    public class BigPackageService : CatalogueService<BigPackage, CatalogueSearch>, IBigPackageService
    {
        public BigPackageService(IAppUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            IsUseStore = true;
        }

        protected override string GetStoreProcName()
        {
            return "BigPackage_GetPagingData";
        }

        public override async Task<BigPackage> GetByIdAsync(int id)
        {
            var bigPackage = await Queryable.Where(e => e.Id == id && !e.Deleted).AsNoTracking().FirstOrDefaultAsync();
            if (bigPackage == null)
                return null;
            var smallPackage = await unitOfWork.Repository<SmallPackage>().GetQueryable().Where(e => !e.Deleted && e.BigPackageId == bigPackage.Id).OrderByDescending(o => o.Id).ToListAsync();
            if (smallPackage.Any())
                bigPackage.SmallPackages = smallPackage;
            return bigPackage;
        }

        /// <summary>
        /// Cập nhật thông tin người dùng
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        //public override async Task<bool> UpdateAsync(BigPackage item)
        //{
        //    bool result = true;

        //    return result;
        //}
    }
}
