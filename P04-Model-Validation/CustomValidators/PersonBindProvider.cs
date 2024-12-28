using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using P04_Model_Validation.CustomModelBinders;
using P04_Model_Validation.Models;

namespace P04_Model_Validation.CustomValidators;

public class PersonBindProvider : IModelBinderProvider
{
    public IModelBinder? GetBinder(ModelBinderProviderContext context)
    {
        if (context.Metadata.ModelType == typeof(Person))
        {
            return new BinderTypeModelBinder(typeof(PersonModelBinder));
        }

        return null;
    }
}