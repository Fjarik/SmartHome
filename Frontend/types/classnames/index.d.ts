declare module "classNames" {
    export type ClassValue = string | number | ClassDictionary | ClassArray | undefined | null | false;

    export interface ClassDictionary {
        [id: string]: boolean | undefined | null;
    }

    export interface ClassArray extends Array<ClassValue> { }

    interface ClassNamesFn {
        (...classes: ClassValue[]): string;
    }

    declare const classNames: ClassNamesFn;

    export default classNames;
}