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
      food {
        id
        name
      }
    }
  }
`;

export const getFoodsBasic = gql`
 query getBasicFoods{
    foods {
      id
      name
      type
      sideIds
    }
    sidedishes {
      id
      name
    }
  }
`;