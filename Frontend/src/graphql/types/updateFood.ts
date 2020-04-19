/* tslint:disable */
/* eslint-disable */
// @generated
// This file was automatically generated and should not be edited.

import { FoodInput } from "./../graphql-global-types";

// ====================================================
// GraphQL mutation operation: updateFood
// ====================================================

export interface updateFood_updateFood {
  __typename: "FoodType";
  /**
   * Id property
   */
  id: string;
}

export interface updateFood {
  updateFood: updateFood_updateFood | null;
}

export interface updateFoodVariables {
  foodId: string;
  food: FoodInput;
}
