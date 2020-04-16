import gql from "graphql-tag";

export const getLoggedUser = gql`
  query getLogged {
    logged {
      id
      firstname
      lastname
      createdAt
    }
  }
`;

export const getMealsBasic = gql`
  query getBasicMeals{
    meals {
      id
      date
      type
      time
      food {
        id
        name
      }
      soup {
        id
        name
      }
    }
  }
`;

export const getFoodsBasic = gql`
 query getBasicFoods{
    foods(types: [SOUP, MAIN_MEAL, SIDE_DISH]) {
      id
      name
      type
      sideIds
    }
  }
`;

export const getAllFoods = gql`
  query allFoods {
    foods {
      id
      name
      type
      sideIds
      categoryIds
    }
    categories {
      id
      name
    }
  }
`;