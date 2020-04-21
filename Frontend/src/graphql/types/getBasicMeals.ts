/* tslint:disable */
/* eslint-disable */
// @generated
// This file was automatically generated and should not be edited.

import { MealTypeEnum, MealTimeEnum } from "./../graphql-global-types";

// ====================================================
// GraphQL query operation: getBasicMeals
// ====================================================

export interface getBasicMeals_meals_food {
  __typename: "FoodType";
  /**
   * Id property
   */
  id: string;
  /**
   * Name of food
   */
  name: string;
}

export interface getBasicMeals_meals_soup {
  __typename: "FoodType";
  /**
   * Id property
   */
  id: string;
  /**
   * Name of food
   */
  name: string;
}

export interface getBasicMeals_meals {
  __typename: "MealType";
  /**
   * Id property
   */
  id: string;
  /**
   * Name of food
   */
  date: any;
  /**
   * Meal type
   */
  type: MealTypeEnum;
  /**
   * Meal time
   */
  time: MealTimeEnum;
  /**
   * Can be removed
   */
  isRemoveable: boolean;
  /**
   * Food
   */
  food: getBasicMeals_meals_food | null;
  /**
   * Soup
   */
  soup: getBasicMeals_meals_soup | null;
}

export interface getBasicMeals {
  meals: getBasicMeals_meals[] | null;
}
