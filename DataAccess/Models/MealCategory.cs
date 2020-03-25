﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public partial class MealCategory
    {
        [Key]
        [Column("MealID")]
        public int MealId { get; set; }
        [Key]
        [Column("CategoryID")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("MealCategories")]
        public virtual Category Category { get; set; }
        [ForeignKey(nameof(MealId))]
        [InverseProperty("MealCategories")]
        public virtual Meal Meal { get; set; }
    }
}