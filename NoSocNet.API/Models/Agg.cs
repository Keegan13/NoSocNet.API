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

    public class LoginResponseModel : IHasResultCode
    {
        public LoginResponseModel()
        {
            this.Messages = new List<string>();
        }
        public int ResultCode { get; set; }

        public List<string> Messages { get; set; }

        public Object Data { get; set; }
    }
    public class UserInfoResponse : IHasResultCode
    {
        public UserInfoResponse()
        {
            this.Messages = new List<string>();
        }

        public UserInfo Data { get; set; }

        public int ResultCode { get; set; }

        public List<string> Messages { get; set; }
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
