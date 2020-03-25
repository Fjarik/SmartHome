﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public partial class Meal
    {
        public Meal()
        {
            MealCategories = new HashSet<MealCategory>();
            MealSides = new HashSet<MealSide>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("CookedByID")]
        public int CookedById { get; set; }
        [Column("FoodID")]
        public int FoodId { get; set; }
        [Column("TypeID")]
        public int TypeId { get; set; }
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [ForeignKey(nameof(CookedById))]
        [InverseProperty(nameof(User.Meals))]
        public virtual User CookedBy { get; set; }
        [ForeignKey(nameof(FoodId))]
        [InverseProperty("Meals")]
        public virtual Food Food { get; set; }
        [ForeignKey(nameof(TypeId))]
        [InverseProperty(nameof(MealType.Meals))]
        public virtual MealType Type { get; set; }
        [InverseProperty(nameof(MealCategory.Meal))]
        public virtual ICollection<MealCategory> MealCategories { get; set; }
        [InverseProperty(nameof(MealSide.Meal))]
        public virtual ICollection<MealSide> MealSides { get; set; }
    }
}