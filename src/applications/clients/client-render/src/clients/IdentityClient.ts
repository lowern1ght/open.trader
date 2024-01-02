import axios, {AxiosRequestConfig} from "axios";
import {IRegisterModel, IUserLogin} from "../models/Identity.ts";

export let axiosConfig : AxiosRequestConfig = { }

export class IdentityClient {
    public static async login(model: IUserLogin)  {
        if (!model.rememberMe) {
            model.rememberMe = false;
        }

        let response = await axios.post("/web-api/identity/login", model, axiosConfig);

        if (response.status == 200)
            axiosConfig.headers = {
                'Authorization' : `Bearer ${response.data.token}`
            }

        return response
    }

    public static async register(model : IRegisterModel) {
        return await axios.post("/web-api/identity/register", model, axiosConfig)
    }

    public static async info() {
        return await axios.get("/web-api/identity", axiosConfig)
    }

    public static async logoutAsync() {
        return await axios.post("/web-api/identity/logout", axiosConfig)
    }

    public static logout() {
        axios.post("/web-api/identity/logout", axiosConfig)
            .catch(response => {
                console.log(response.data)
            })
    }
}

export class IdentityHelper {
    public static async isAuthorize() : Promise<boolean> {
        try {
            return (await IdentityClient.info()).status == 200
        }
        catch {
            return false;
        }
    }
}