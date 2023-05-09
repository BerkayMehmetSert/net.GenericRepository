namespace API.Application.Constants
{
    public static class CategoryMessage
    {
        public const string NameRequired = "Category name is required.";
        public const string NameMaxLength = "Category name cannot be longer than 100 characters.";
        public const string DescriptionRequired = "Category description is required.";
        public const string DescriptionMaxLength = "Category description cannot be longer than 255 characters.";

        public const string CategoryNotFound = "Category not found.";
        public const string CategoryAlreadyExists = "Category already exists.";
        public const string CategoryListEmpty = "Category list is empty.";
    }
}
