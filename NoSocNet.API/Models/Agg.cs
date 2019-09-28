using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NoSocNet.API.Models
{
    public interface IHasResultCode
    {
        int ResultCode { get; set; }
    }

    public enum ResultCode
    {
        Success,
        Error
    }

    public class UserInfo
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
    }
    public class LoginInputModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; } = false;
        public bool Captcha { get; set; }
    }

    public class LoginResponseModel : ResultResponseBase
    {
    }
    public class CaptchaUrlResponse
    {
        public string Url { get; set; }
    }

    public class ResultResponseBase : IHasResultCode
    {
        public ResultResponseBase()
        {
            this.Messages = new List<string>();
        }
        public virtual Object Data { get; set; }
        public virtual int ResultCode { get; set; }
        public virtual List<string> Messages { get; set; }
    }
    public class ProfileResponseModel : ProfilePutInputModel
    {
        public PhotoViewModel Photos { get; set; }
    }
    public class StatusResponse : ResultResponseBase
    {

    }
    public class ProfilePutResponseModel : ResultResponseBase
    {

    }
    public class UploadPhotoResponseModel : ResultResponseBase
    {
        public new PhotoViewModel Data { get; set; }
    }
    public class ProfilePutInputModel
    {
        public int UserId { get; set; }
        public bool LookingForAJob { get; set; }

        public string LookingForAJobDescription { get; set; }

        public string FullName { get; set; }

        public ContactsViewModel Contacts { get; set; }
    }

    public class ContactsViewModel
    {
        public string Github { get; set; }
        public string Vk { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }

        public string Twitter { get; set; }

        public string Website { get; set; }
        public string Youtube { get; set; }
        public string MainLink { get; set; }
    }
    public class UserInfoResponse : ResultResponseBase
    {

    }

    public class UserListInputModel
    {
        public int Page { get; set; }
        public string Term { get; set; }
        public int Count { get; set; }
    }

    public class UserList : ListViewModel<UserViewModel> { }

    public class ListViewModel<T>
    {
        public IEnumerable<T> Items { get; set; }

        public int TotalCount { get; set; }

        public string Error { get; set; }
    }

    public class UserViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Status { get; set; }
        public bool Followed { get; set; }

        public PhotoViewModel Photos { get; set; }
    }

    public class PhotoViewModel
    {
        public string Small { get; set; }
        public string Large { get; set; }
    }
}
