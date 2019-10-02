using GraphQL.Types;

namespace api.GraphQL.InputTypes
{
    public class FilmeInputType : InputObjectGraphType
    {
        public FilmeInputType()
        {
            Field<NonNullGraphType<StringGraphType>>("nome");
            Field<NonNullGraphType<StringGraphType>>("sinopse");
            Field<NonNullGraphType<IntGraphType>>("ano");
            
            Field<ListGraphType<AtorInputType>>("atores");
        }
    }
}