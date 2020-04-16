/* tslint:disable */
/* eslint-disable */
// @generated
// This file was automatically generated and should not be edited.

import { FoodTypeEnum } from "./../graphql-global-types";

// ====================================================
// GraphQL mutation operation: createFood
// ====================================================

export interface createFood_createFood {
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
  /**
   * Category IDs of food
   */
  categoryIds: number[] | null;
}

export interface createFood {
  createFood: createFood_createFood | null;
}

export interface createFoodVariables {
  name: string;
  type: FoodTypeEnum;
  categoryIds?: string[] | null;
  sideIds?: string[] | null;
  glutenFree?: boolean | null;
}
