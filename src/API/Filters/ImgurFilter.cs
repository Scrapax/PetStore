using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using PetStore.Attributes;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace PetStore.Filters
{
    public class ImgurFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            var attr = context.MemberInfo?.GetCustomAttribute<ImageUrlAttribute>();
            if(attr != null)
                schema.Example = new OpenApiString("https://i.imgur.com/OPWL5L9.jpeg");
        }
    }
}