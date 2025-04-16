namespace ShittyVineRI {

    public static class MiscellaneousStuff {

        public static void HandleJOT (WebApplication app) {
            app.MapGet("/jot", 
         
            async (HttpRequest request, HttpContext context, ShittyVineRIDb db) =>
            {


                var jsonResponse = new ErrorOutput {

                    Code = "",
                    Data = new EmptyData{},
                    Success = true,
                    Error = "" 

                };
        
                return jsonResponse;
                
            });

        }

        public static void HandleClientFlags (WebApplication app) {
            app.MapGet("/users/me", 
         
            async (HttpRequest request, HttpContext context, ShittyVineRIDb db) =>
            {


                var jsonResponse = new ClietFlags {

                    Code = "",
                    Data = new ClietFlagsData{
                        GuestID = Utils.CreateKey(),
                        ScribeEnabled = 1,
                        SectionedSearch = 1,
                        WideFoVEnabled = 1
                    },
                    Success = true,
                    Error = "" 

                };
        
                return jsonResponse;
                
            });

        }

    }

}