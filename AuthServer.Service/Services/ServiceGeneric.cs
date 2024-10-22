using AuthServer.Core.GenericServices;
using AuthServer.Core.Repositories;
using AuthServer.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Service.Services
{
    public class ServiceGeneric<TEntity, TDTO> : IServiceGeneric<TEntity, TDTO> where TDTO : class where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepositoy<TEntity> _genericRepositoy;
        public ServiceGeneric(IUnitOfWork unitOfWork, IGenericRepositoy<TEntity> genericRepositoy)
        {
            _unitOfWork = unitOfWork;
            _genericRepositoy = genericRepositoy;
            
        }
        public async Task<Response<TDTO>> AddAsync(TDTO tDto)
        {
            var newEntity = ObjectMapper.Mapper.Map<TEntity>(tDto);
            await _genericRepositoy.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();
            var newDto = ObjectMapper.Mapper.Map<TDTO>(newEntity);
            return Response<TDTO>.Success(newDto, 200);
        }

        public async Task<Response<IEnumerable<TDTO>>> GetAllAsync()
        {
            var newEntity = await _genericRepositoy.GetAllAsync();
            var newDto = ObjectMapper.Mapper.Map<List<TDTO>>(newEntity);
            return Response<IEnumerable<TDTO>>.Success(newDto, 200);
        }

        public async Task<Response<TDTO>> GetByIdAsync(int id)
        {
            var product = await _genericRepositoy.GetByIdAsync(id);
            if(product == null)
            {
                return Response<TDTO>.Fail("Id not found", 404, true);
            }
            return Response<TDTO>.Success(ObjectMapper.Mapper.Map<TDTO>(product), 200);
        }

        public async Task<Response<NoDataDto>> Remove(int id)
        {
            var toBeRemovedProduct = await _genericRepositoy.GetByIdAsync(id);
            if(toBeRemovedProduct == null)
            {
                return Response<NoDataDto>.Fail("Id not found", 404, true);
            }
            _genericRepositoy.Remove(toBeRemovedProduct);
            await _unitOfWork.CommitAsync();
            return Response<NoDataDto>.Success(200);
        }

        public async Task<Response<NoDataDto>> Update(TDTO tDto, int id)
        {
            var IsProductExisted = await _genericRepositoy.GetByIdAsync(id);
            //Bu getbyId memoryden detached edilmesinin sebebi updateEntity ile aynı değerleri tutyor ve detached olmazsa iki defa modified oluğ hata verir.
            if (IsProductExisted == null)
            {
                return Response<NoDataDto>.Fail("Id not found",404, true);
            }
            var updateEntity = ObjectMapper.Mapper.Map<TEntity>(tDto);
            _genericRepositoy.Update(updateEntity);
            await _unitOfWork.CommitAsync();
            return Response<NoDataDto>.Success(204);
        }

        public async Task<Response<IEnumerable<TDTO>>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            var list = _genericRepositoy.Where(predicate);
            return Response<IEnumerable<TDTO>>.Success(ObjectMapper.Mapper.Map<IEnumerable<TDTO>>(await list.ToListAsync()), 200);
        }
    }
}
