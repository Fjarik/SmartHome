/* tslint:disable */
/* eslint-disable */
// @generated
// This file was automatically generated and should not be edited.

import { MealTypeEnum } from "./../graphql-global-types";

// ====================================================
// GraphQL query operation: getBasicMeals
// ====================================================

export interface getBasicMeals_meals_food {
  __typename: "FoodType";
  /**
   * Id property
   */
  id: string | null;
  /**
   * Name of food
   */
  name: string | null;
}

export interface getBasicMeals_meals {
  __typename: "MealType";
  /**
   * Id property
   */
  id: string | null;
  /**
   * Name of food
   */
  date: any | null;
  /**
   * Meal type
   */
  type: MealTypeEnum | null;
  /**
   * Food
   */
  food: getBasicMeals_meals_food | null;
}

export interface getBasicMeals {
  meals: (getBasicMeals_meals | null)[] | null;
}
