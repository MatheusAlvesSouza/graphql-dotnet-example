using api.Data;
using GraphQL.Types;
using api.GraphQL.Types;

namespace api.GraphQL
{
    class ApiQuery : ObjectGraphType
    {  
        // Recebe o DataContext via DI (Startup.cs)
        public ApiQuery(DataContext DataContext)
        {
            // Query 'filmes' que retorna uma lista de filmes (FilmeType)
            Field<ListGraphType<FilmeType>>("filmes", 
                // No resolve ele literalmente ira resolver nossa query 'filmes' e retornar o resulta
                resolve : GraphQLContext => {
                return DataContext.GetFilmes();
            });
        }
    }
}