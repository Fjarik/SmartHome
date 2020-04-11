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
  id: string;
  /**
   * Firstname
   */
  firstname: string;
  /**
   * Lastname
   */
  lastname: string;
  /**
   * Created at
   */
  createdAt: any;
}

export interface getLogged {
  logged: getLogged_logged | null;
}
