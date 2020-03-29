import gql from "graphql-tag";

export const loginMutation = gql`
mutation login($googleToken: String!) {
    login(googleToken:$googleToken){
      authToken
    }
}`;
