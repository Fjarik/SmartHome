﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public partial class User
    {
        public User()
        {
            Meals = new HashSet<Meal>();
            Tokens = new HashSet<Token>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("GoogleID")]
        [StringLength(100)]
        public string GoogleId { get; set; }
        [Required]
        [StringLength(200)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string Firstname { get; set; }
        [Required]
        [StringLength(50)]
        public string Lastname { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }

        [InverseProperty(nameof(Meal.CookedBy))]
        public virtual ICollection<Meal> Meals { get; set; }
        [InverseProperty(nameof(Token.User))]
        public virtual ICollection<Token> Tokens { get; set; }
    }
}