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
            RelationshipSources = new HashSet<Relationship>();
            RelationshipTargets = new HashSet<Relationship>();
            Tokens = new HashSet<Token>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        [Required]
        [Column("GoogleID")]
        [StringLength(1000)]
        public string GoogleId { get; set; }

        [InverseProperty(nameof(Meal.CookedBy))]
        public virtual ICollection<Meal> Meals { get; set; }
        [InverseProperty(nameof(Relationship.Source))]
        public virtual ICollection<Relationship> RelationshipSources { get; set; }
        [InverseProperty(nameof(Relationship.Target))]
        public virtual ICollection<Relationship> RelationshipTargets { get; set; }
        [InverseProperty(nameof(Token.User))]
        public virtual ICollection<Token> Tokens { get; set; }
    }
}