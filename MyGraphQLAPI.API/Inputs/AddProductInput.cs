// src/MyGraphQLAPI.API/GraphQL/Inputs/AddProductInput.cs

using HotChocolate;

namespace MyGraphQLAPI.API.GraphQL.Inputs
{
    // Input type for the AddProduct mutation
    public class AddProductInput
    {
        [GraphQLNonNullType] // Indicates the field is required in the input
        public string Name { get; set; } = default!;

        public string? Description { get; set; }

        [GraphQLNonNullType]
        public decimal Price { get; set; }

        [GraphQLNonNullType]
        public int Stock { get; set; }
    }
}