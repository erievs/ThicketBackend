namespace ShittyVineRI {

    public static class FileDeliveryStuff {


        public static void VideoDeliveryService(WebApplication app) {
            
            app.MapGet("/cdn/video/{file_name}", (string file_name) =>  
            {  
            
                var appDataPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "ShittyVineRI"
                );

                
                string filePath = Path.Combine(appDataPath, $"{file_name}");

                return Results.Stream(new FileStream(filePath, FileMode.Open));  
            });


        }

        public static void ThumbnailDeliveryService(WebApplication app) {
            
            app.MapGet("/cdn/thumbnail/{file_name}", (string file_name) =>  
            {  
            
                var appDataPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "ShittyVineRI"
                );

                
                string filePath = Path.Combine(appDataPath, $"{file_name}");

                return Results.Stream(new FileStream(filePath, FileMode.Open));  
            });


        }

        public static void WebpageAssetsDeliveryService(WebApplication app) {
            
            app.MapGet("/cdn/web/{file_name}", (string file_name) =>  
            {  
            
                var appDataPath = Path.Combine(Environment.CurrentDirectory,
                    "SiteAssets"
                );

                string filePath = Path.Combine(appDataPath, $"{file_name}");

                if (file_name.EndsWith(".css")) {
                   return Results.Content(File.ReadAllText(filePath), "text/css");
                }


                return Results.Stream(new FileStream(filePath, FileMode.Open));  

            });


        }
 

    }

}