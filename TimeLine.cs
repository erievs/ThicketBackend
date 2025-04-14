using System.Text.Json;

using Newtonsoft.Json;

namespace ShittyVineRI {

    public static class TimeLine {

        public static void TimeLineGraph (WebApplication app) {

            app.MapGet("/timelines/graph", async (HttpRequest request, HttpContext context, ShittyVineRIDb db) => {

                    Console.WriteLine("test");

                    var json = new VineTimeLine {

                        Code = "",
                        Success = true,
                        Error = ""

                    };

                    Console.WriteLine(json);

                    if(request.Headers.UserAgent.ToString().StartsWith("iphone")) {

                        Console.WriteLine("It seems like you're using an iPhone, this is simply just for debugging purposes");

                    }

                    context.Response.ContentType = "application/json"; 


                    return json;


            });
             

        }


    }

}