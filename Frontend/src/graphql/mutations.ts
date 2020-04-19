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

export const createFoodMutation = gql`
  mutation createFood(
    $food: FoodInput!
  ) {
    createFood(
      food: $food
    ) {
      id
      name
      type
      sideIds
      categoryIds
    }
  }
`;

export const removeFoodMutation = gql`
  mutation removeFood($id: ID!) {
    removeFood(id: $id)
  }
`;

export const createMealMutation = gql`
  mutation createMeal(
    $date: Date!
    $type: MealTypeEnum!
    $time: MealTimeEnum!
    $foodId: ID
    $sideDishId: ID = null
    $originalMealId: ID = null
    $soupId: ID = null
  ) {
    createMeal(
      meal: {
        foodId: $foodId
        type: $type
        time: $time
        date: $date
        sideDishId: $sideDishId
        originalMealId: $originalMealId
        soupId: $soupId
      }
    ) {
      id
    }
  }
`;

export const updateFoodMutation = gql`
  mutation updateFood($foodId: ID!, $food: FoodInput!) {
    updateFood(foodId: $foodId, food: $food) {
      id
    }
  }
`;