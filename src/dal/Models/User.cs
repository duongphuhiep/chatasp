﻿using System;

namespace Dal.Models
{
    /// <summary>
    /// And user can make or join any conversation
    /// </summary>
    public class User
    {
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public DateTime JointDate { get; set; }
    }
}