using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace ShittyVineRI {

    public static class Utils {
        private static Random random = new Random();
        private static Guid uuidMaker = Guid.NewGuid();

        public static string GenerateAlphaNumeroic(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string CreateKey() {
            return uuidMaker.ToString();;
        }

        // some binder I found on stack overflow that works well for url encoded requsts
        // https://stackoverflow.com/questions/72579605/accept-x-www-form-urlencoded-in-minimal-api-net-6
        public static async Task<T?> BindFromForm<T>(this HttpContext httpContext)
        {
            var serviceProvider = httpContext.RequestServices;
            var factory = serviceProvider.GetRequiredService<IModelBinderFactory>();
            var metadataProvider = serviceProvider.GetRequiredService<IModelMetadataProvider>();

            var metadata = metadataProvider.GetMetadataForType(typeof(T));
            var modelBinder = factory.CreateBinder(new() {
                Metadata = metadata
            });

            var context = new DefaultModelBindingContext
            {
                ModelMetadata = metadata,
                ModelName = string.Empty,
                ValueProvider = new FormValueProvider(
                    BindingSource.Form,
                    httpContext.Request.Form,
                    CultureInfo.InvariantCulture
                ),
                ActionContext = new ActionContext(
                    httpContext, 
                    new RouteData(), 
                    new ActionDescriptor()),
                ModelState = new ModelStateDictionary()
            };
            await modelBinder.BindModelAsync(context);
            return (T?) context.Result.Model;
        }
    
        public static int UserId(int length)
        {
            return random.Next(1, 2147483647);
        }

    }
}