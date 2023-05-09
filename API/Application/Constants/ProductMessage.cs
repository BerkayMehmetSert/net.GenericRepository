namespace API.Application.Constants
{
    public static class ProductMessage
    {
        public const string NameRequired = "Product name is required.";
        public const string NameMaxLength = "Product name cannot be longer than 100 characters.";
        public const string DescriptionRequired = "Product description is required.";
        public const string DescriptionMaxLength = "Product description cannot be longer than 255 characters.";
        public const string PriceRequired = "Product price is required.";
        public const string PriceGreaterThanZero = "Product price must be greater than 0.";

        public const string ProductNotFound = "Product not found.";
        public const string ProductAlreadyExists = "Product already exists.";
        public const string ProductListEmpty = "Product list is empty.";
    }
}
