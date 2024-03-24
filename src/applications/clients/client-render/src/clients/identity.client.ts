import axios from "axios";
import {IRegisterModel, IUserLogin} from "../models/Identity.ts";

let proxyWebApi = "/web-api"

export class IdentityClient {
    public static async LoginAsync(user: IUserLogin) {
        return await axios.post(`${proxyWebApi}/identity/login`, user)
    }

    public static async RegisterAsync(user: IRegisterModel) {
        return await axios.post(`${proxyWebApi}/identity/register`, user)
    }

    public static async UserInfoAsync() {
        return await axios.get(`${proxyWebApi}/identity`, )
    }

    public static async LogoutAsync() {
        return await axios.post(`${proxyWebApi}/identity/logout`)
    }
}