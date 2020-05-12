import { MealTimeEnum } from "src/graphql/graphql-global-types";

const appUrl = "/app";
const projectsUrl = appUrl + "/projects";
const calendarUrl = projectsUrl + "/calendar";
const mealsUrl = projectsUrl + "/meals";

const accountUrls = {
    loginUrl: "/login",
    accountUrl: "/account",
    get settingsUrl() { return this.accountUrl + "/settings"; },
};

const meals = {
    get mealsIndex() { return mealsUrl; },
    get addMeal() { return mealsUrl + "/addMeal"; },
    get foodsIndex() { return mealsUrl + "/foods"; },
    get addFood() { return mealsUrl + "/foods/addFood"; },
    getAddMeal: (time: MealTimeEnum = MealTimeEnum.LUNCH) => {
        return mealsUrl + "/addMeal?time=" + time.toString();
    },
};

const projectsUrls = {
    calendarUrl: calendarUrl,
    meals: meals,
};

const appUrls = {
    appUrl: appUrl,
    get projects() { return projectsUrl; },
    get settings() { return this.appUrl + "/settings"; },
    projectsUrls: projectsUrls,
};

const customUrls = {
    indexUrl: "/",
    account: accountUrls,
    app: appUrls,
};

export default customUrls;