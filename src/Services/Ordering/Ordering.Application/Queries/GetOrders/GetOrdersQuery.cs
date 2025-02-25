using BuildingBlocks.CQRS;
using Microsoft.EntityFrameworkCore;
using Ordering.Application.Data;
using Ordering.Application.Dtos;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Ordering.Application.Queries.GetOrders
{
    public class GetOrdersQuery(PaginationRequest PaginationRequest)
    : IQuery<GetOrdersResult>;
    public record GetOrdersResult(PaginatedResult<OrderDto> Orders);
}
