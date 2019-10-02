using api.Data;
using api.Models;
using GraphQL.Types;
using api.GraphQL.Types;
using api.GraphQL.InputTypes;

namespace api.GraphQL
{
    class ApiMutation : ObjectGraphType
    {
        public ApiMutation(DataContext DataContext)
        {
            // Arguments são argumentos que queremos receber na requisição
            Field<FilmeType>("addFilme", arguments: new QueryArguments()
            {
                // QueryArgument é o argumento em si, poderia ter quantos eu quisesse
                new QueryArgument<FilmeInputType>{ Name = "filme" }
            },
            resolve : GraphQLContext => {
                // Em toda resolve recebemos um ResolveFieldContext da GraphQL
                // Usando o metodo GetArgument podemos pegar um argumento e dizer seu <type> para ele já ser parseado
                Filme filme = GraphQLContext.GetArgument<Filme>("filme");
                // Insere no nosso contexto
                DataContext.AddFilme(filme);

                return filme;
            });
        }
    }
}