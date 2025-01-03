﻿using SharedLibrary.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.GenericServices
{
    public interface IServiceGeneric<TEntity,TDTO>where TEntity : class where TDTO : class
    {
        Task<Response<TDTO>> GetByIdAsync(int id);
        Task<Response<IEnumerable<TDTO>>> GetAllAsync();
        //??
        Task<Response<IEnumerable<TDTO>>> Where(Expression<Func<TEntity, bool>> predicate);
        Task <Response<TDTO>>AddAsync(TDTO entity);
        Task<Response<NoDataDto>> Remove(int id);
        Task<Response<NoDataDto>> Update(TDTO entity, int id);

    }
}
