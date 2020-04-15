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
}

export interface allFoods_sidedishes {
  __typename: "SideDishType";
  /**
   * Id property
   */
  id: string;
  /**
   * Name of side dish
   */
  name: string;
}

export interface allFoods {
  foods: (allFoods_foods | null)[] | null;
  sidedishes: (allFoods_sidedishes | null)[] | null;
}
