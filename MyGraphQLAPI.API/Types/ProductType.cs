// src/MyGraphQLAPI.API/GraphQL/Types/ProductType.cs
using HotChocolate.Types;
using MyGraphQLAPI.Domain.Entities;

namespace MyGraphQLAPI.API.GraphQL.Types
{
    // Defines how the Product entity is exposed in GraphQL
    public class ProductType : ObjectType<Product>
    {
        protected override void Configure(IObjectTypeDescriptor<Product> descriptor)
        {
            // Optional: Customize fields, add derived fields, ignore fields etc.
            descriptor.Field(p => p.Id).Description("The unique identifier of the product.");
            descriptor.Field(p => p.Name).Description("The name of the product.");
            descriptor.Field(p => p.Description).Description("A brief description of the product.");
            descriptor.Field(p => p.Price).Description("The price of the product.");
            descriptor.Field(p => p.Stock).Description("The current stock quantity.");

            // Example: Add a field that's not directly on the entity
            // descriptor.Field("isExpensive")
            //     .Type<BooleanType>()
            //     .Resolve(context =>
            //     {
            //         var product = context.Parent<Product>();
            //         return product.Price > 1000;
            //     });
        }
    }
}