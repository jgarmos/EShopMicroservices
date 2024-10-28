
using Catalog.API.Models;

namespace Catalog.API.Products.GetProductById;

public record GetgProductByIdQuery(Guid id) : IQuery<GetProductByIdResult>;

public record GetProductByIdResult(Product product);

internal class GetProductByIdQueryHandler
    (IDocumentSession session, ILogger<GetProductByIdQueryHandler> logger)
    : IQueryHandler<GetgProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {

        logger.LogInformation("GetProductByIdQueryHanlder. Hnadle called with {@query}", query);

        var product = await session.LoadAsync<Product>(query.Id, cancellationToken);

        if (prodcut is null)
        {
            throw new ProductNotFoundException();
        }

        return new GetProductByIdResult(product);

    }

}

