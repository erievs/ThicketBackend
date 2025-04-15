namespace ShittyVineRI {

    public static class UploadHandler {


        public static void HandleVineUploads(WebApplication app) {

            // The API that handles the video uploading part of the upload proccess
            app.MapPut("/upload/videos/{file}",
            async (HttpRequest request, HttpContext context) =>
            {

                    // without this the video file will be unplayable
                    context.Request.EnableBuffering(); 

                    var appDataPath = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                        "ShittyVineRI"
                    );

                    Directory.CreateDirectory(appDataPath);

                    var requestContent = request.BodyReader;

                    var videoFileName = $"vine_{Utils.GenerateAlphaNumeroic(12)}.mp4";


                    using (var whyDoWeExistJustToSuffer = File.OpenWrite(Path.Combine(appDataPath, $"{videoFileName}"))) {

                        Console.WriteLine(whyDoWeExistJustToSuffer.Name);

                        var videoCDNPath = $"http://{context.Request.Host}/cdn/video/{videoFileName}";                

                        Console.WriteLine("Uploaded Video CDN " + videoCDNPath);

                        // a custom bufferSize is needed or again the file will be unplayable, around 300_000 seems to be the miniuim but I just do 512kb for saftey
                        await request.Body.CopyToAsync(whyDoWeExistJustToSuffer, 512_000);
                        
                        context.Request.ContentType = "application/json"; 
                        context.Response.Headers["X-Upload-Key"] = videoCDNPath;

                    }

                return Results.Ok();
            });

        }

        public static void HandleThumbnailUploads(WebApplication app) {

            // The API that handles the thumbnail uploading part of the upload proccess, this is the pennulimtate stage
            app.MapPut("/upload/thumbs/{file}",
            async (HttpRequest request, HttpContext context) =>
            {

                    // without this the thumbnail file will be unplayable
                    context.Request.EnableBuffering(); 

                    var appDataPath = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                        "ShittyVineRI"
                    );

                    Directory.CreateDirectory(appDataPath);

                    var requestContent = request.BodyReader;

                    var thumbNailFileName = $"thumbnail_{Utils.GenerateAlphaNumeroic(12)}.jpg";

                    using (var whyDoWeExistJustToSuffer = File.OpenWrite(Path.Combine(appDataPath, $"{thumbNailFileName}"))) {
                
                    Console.WriteLine(whyDoWeExistJustToSuffer.Name);

                    var thumbnailCDNPath = $"http://{context.Request.Host}/cdn/thumbnail/{thumbNailFileName}";                

                    Console.WriteLine("Uploaded Audio CDN " + thumbnailCDNPath);

                    // a custom bufferSize is needed or again the file will be useable, around 300_000 seems to be the miniuim but I just do 512kb for saftey
                    await request.Body.CopyToAsync(whyDoWeExistJustToSuffer, 512_000);


                    context.Request.ContentType = "application/json"; 
                    context.Response.Headers["X-Upload-Key"] = thumbnailCDNPath;


                    }

                return Results.Ok();
            });

        }

        public static void HandlePostingVideos(WebApplication app) {

            // The API that handles the thumbnail uploading part of the upload proccess, this is the pennulimtate stage
            app.MapPost("/posts",
            async (Vine vine, HttpRequest request, HttpContext context, ShittyVineRIDb db) =>
            {



                var vineToMake = new Vine {
                    VideoUrl = vine.VideoUrl,
                    ThumbnailUrl = vine.ThumbnailUrl,
                    Description = vine.Description,
                    Username = "Placeholder",
                    Date = DateTime.UtcNow
                };

                Console.WriteLine("Vine someone just vine " + Newtonsoft.Json.JsonConvert.SerializeObject(vineToMake));


                await db.Vines.AddAsync(vineToMake);
                await db.SaveChangesAsync(); // opps forgot to do thus
   
                Console.WriteLine("Vine someone just vine " + Newtonsoft.Json.JsonConvert.SerializeObject(vineToMake));

                var jsonResponse = new UploadOutput {

                    Code = "",
                    Data = new EmptyData(),
                    Success = true,
                    Error = ""
                };
                  

                return jsonResponse;

            });

        }


    }

}