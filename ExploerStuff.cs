
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ShittyVineRI {

    public static class ExploerStuff {

        public static void HandleExploreV2(WebApplication app) {

      
            app.MapGet("/explore/v2", 
            async (HttpRequest request, HttpContext context, ShittyVineRIDb db) =>
            {
                
                var videoCDNPath = $"http://{context.Request.Host}/cdn/web";        

                return Results.Content(HTMLModal.ExploreV2(videoCDNPath), "text/html");
                                
            });


        }

    }

}