
using System.Runtime.InteropServices.JavaScript;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        public class ErrorOutput
    {
        public String? Code { get; set; }
        public EmptyData? Data { get; set; }
        public Boolean? Success { get; set; }
        public String? Error { get; set; }
    }

    public class AccountData
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
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

        public String? Username { get; set; }

        public DateTime? Date { get; set; }

    }

    public class VineTimeLine {

        public String? Code { get; set; }
        public VineTimeLineData? Data { get; set; }
        public Boolean? Success { get; set; }
        public String? Error { get; set; }

    }

    public class VineTimeLineData {

        public int? Count { get; set; }
        public List<VineTimeLineRecord>? Records { get; set; }
        public Int32? NextPage { get; set; }
        public Int32? PreviousPage { get; set; }
        public int? Size { get; set; }

    }

    public class VineTimeLineRecord {

        public Int32? Liked { get; set; }
        public String? Username { get; set; }
        public String? VideoDashUrl  { get; set; }
        public String? VideoWebmUrl  { get; set; }
        public String? VideoLowUrl { get; set; }
        public List<VideoEntry>? VideoUrls { get; set; }
        public Int32? PostToTwitter { get; set; }
        public String? VideoUrl { get; set; }
        public String? Description { get; set; }
        public DateTime? Created { get; set; }
        public String? AvatarUrl { get; set; }
        public Int32? UserId { get; set; }
        public String? ThumbnailUrl { get; set; }
        public Int32? FoursquareVenueId { get; set; }
        public Int32? PostToFacebook { get; set; }
        public Int32? Promoted { get; set; }
        public Int32? Verified { get; set; }
        public Int32? PostId { get; set; }
        public Int32? ExplicitContent { get; set; }
        public List<Tags>? Tags { get; set; }
        public String? Location { get; set; }
    }


    public class VideoEntry
    {
        public String? VideoUrl { get; set; }
        public String? Format { get; set; }
        public Int32? Default { get; set; }
        public String? IdStr { get; set; }
        public Int32? Rate { get; set; }
        public String? Id { get; set; }
    }

    public class Tags
    {

    }

    public class AccountMe
    {
        public String? Code { get; set; }
        public AccountMeData? Data { get; set; }
        public Boolean? Success { get; set; }
        public String? Error { get; set; }
    }

    public class AccountMeData
    {
        public String? Username { get; set; }
        public String? ProfileBackground { get; set; }
        public Int32? Following { get; set; }
        public Int32? FollowerCount { get; set; }
        public Int32? Verified { get; set; }
        public String? AvatarUrl { get; set; }
        public String? Description { get; set; }
        public Int32? TwitterId { get; set; }
        public Int32? UserId { get; set; }
        public Int32? TwitterConnected { get; set; }
        public Int32? LikeCount { get; set; }
        public Int32? FacebookConnected { get; set; }
        public Int32? PostCount { get; set; }
        public Int32? PhoneNumber { get; set; }
        public String? Location { get; set; }
        public Int32? FollowingCount { get; set; }
        public String? Email { get; set; }
        public Int32? VerifiedEmail { get; set; }
        public Int32? LoopCount { get; set; }
    }

    


}