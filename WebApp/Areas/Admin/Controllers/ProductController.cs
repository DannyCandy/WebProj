using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Models;
using WebApp.Repositories;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly ISanPhamRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(ISanPhamRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        // Hiển thị danh sách sản phẩm
        public async Task<IActionResult> Index()
        {
            var productList = await _productRepository.GetAllAsync();
            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Idcategory", "NameCategory");
            return View(productList);
        }

        // Hiển thị form thêm sản phẩm mới
        
        public async Task<IActionResult> AddAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Idcategory", "NameCategory");
            return View();
        }

        // Xử lý thêm sản phẩm mới
       
        [HttpPost]
        public async Task<IActionResult> Add(SanPham product, IFormFile HinhAnhSp)
        {
            product.Idsp = Guid.NewGuid().ToString();
            ModelState.Remove("Idsp");
            if (ModelState.IsValid)
            {
                if (HinhAnhSp is not null)
                {
                    // Lưu hình ảnh sản phẩm
                    product.HinhAnhSp = await SaveImage(HinhAnhSp);
                }
                await _productRepository.AddAsync(product);
                return RedirectToAction(nameof(Index));
            }
            // Nếu ModelState không hợp lệ, hiển thị form với dữ liệu đã nhập
            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Idcategory", "NameCategory");
            return View(product);
        }
        //Xử lý lưu đường dẫn hình ảnh
        private async Task<string> SaveImage(IFormFile image)
        {
            var savePath = Path.Combine("wwwroot/images/ProductImg", image.FileName); // Thay đổi đường dẫn theo cấu hình của bạn
            using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            return "/images/ProductImg/" + image.FileName; // Trả về đường dẫn tương đối
        }

        public async Task<IActionResult> Action()
        {
            var products = await _productRepository.GetAllAsync();
            if (products.Any())
            {
                return View(products);
            }
            return RedirectToAction("Page");
        }


        // Hiển thị thông tin chi tiết sản phẩm
        public async Task<IActionResult> Display(string id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product is null)
            {
                return NotFound();
            }
            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Idcategory", "NameCategory");
            return View(product);
        }

        // Hiển thị form cập nhật sản phẩm
        
        public async Task<IActionResult> Update(string id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product is null)
            {
                return NotFound();
            }

            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Idcategory", "NameCategory", product.Idcategory);
            return View(product);
        }

        // Xử lý cập nhật sản phẩm
        
        [HttpPost]
        public async Task<IActionResult> Update(string id, SanPham product, IFormFile image)
        {
            if (id != product.Idsp)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                if (image is not null)
                {
                    // Lưu hình ảnh sản phẩm
                    product.HinhAnhSp = await SaveImage(image);
                }
                await _productRepository.UpdateAsync(product);
                return RedirectToAction(nameof(Index));
            }
            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Idcategory", "NameCategory");
            return View(product);
        }

        // Hiển thị form xác nhận xóa sản phẩm
        
        public async Task<IActionResult> Delete(string id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product is null)
            {
                return NotFound();
            }
            //Lọc ra category ứng với sán phẩm
            var categories = await _categoryRepository.GetAllAsync();
            var selectedCategory = categories.FirstOrDefault(c => c.Idcategory == product.Idcategory);
            ViewBag.CategoryName = selectedCategory?.NameCategory;
            return View(product);
        }

        // Xử lý xóa sản phẩm
        
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _productRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Page()
        {
            return View();
        }
    }
}
