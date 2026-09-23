using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rentaly.BusinessLayer.Abstract;
using Rentaly.BusinessLayer.Exceptions;
using Rentaly.DtoLayer.BranchDtos;

namespace Rentaly.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BranchController : Controller
    {
        private readonly IBranchService _branchService;
        private readonly IMapper _mapper;

        public BranchController(IBranchService branchService, IMapper mapper)
        {
            _branchService = branchService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _branchService.TGetListAsync();

            return View(values);
        }

        [HttpGet]
        public IActionResult CreateBranch()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBranch(CreateBranchDto createBranchDto)
        {
            try
            {
                await _branchService.TInsertAsync(createBranchDto);
                TempData["Success"] = "Şube başarıyla eklendi.";
                return RedirectToAction("Index");
            }
            catch (BusinessValidationException ex)
            {
                foreach (var error in ex.Errors)
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            catch (BusinessRuleException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(createBranchDto);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBranch(int id)
        {
            var value = await _branchService.TGetByIdAsync(id);

            if (value is null)
                return NotFound();

            var dto = _mapper.Map<UpdateBranchDto>(value);

            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBranch(UpdateBranchDto updateBranchDto)
        {
            try
            {
                await _branchService.TUpdateAsync(updateBranchDto);
                TempData["Success"] = "Şube başarıyla güncellendi.";
                return RedirectToAction("Index");
            }
            catch (BusinessValidationException ex)
            {
                foreach (var error in ex.Errors)
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            catch (BusinessRuleException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(updateBranchDto);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            try
            {
                await _branchService.TDeleteAsync(id);
                TempData["Success"] = "Şube başarıyla silindi.";
            }
            catch (BusinessRuleException ex)
            {
                TempData["Error"] = ex.Message;
            }

            return RedirectToAction("Index");
        }
    }
}
