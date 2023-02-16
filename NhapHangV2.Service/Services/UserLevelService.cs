using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NhapHangV2.Entities;
using NhapHangV2.Entities.DomainEntities;
using NhapHangV2.Interface.DbContext;
using NhapHangV2.Interface.Services;
using NhapHangV2.Interface.UnitOfWork;
using NhapHangV2.Service.Services.DomainServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Service.Services
{
    public class UserLevelService : DomainService<UserLevel, BaseSearch>, IUserLevelService
    {
        protected readonly IAppDbContext Context;

        public UserLevelService(IAppUnitOfWork unitOfWork, IMapper mapper, IAppDbContext context) : base(unitOfWork, mapper)
        {
            Context = context;
        }

        protected override string GetStoreProcName()
        {
            return "UserLevel_GetPagingData";
        }

        public override async Task<bool> UpdateAsync(UserLevel item)
        {
            using (var dbContextTransaction = Context.Database.BeginTransaction())
            {
                try
                {
                    unitOfWork.Repository<UserLevel>().Update(item);
                    var users = await unitOfWork.Repository<Users>().GetQueryable().Where(x => x.LevelId == item.Id && !x.Deleted).ToListAsync();
                    foreach (var user in users)
                    {
                        decimal transactionMoney = user.TransactionMoney;
                        var userLevel = await unitOfWork.Repository<UserLevel>().GetQueryable().FirstOrDefaultAsync(x => transactionMoney >= x.Money && transactionMoney < x.MoneyTo);
                        if (user.LevelId != userLevel.Id)
                        {
                            user.LevelId = userLevel.Id;
                            user.DateUpLevel = DateTime.Now;
                            await unitOfWork.Repository<Users>().UpdateFieldsSaveAsync(user, new Expression<Func<Users, object>>[]
                            {
                                x => x.LevelId,
                                x => x.DateUpLevel
                            });
                        }
                    }
                    await unitOfWork.SaveAsync();
                    await dbContextTransaction.CommitAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    await dbContextTransaction.RollbackAsync();
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
