using System.Linq;
using GraphChocolate.Data;
using GraphChocolate.Models;
using HotChocolate;
using HotChocolate.Data;

namespace GraphChocolate
{
    public class Query
    {
        [UseDbContext(typeof(PizzaContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Pizza> GetPizzas([ScopedService] PizzaContext context)
            => context.Pizzas;
    }
}
