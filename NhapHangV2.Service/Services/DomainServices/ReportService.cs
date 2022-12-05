using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NhapHangV2.Entities.DomainEntities;
using NhapHangV2.Interface.DbContext;
using NhapHangV2.Interface.Services.DomainServices;
using NhapHangV2.Interface.UnitOfWork;
using NhapHangV2.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Service.Services.DomainServices
{
    public abstract class ReportService<E, T> : IReportService<E, T> where E : Entities.DomainEntities.AppDomainReport where T : BaseSearch, new()
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IMapper mapper;
        protected readonly IAppDbContext Context;
        public ReportService(IUnitOfWork unitOfWork, IMapper mapper, IAppDbContext Context)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.Context = Context;
        }

        public virtual async Task<PagedList<E>> GetPagedListData(T baseSearch)
        {
            PagedList<E> pagedList = new PagedList<E>();
            SqlParameter[] parameters = GetSqlParameters(baseSearch);
            pagedList = await ExcuteQueryPagingAsync(this.GetStoreProcName(), parameters);
            pagedList.PageIndex = baseSearch.PageIndex;
            pagedList.PageSize = baseSearch.PageSize;
            return pagedList;
        }

        protected virtual string GetStoreProcName()
        {
            return string.Empty;
        }

        protected virtual SqlParameter[] GetSqlParameters(T baseSearch)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            foreach (PropertyInfo prop in baseSearch.GetType().GetProperties())
            {
                sqlParameters.Add(new SqlParameter(prop.Name, prop.GetValue(baseSearch, null)));
            }
            SqlParameter[] parameters = sqlParameters.ToArray();
            return parameters;
        }

        public virtual Task<PagedList<E>> ExcuteQueryPagingAsync(string commandText, SqlParameter[] sqlParameters)
        {
            return Task.Run(() =>
            {
                PagedList<E> pagedList = new PagedList<E>();
                DataTable dataTable = new DataTable();
                SqlConnection connection = null;
                SqlCommand command = null;
                try
                {
                    connection = (SqlConnection)Context.Database.GetDbConnection();
                    command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = commandText;
                    command.Parameters.AddRange(sqlParameters);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                    sqlDataAdapter.Fill(dataTable);
                    pagedList.Items = MappingDataTable.ConvertToList<E>(dataTable);
                    if (pagedList.Items != null && pagedList.Items.Any())
                        pagedList.TotalItem = pagedList.Items.FirstOrDefault().TotalItem;
                    return pagedList;
                }
                finally
                {
                    if (connection != null && connection.State == System.Data.ConnectionState.Open)
                        connection.Close();

                    if (command != null)
                        command.Dispose();
                }
            });
        }
    }
}
