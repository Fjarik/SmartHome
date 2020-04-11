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
  name: string;
}

export interface getFoods_foods {
  __typename: "FoodType";
  /**
   * Name of food
   */
  name: string;
  /**
   * Type of food
   */
  type: FoodTypeEnum;
  /**
   * Category IDs of food
   */
  categoryIds: number[] | null;
  /**
   * Categories of food
   */
  categories: getFoods_foods_categories[] | null;
}

export interface getFoods {
  foods: (getFoods_foods | null)[] | null;
}
