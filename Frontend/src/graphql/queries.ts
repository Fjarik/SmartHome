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

export const getFoods = gql`
  query getFoods{
    foods {
      name
      type
      categoryIds
      categories {
        name
      }
    }
  }
`;