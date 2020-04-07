import dayjs from "dayjs";
import relative from "dayjs/plugin/relativeTime";
import "dayjs/locale/cs";

const useDate = () => {
    dayjs.locale("cs");
    dayjs.extend(relative);

    return dayjs;
};

export default useDate;