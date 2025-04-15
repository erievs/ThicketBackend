namespace ShittyVineRI {

    public static class UserStuff {

        public static void HandleMe(WebApplication app) {

         
         app.MapGet("/users/me", 
            async (HttpRequest request, HttpContext context, ShittyVineRIDb db) =>
            {


                var jsonResponse = new AccountMe {
                    Code = "",
                    Data = new AccountMeData {
                        Username = "Yap",
                        ProfileBackground = "0x33ccbf",
                        Following = 1,
                        FollowerCount = 1,
                        Verified = 0,
                        Description = "Yap",
                        AvatarUrl = "https://alternative.me/media/256/vine-icon-4f4dc40kvhmrw38x-c.png",
                        TwitterId = null,
                        UserId = 1,
                        TwitterConnected = 0,
                        LikeCount = 0,
                        FacebookConnected = 0,
                        PostCount = 0,
                        PhoneNumber = null,
                        Location = "Paris, France",
                        FollowingCount = 0,
                        Email = "test@gmail.com",
                        VerifiedEmail = 1,
                        LoopCount = 1
                        
                    },
                    Success = true,
                    Error = ""
                };

                context.Response.ContentType = "application/json"; 
 
                return jsonResponse;
                
            });


        }

    }

}