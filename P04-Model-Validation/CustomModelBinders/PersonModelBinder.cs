using Microsoft.AspNetCore.Mvc.ModelBinding;
using P04_Model_Validation.Models;

namespace P04_Model_Validation.CustomModelBinders;

public class PersonModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        Person person = new Person();
        // FirstName and LastName
        if (bindingContext.ValueProvider.GetValue("FirstName").Any())
        {
            person.PersonName = bindingContext.ValueProvider.GetValue("FirstName").FirstValue;
            if (bindingContext.ValueProvider.GetValue("LastName").Any())
            {
                person.PersonName += " " + bindingContext.ValueProvider.GetValue("LastName");
            }
        }

        bindingContext.Result = ModelBindingResult.Success(person);
        return Task.CompletedTask;
    }
}