/* tslint:disable */
/* eslint-disable */
// @generated
// This file was automatically generated and should not be edited.

// ====================================================
// GraphQL query operation: getLogged
// ====================================================

export interface getLogged_logged {
  __typename: "UserType";
  /**
   * Id property
   */
  id: string | null;
  /**
   * Firstname
   */
  firstname: string | null;
  /**
   * Lastname
   */
  lastname: string | null;
  /**
   * Created at
   */
  createdAt: any | null;
}

export interface getLogged {
  logged: getLogged_logged | null;
}
