using Rentaly.DtoLayer.CarDtos;

namespace Rentaly.BusinessLayer.Abstract
{
    public interface ICarService
    {
        Task<List<ResultCarDto>> TGetListAsync();
        Task<GetCarByIdDto?> TGetByIdAsync(int id);
        Task TInsertAsync(CreateCarDto dto);
        Task TUpdateAsync(UpdateCarDto dto);
        Task TDeleteAsync(int id);
    }
}
