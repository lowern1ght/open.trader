import {ExchangeModel} from "./models/ExchangeModels.ts";
import axios from "axios";

export class ExchangeClient {
    public static async all() : Promise<ExchangeModel[]> {
        let response = await axios.get("/web-api/exchange/");

        if (response.status == 200) {
            return response.data as ExchangeModel[]
        }

        return []
    }

    public static async imageById(id : string) : Promise<string> {
        let response = await axios.get(`/web-api/exchange/${id}/image`)

        if (response.status == 200)
            return response.data

        return ""
    }
}