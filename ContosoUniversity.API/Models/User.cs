using System;

namespace ContosoUniversity.API.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}