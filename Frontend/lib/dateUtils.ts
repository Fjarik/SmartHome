import { DateTime } from "luxon";

export const getRelativeDateString = (date: string): string => {
    const d = DateTime.fromISO(date);
    const dateString = d.toRelativeCalendar({ locale: "cz" })
        + " ("
        + d.toLocaleString({ locale: "cz" })
        + ")";

    return dateString.charAt(0).toUpperCase() + dateString.slice(1);
};