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
  authToken: string;
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

export interface login {
  login: login_login | null;
}

export interface loginVariables {
  googleToken: string;
}
