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
  }
`;

export const logoutMutation = gql`
  mutation logout($everywhere: Boolean) {
    logout(logoutAll: $everywhere)
  }
`;


export const createMealMutation = gql`
  mutation createMeal(
    $foodId: ID!
    $type: MealTypeEnum!
    $date: Date!
    $sideDishId: ID = null
    $originalMealId: ID = null
  ) {
    createMeal(
      meal: {
        foodId: $foodId
        type: $type
        date: $date
        sideDishId: $sideDishId
        originalMealId: $originalMealId
      }
    ) {
      id
    }
  }
`;