﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public partial class Category
    {
        public Category()
        {
            FoodCategories = new HashSet<FoodCategory>();
            MealCategories = new HashSet<MealCategory>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        public bool? IsHealthy { get; set; }

        [InverseProperty(nameof(FoodCategory.Category))]
        public virtual ICollection<FoodCategory> FoodCategories { get; set; }
        [InverseProperty(nameof(MealCategory.Category))]
        public virtual ICollection<MealCategory> MealCategories { get; set; }
    }
}