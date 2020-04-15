/* tslint:disable */
/* eslint-disable */
// @generated
// This file was automatically generated and should not be edited.

import { FoodTypeEnum } from "./../graphql-global-types";

// ====================================================
// GraphQL query operation: getBasicFoods
// ====================================================

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
   * Side dish IDs of food
   */
  sideIds: number[] | null;
}

export interface getBasicFoods {
  foods: getBasicFoods_foods[] | null;
}
