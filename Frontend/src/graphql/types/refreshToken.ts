/* tslint:disable */
/* eslint-disable */
// @generated
// This file was automatically generated and should not be edited.

// ====================================================
// GraphQL mutation operation: refreshToken
// ====================================================

export interface refreshToken_refreshToken {
  __typename: "AuthTokenType";
  /**
   * Refresh token
   */
  refreshToken: string;
}

export interface refreshToken {
  refreshToken: refreshToken_refreshToken | null;
}

export interface refreshTokenVariables {
  refreshToken: string;
}
