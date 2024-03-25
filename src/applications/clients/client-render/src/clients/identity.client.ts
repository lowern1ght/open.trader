import axios from "axios";
import {IRegisterModel, IUserLogin} from "../models/Identity.ts";

let proxyWebApi = "/api"

export class IdentityClient {
    public static async LoginAsync(user: IUserLogin) {
        return await axios.post(`${proxyWebApi}/v1/identity/login`, user)
    }

    public static async RegisterAsync(model: IRegisterModel) {
        return await axios.post(`${proxyWebApi}/v1/identity/register`, model)
    }

    public static async UserInfoAsync() {
        return await axios.get(`${proxyWebApi}/v1/identity`, )
    }

    public static async LogoutAsync() {
        return await axios.post(`${proxyWebApi}/v1/identity/logout`)
    }
}