import gql from "graphql-tag";

export const loginMutation = gql`
  mutation login($googleToken: String!) {
    login(googleToken:$googleToken){
      authToken
      id
      firstname
      lastname
      createdAt
    }
}`;

export const logoutMutation = gql`
  mutation logout($everywhere: Boolean) {
    logout(logoutAll: $everywhere)
}`;