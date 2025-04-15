
using System.Data.Common;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ShittyVineRI {

    public static class TimeLine {
  

        public static void TimeLineGraph (WebApplication app) {

            app.MapGet("/timelines/graph", async (HttpRequest request, HttpContext context, ShittyVineRIDb db) => {

                    Console.WriteLine("test");

                    var allVines = new List<VineTimeLineRecord>();
        

                    foreach(Vine vine in db.Vines) {

                        
                        
                        var addToVineList = new VineTimeLineRecord {
                            Liked = 0,
                            Username = vine.Username ?? "Placeholder",
                            VideoDashUrl = vine.VideoUrl,
                            VideoWebmUrl = null,
                            VideoLowUrl = vine.VideoUrl,
                            VideoUrls = new List<VideoEntry> {
                                new VideoEntry {
                                    VideoUrl = vine.VideoUrl,
                                    Format = "h264",
                                    Default = 1,
                                    IdStr = "original",
                                    Rate = 200,
                                    Id = "original"
                                }
                            },
                            PostToTwitter = 0,
                            VideoUrl = vine.VideoUrl,
                            Description = vine.Description ?? "Nothing",
                            Created = vine.Date ?? DateTime.UtcNow,
                            AvatarUrl = null,
                            UserId = 331,
                            ThumbnailUrl = vine.ThumbnailUrl,
                            FoursquareVenueId = 211,
                            PostToFacebook = 0,
                            Promoted = 0,
                            Verified = 0,
                            PostId = 3313,
                            ExplicitContent = 0,
                            Tags = [],
                            Location = "Paris, France"
              
                        };

                        allVines.Add(addToVineList);

                    }


                    var json = new VineTimeLine {

                        Code = "",
                        Data = new VineTimeLineData {
                            Count = allVines.Count,
                            NextPage = null,
                            PreviousPage = null,
                            Records = allVines,
                            Size = 250
                        },
                        Success = true,
                        Error = ""

                    };
                    

                    Console.WriteLine(allVines);

                    if(request.Headers.UserAgent.ToString().StartsWith("iphone")) {

                        Console.WriteLine("It seems like you're using an iPhone, this is simply just for debugging purposes");

                    }

                    context.Response.ContentType = "application/json"; 


                    return json;
    

            });
             

        }


    }

}