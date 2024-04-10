import axios from "axios";
import {proxy} from "./constants.ts";
import {IRegisterModel, IUserLogin} from "../models/Identity.ts";

export class IdentityClient {
    public static async loginAsync(user: IUserLogin) {
        return await axios.post(`${proxy}/v1/identity/login`, user)
    }

    public static async registerAsync(model: IRegisterModel) {
        return await axios.post(`${proxy}/v1/identity/register`, model)
    }

    public static async userInfoAsync() {
        return await axios.get(`${proxy}/v1/identity`, )
    }

    public static async logoutAsync() {
        return await axios.post(`${proxy}/v1/identity/logout`)
    }
}