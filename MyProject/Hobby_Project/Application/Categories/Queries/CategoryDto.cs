namespace HobbyProject.Application.Categories.Queries
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Name { get; set; }
        public ICollection<HobbySubCategoryDto> HobbySubCategories { get; set; }
    }
}