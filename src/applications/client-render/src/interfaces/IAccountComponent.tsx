import {JSX} from "react";

export interface IAccountComponent extends JSX.Element {
    readonly type: "register" | "login"
}