/* tslint:disable */
/* eslint-disable */
// @generated
// This file was automatically generated and should not be edited.

import { FoodTypeEnum } from "./../graphql-global-types";

// ====================================================
// GraphQL query operation: getFoods
// ====================================================

export interface getFoods_foods_categories {
  __typename: "CategoryType";
  /**
   * Name of food category
   */
  name: string | null;
}

export interface getFoods_foods {
  __typename: "FoodType";
  /**
   * Name of food
   */
  name: string | null;
  /**
   * Type of food
   */
  type: FoodTypeEnum | null;
  /**
   * Categories of food
   */
  categoryIds: (number | null)[] | null;
  /**
   * Categories of food
   */
  categories: (getFoods_foods_categories | null)[] | null;
}

export interface getFoods {
  foods: (getFoods_foods | null)[] | null;
}
