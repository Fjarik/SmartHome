const appUrl = "/app";
const projectsUrl = appUrl + "/projects";

const accountUrls = {
    loginUrl: "/login",
    accountUrl: "/account",
    get settingsUrl() { return this.accountUrl + "/settings"; },
};

const projectsUrls = {
    get calendarUrl() { return projectsUrl + "/calendar"; },
    get mealsUrl() { return projectsUrl + "/meals"; },
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