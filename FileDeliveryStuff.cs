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
 

    }

}