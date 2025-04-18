namespace ShittyVineRI {

    public static class AccountStuff {

        public static void Registration(WebApplication app) {

            app.MapPost("/users", 
            async (Account user, ShittyVineRIDb db) =>
            {

                // we use realUser since we need to keep the Id to make EntityFrameworkCore happy in the modal

                // however we dont want to pass in the 

                var realUser = new Account {
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email,
                    Password = user.Password
                };

                await db.Accounts.AddAsync(realUser);
                await db.SaveChangesAsync(); // opps forogt to do this lol
   
   
                Console.WriteLine("Response For Accounts " + Newtonsoft.Json.JsonConvert.SerializeObject(realUser));

                var jsonResponse = new AccountOutput {
                    Code = "",
                    Data = new AccountData {
                        Username = realUser.Username,
                        UserID = user.Id.ToString(),
                        Key =  Utils.CreateKey(), // we use the Username since I do not feel like dealing with proper sessions right now
                    },
                    Success = true,
                    Error = ""
                };

                return jsonResponse;
                
            });
        }

        public static void SignIn(WebApplication app) {

            app.MapPost("/users/authenticate", 
            async (HttpRequest request, HttpContext context, Account user, ShittyVineRIDb db) =>
            {
                 Console.WriteLine("Accounts " + Newtonsoft.Json.JsonConvert.SerializeObject(user));
                

                var jsonResponse = new AccountOutput {
                    Code = "",
                    Data = new AccountData {
                        Username = "",
                        UserID = "",
                        Key =  Utils.CreateKey(), // we use the Username since I do not feel like dealing with proper sessions right now
                    },
                    Success = true,
                    Error = ""
                };

                if(await db.Accounts.FindAsync(user.Id) is Account account) {
                    

                    jsonResponse = new AccountOutput {
                        Code = "",
                        Data = new AccountData {
                            Username = account.Username,
                            UserID = account.Id.ToString(),
                            Key =  Utils.CreateKey(), // we use the Username since I do not feel like dealing with proper sessions right now
                        },
                        Success = true,
                        Error = ""
                    };
                    
                    context.Response.ContentType = "application/json"; 

                } 
 
                return jsonResponse;

                
            });

        }

    }

}