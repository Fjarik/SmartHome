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
}

export interface getBasicFoods_sidedishes {
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

export interface getBasicFoods {
  foods: (getBasicFoods_foods | null)[] | null;
  sidedishes: (getBasicFoods_sidedishes | null)[] | null;
}
