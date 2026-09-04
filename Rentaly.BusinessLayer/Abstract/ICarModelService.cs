using Rentaly.DtoLayer.CarModelDtos;

namespace Rentaly.BusinessLayer.Abstract
{
    public interface ICarModelService
    {
        Task<List<ResultCarModelDto>> TGetListAsync();
        Task<GetCarModelByIdDto?> TGetByIdAsync(int id);
        Task TInsertAsync(CreateCarModelDto dto);
        Task TUpdateAsync(UpdateCarModelDto dto);
        Task TDeleteAsync(int id);
    }
}