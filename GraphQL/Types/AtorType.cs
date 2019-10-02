using api.Models;
using GraphQL.Types;

namespace api.GraphQL.Types
{
    public class AtorType : ObjectGraphType<Ator>
    {
        public AtorType()
        {
            Field(a => a.Nome).Description("Nome do ator");
            Field(a => a.Idade).Description("Idade do ator no filme");
        }
    }
}