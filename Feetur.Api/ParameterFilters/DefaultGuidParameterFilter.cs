using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Feetur.Api.ParameterFilters;

public class DefaultGuidParameterFilter: IParameterFilter
{
    public void Apply(OpenApiParameter parameter, ParameterFilterContext context)
    {
        var type = context.ParameterInfo?.ParameterType;
        
        if(type == null)
            return;

        if (type == typeof(Guid))
            parameter.Schema.Default = new OpenApiString(Guid.Empty.ToString());
    }
}