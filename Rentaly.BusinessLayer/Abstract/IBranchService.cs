using Rentaly.DtoLayer.BranchDtos;

namespace Rentaly.BusinessLayer.Abstract
{
    public interface IBranchService
    {
        Task<List<ResultBranchDto>> TGetListAsync();
        Task<GetBranchByIdDto?> TGetByIdAsync(int id);
        Task TInsertAsync(CreateBranchDto branchDto);
        Task TUpdateAsync(UpdateBranchDto branchDto);
        Task TDeleteAsync(int id);
    }
}
