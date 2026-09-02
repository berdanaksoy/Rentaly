using Rentaly.DtoLayer.BrandDtos;

namespace Rentaly.BusinessLayer.Abstract
{
    public interface IBrandService
    {
        Task<List<ResultBrandDto>> TGetListAsync();
        Task<GetBrandByIdDto?> TGetByIdAsync(int id);
        Task TInsertAsync(CreateBrandDto dto);
        Task TUpdateAsync(UpdateBrandDto dto);
        Task TDeleteAsync(int id);
    }
}