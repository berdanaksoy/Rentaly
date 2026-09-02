using Rentaly.DtoLayer.CategoryDtos;

namespace Rentaly.BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> TGetListAsync();
        Task<GetCategoryByIdDto?> TGetByIdAsync(int id);
        Task TInsertAsync(CreateCategoryDto dto);
        Task TUpdateAsync(UpdateCategoryDto dto);
        Task TDeleteAsync(int id);
    }
}
