using GraphQL.Types;

namespace api.GraphQL.InputTypes
{
    public class AtorInputType : InputObjectGraphType
    {
        public AtorInputType()
        {
            Field<NonNullGraphType<StringGraphType>>("nome");
            Field<NonNullGraphType<IntGraphType>>("idade");
        }
    }
}