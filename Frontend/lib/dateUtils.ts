import { DateTime } from "luxon";
import { capitalize } from "lodash";

export const getRelativeDateString = (date: string): string => {
    const d = DateTime.fromISO(date);
    const now = DateTime.local();

    const i = d >= now ? d.diffNow("days") : now.diff(d, "days");
    const days = Math.abs(i.days);
    if (days > 2) {
        const r = d.setLocale("cz").toFormat("ccc DDD");
        return capitalize(r);
    }

    const dateString = d.toRelativeCalendar({ locale: "cz" })
        + " ("
        + d.toLocaleString({ locale: "cz" })
        + ")";

    return capitalize(dateString);
};