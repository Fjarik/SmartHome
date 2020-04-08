type EnumType = { [s: number]: string };

export const mapEnum = (enumerable: EnumType, fn: Function): any[] => {
    // get all the members of the enum
    let enumMembers: any[] = Object.keys(enumerable).map(key => enumerable[key]);

    // we are only interested in the numeric identifiers as these represent the values
    let enumValues: number[] = enumMembers.filter(v => typeof v === "string");

    // now map through the enum values
    return enumValues.map(m => fn(m));
};