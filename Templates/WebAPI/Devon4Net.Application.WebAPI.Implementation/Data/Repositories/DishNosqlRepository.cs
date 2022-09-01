using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;
using Devon4Net.Application.WebAPI.Implementation.Domain.RepositoryInterfaces;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;


namespace Devon4Net.Application.WebAPI.Implementation.Data.Repositories
{
    public class DishNosqlRepository: IDishNosqlRepository
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoCollection<DishNosql> _dishNosqlCollection;

        public DishNosqlRepository()
        {
            //TODO: Add the connectionstring into appsettings.developement.json
            var settings = MongoClientSettings.FromConnectionString("mongodb://localhost:27017");
            _mongoClient = new MongoClient(settings);
            var camelCaseConvention = new ConventionPack { new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("CamelCase", camelCaseConvention, type => true);
            _dishNosqlCollection = _mongoClient.GetDatabase("my_thai_star_progress").GetCollection<DishNosql>("Dish");

        }


        public async Task<List<DishNosql>> GetAll()
        {
            var dishes = await _dishNosqlCollection
                .Find(Builders<DishNosql>.Filter.Empty)
                .ToListAsync();

            return dishes;
        }

        public async Task<DishNosql> GetDishById(string movieId, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dishNosqlCollection.Aggregate()
                    .Match(Builders<DishNosql>.Filter.Eq(x => x._id, movieId))
                    // Ticket: Get Comments
                    // Add a lookup stage that includes the
                    // comments associated with the retrieved movie
                    .FirstOrDefaultAsync(cancellationToken);
            }

            catch (Exception ex)
            {
                // TODO Ticket: Error Handling
                // Catch the exception and check the exception type and message contents.
                // Return null if the exception is due to a bad/missing Id. Otherwise,
                // throw.
                if (ex == null)
                {
                    return null;
                }
                throw;
            }
        }
    }
}
