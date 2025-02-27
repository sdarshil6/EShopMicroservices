﻿using Carter;
using Mapster;
using MediatR;
using Ordering.Application.Dtos;
using Ordering.Application.Queries.GetOrdersByCustomer;

namespace Ordering.API.Endpoints
{
    public class GetOrdersByCustomer : ICarterModule
    {
        //public record GetOrdersByCustomerRequest(Guid CustomerId);
        public record GetOrdersByCustomerResponse(IEnumerable<OrderDto> Orders);
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/orders/customer/{customerId}", async (Guid customerId, ISender sender) =>
            {
                var result = await sender.Send(new GetOrdersByCustomerQuery(customerId));

                var response = result.Adapt<GetOrdersByCustomerResponse>();

                return Results.Ok(response);
            })
         .WithName("GetOrdersByCustomer")
         .Produces<GetOrdersByCustomerResponse>(StatusCodes.Status200OK)
         .ProducesProblem(StatusCodes.Status400BadRequest)
         .ProducesProblem(StatusCodes.Status404NotFound)
         .WithSummary("Get Orders By Customer")
         .WithDescription("Get Orders By Customer");
        }
    }
}
