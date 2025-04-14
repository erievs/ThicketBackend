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
                        Key =  realUser.Username, // we use the Username since I do not feel like dealing with proper sessions right now
                    },
                    Success = true,
                    Error = ""
                };

                return jsonResponse;
                
            });
        }

        public static void SignIn(WebApplication app) {

            app.MapPost("/users/authenticate", 
            async (Account user, ShittyVineRIDb db) =>
            {
                
                if(await db.Accounts.FindAsync(user.Email) is Account account) {
                    

                    var jsonResponse = new AccountOutput {
                        Code = "",
                        Data = new AccountData {
                            Username = account.Username,
                            UserID = user.Id.ToString(),
                            Key =  account.Username, // we use the Username since I do not feel like dealing with proper sessions right now
                        },
                        Success = false,
                        Error = ""
                    };
                    
 
                    Console.WriteLine("Response For Accounts " + Newtonsoft.Json.JsonConvert.SerializeObject(jsonResponse));

                    Results.Ok(jsonResponse);


                } else {
                    Results.Unauthorized();
                }
 

                
            });

        }

    }

}