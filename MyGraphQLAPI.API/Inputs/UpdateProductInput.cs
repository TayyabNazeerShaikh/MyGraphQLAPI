// src/MyGraphQLAPI.API/GraphQL/Inputs/UpdateProductInput.cs

using HotChocolate;

namespace MyGraphQLAPI.API.GraphQL.Inputs
{
    // Input type for the UpdateProduct mutation
    public class UpdateProductInput : AddProductInput // Inherit for common fields
    {
        [GraphQLNonNullType]
        public int Id { get; set; }
    }
}