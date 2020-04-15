/* tslint:disable */
/* eslint-disable */
// @generated
// This file was automatically generated and should not be edited.

import { FoodTypeEnum } from "./../graphql-global-types";

// ====================================================
// GraphQL query operation: allFoods
// ====================================================

export interface allFoods_foods {
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
   * Side dish IDs of food
   */
  sideIds: number[] | null;
}

export interface allFoods {
  foods: allFoods_foods[] | null;
}
