using System.Threading.Tasks;
using category.Model;
using category;

namespace category.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<Category> AddCategory(CategoryModel category);
        public Task<Category> GetCategory(int id);

        public Task<Category> DeleteCategory(int id);

        public Task<Category> ModifyCategory(ModifyCategoryModel categoryModel);
    }
}