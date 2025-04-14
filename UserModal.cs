
using System.Runtime.InteropServices.JavaScript;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace ShittyVineRI {
    
    // this is the data that we store and are sending to us
    public class Account
    {
        [JsonIgnore] // the id is require to be in modals, 
        // and the eaist way to have it set, without the need for having it passed in is make an id, and then ignore this property 
        // so swagger don't see it! No harm, no foul i guess.
        public int Id { get; set; } = Utils.UserId(14); 

        [JsonIgnore] 
        public string? Username { get; set; } = Utils.GenerateAlphaNumeroic(16); 
        public string? Email { get; set; }
        public string? Password { get; set; }

        // you gotta stick this whenever there's a url encoeed thingy ma bob I think this is the only one though.
        public static async ValueTask<Account?> BindAsync(HttpContext httpContext, ParameterInfo parameter)
        {
            return await httpContext.BindFromForm<Account>();
        }
        
    }

    // This is what we send as a response to the client!
    public class AccountOutput
    {
        public String? Code { get; set; }
        public AccountData? Data { get; set; }
        public Boolean? Success { get; set; }
        public String? Error { get; set; }
    }

    public class AccountData
    {
        public string? Username { get; set; }
        public string?  UserID { get; set; }
        public string?  Key { get; set; }
    }

    public class UploadOutput
    {
        public String? Code { get; set; }
        public EmptyData? Data { get; set; }
        public Boolean? Success { get; set; }
        public String? Error { get; set; }
    }

    public class EmptyData {}

    public class Vine {

        [JsonIgnore] // the id is require to be in modals, 
        // and the eaist way to have it set, without the need for having it passed in is make an id, and then ignore this property 
        // so swagger don't see it! No harm, no foul i guess.
        public int Id { get; set; } = Utils.UserId(14);

        public String? VideoUrl { get; set; }

        public String? ThumbnailUrl { get; set; }

        public String? Description { get; set; }

    }

    public class VineTimeLine {

        public String? Code { get; set; }
        public VineTimeLineData? Data { get; set; }
        public Boolean? Success { get; set; }
        public String? Error { get; set; }

    }

    public class VineTimeLineData {

        public String? Count { get; set; }
        public Array? Records { get; set; }
        public int? NextPage { get; set; }
        public int? PreviousPage { get; set; }
        public int? Size { get; set; }

    }
    
    


}