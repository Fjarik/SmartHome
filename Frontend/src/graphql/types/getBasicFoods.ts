/* tslint:disable */
/* eslint-disable */
// @generated
// This file was automatically generated and should not be edited.

import { FoodTypeEnum } from "./../graphql-global-types";

// ====================================================
// GraphQL query operation: getBasicFoods
// ====================================================

export interface getBasicFoods_foods_categories {
  __typename: "CategoryType";
  /**
   * Name of food category
   */
  name: string;
}

export interface getBasicFoods_foods {
  __typename: "FoodType";
  /**
   * Id property
   */
  id: string;
  /**
   * Name of food
   */
  name: string;
  /**
   * Type of food
   */
  type: FoodTypeEnum;
  /**
   * Categories of food
   */
  categories: getBasicFoods_foods_categories[] | null;
}

export interface getBasicFoods {
  foods: (getBasicFoods_foods | null)[] | null;
}
