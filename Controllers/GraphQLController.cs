using GraphQL;
using api.Data;
using api.GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class GraphQLController : Controller
    {
        DataContext _dataContext;
        public GraphQLController(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        [HttpPost]
        // [FromBody] GraphQLQuery query vai transformar toda request no objeto da graphql
        public async Task<ObjectResult> Post([FromBody] GraphQLQuery graphQLQuery)
        {
            ExecutionResult result = await new DocumentExecuter()
                .ExecuteAsync(op =>
                {
                    // Seta o nosso Schema que é composto por nossas Queries e Mutations
                    op.Schema = new Schema(){ Query = new ApiQuery(_dataContext), Mutation = new ApiMutation(_dataContext) };
                    // Query do usuario
                    op.Query = graphQLQuery.Query;
                    // Nome da operacao
                    op.OperationName = graphQLQuery.OperationName;
                    // Seta as var do usuario (pode estar na query)
                    op.Inputs = graphQLQuery.Variables?.ToString().ToInputs(); 
                }).ConfigureAwait(false);

            string json = new DocumentWriter(indent: true).Write(result);

            return new ObjectResult(Newtonsoft.Json.Linq.JObject.Parse(json));;
        }
    }

    // Esse é o objeto padrão que qualquer request GraphQL vai ter
    public class GraphQLQuery
    {
        public string OperationName { get; set; }
        public string Query { get; set; }
        public Newtonsoft.Json.Linq.JObject Variables { get; set; }
    }
}
