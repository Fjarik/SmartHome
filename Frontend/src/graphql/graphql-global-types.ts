/* tslint:disable */
/* eslint-disable */
// @generated
// This file was automatically generated and should not be edited.

//==============================================================
// START Enums and Input Objects
//==============================================================

/**
 * Food enum types
 */
export enum FoodTypeEnum {
  DESERT = "DESERT",
  MAIN_MEAL = "MAIN_MEAL",
  SIDE_DISH = "SIDE_DISH",
  SOUP = "SOUP",
}

/**
 * Meal time enum
 */
export enum MealTimeEnum {
  BREAKFAST = "BREAKFAST",
  DINNER = "DINNER",
  LUNCH = "LUNCH",
}

/**
 * Meal enum types
 */
export enum MealTypeEnum {
  FOOD_BOX = "FOOD_BOX",
  GRANDMA = "GRANDMA",
  NORMAL = "NORMAL",
  OTHER = "OTHER",
  RESTAURANT = "RESTAURANT",
}

export interface FoodInput {
  name: string;
  type: FoodTypeEnum;
  categoryIds?: string[] | null;
  sideIds?: string[] | null;
  glutenFree?: boolean | null;
}

//==============================================================
// END Enums and Input Objects
//==============================================================
