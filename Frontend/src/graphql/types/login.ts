/* tslint:disable */
/* eslint-disable */
// @generated
// This file was automatically generated and should not be edited.

// ====================================================
// GraphQL mutation operation: login
// ====================================================

export interface login_login {
  __typename: "AuthUserType";
  /**
   * Token
   */
  authToken: string | null;
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

export interface login {
  login: login_login | null;
}

export interface loginVariables {
  googleToken: string;
}
