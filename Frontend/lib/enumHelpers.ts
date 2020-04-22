import { MealTypeEnum, MealTimeEnum } from "../src/graphql/graphql-global-types";

export const getTypeString = (type: MealTypeEnum): string => {
    switch (type) {
        case MealTypeEnum.FOOD_BOX:
            return "Krabička";
        case MealTypeEnum.GRANDMA:
            return "Babička :)";
        case MealTypeEnum.NORMAL:
            return "Normální jídlo";
        case MealTypeEnum.OTHER:
            return "Ostatní";
        case MealTypeEnum.RESTAURANT:
            return "Restaurace";
        default:
            return "Chyba";
    }
};

export const getTimeString = (type: MealTimeEnum): string => {
    switch (type) {
        case MealTimeEnum.BREAKFAST:
            return "Snídaně";
        case MealTimeEnum.LUNCH:
            return "Oběd";
        case MealTimeEnum.DINNER:
            return "Večeře";
        default:
            return "Chyba";
    }
};