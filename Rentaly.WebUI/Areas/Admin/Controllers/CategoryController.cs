using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rentaly.BusinessLayer.Abstract;
using Rentaly.BusinessLayer.Exceptions;
using Rentaly.DtoLayer.CategoryDtos;

namespace Rentaly.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _categoryService.TGetListAsync();

            return View(values);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto dto)
        {
            try
            {
                await _categoryService.TInsertAsync(dto);
                TempData["Success"] = "Kategori başarıyla eklendi.";
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

            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                await _categoryService.TDeleteAsync(id);
                TempData["Success"] = "Kategori başarıyla silindi.";
            }
            catch (BusinessRuleException ex)
            {
                TempData["Error"] = ex.Message;
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var value = await _categoryService.TGetByIdAsync(id);

            if (value is null)
                return NotFound();

            var dto = _mapper.Map<UpdateCategoryDto>(value);

            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto dto)
        {
            try
            {
                await _categoryService.TUpdateAsync(dto);
                TempData["Success"] = "Kategori başarıyla güncellendi.";
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

            return View(dto);
        }
    }
}
