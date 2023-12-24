import axios from "axios";
import {IRegisterModel, IUserLogin} from "../models/Identity.ts";

export class IdentityClient {
    public static async login(model: IUserLogin)  {
        return axios.post("/api/identity/login", model)
    }

    public static async register(model : IRegisterModel) {
        return axios.post("/api/identity/register", model)
    }

    public static async info() {
        return axios.get("/api/identity")
    }

    public static async logoutAsync() {
        return await axios.post("/api/identity/logout")
    }

    public static logout() {
        axios.post("/api/identity/logout")
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