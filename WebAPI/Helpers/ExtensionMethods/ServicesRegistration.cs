using Core.Interfaces.Repository;
using Persistence.Data.Repositories;
using Services.Interfaces.Services;
using Services.Services;

namespace WebAPI.Helpers.ExtensionMethods
{
    public static class ServicesRegistration
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<IConcertRepository, ConcertRepository>();
            services.AddScoped<ITicketInShoppingCartRepository, TicketInShoppingCartRepository>();
            services.AddScoped<ITicketInOrderRepository, TicketInOrderRepository>();
            services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
            services.AddScoped<IOrderReposiroty, OrderRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<IConcertService, ConcertService>();
            services.AddScoped<IShoppingCartService, ShoppingCartService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ITicketInShoppingCartService, TicketInShoppingCartService>();
            services.AddScoped<ITicketInOrderService, TicketInOrderService>();
            services.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(type => type.FullName); // Use the full type name as the schema ID
            });
        }
    }
}
