/* tslint:disable */
/* eslint-disable */
// @generated
// This file was automatically generated and should not be edited.

import { MealTypeEnum } from "./../graphql-global-types";

// ====================================================
// GraphQL mutation operation: createMeal
// ====================================================

export interface createMeal_createMeal {
  __typename: "MealType";
  /**
   * Id property
   */
  id: string;
}

export interface createMeal {
  createMeal: createMeal_createMeal | null;
}

export interface createMealVariables {
  foodId: string;
  type: MealTypeEnum;
  date: any;
  sideDishId?: string | null;
  originalMealId?: string | null;
}
