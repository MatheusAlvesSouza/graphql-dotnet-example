using api.Models;
using GraphQL.Types;

namespace api.GraphQL.Types
{
    public class FilmeType : ObjectGraphType<Filme>
    {
        public FilmeType()
        {
            Field(a => a.Nome).Description("Nome do filme");
            Field(a => a.Sinopse).Description("Descricao do filme");
            Field(a => a.Ano).Description("Ano do filme");

            Field<ListGraphType<AtorType>>("atores", resolve: context => context.Source.Atores);
        }
    }
}