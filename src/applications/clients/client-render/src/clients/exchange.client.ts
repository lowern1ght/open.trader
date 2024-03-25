import axios from "axios";
import {proxy} from "./constants.ts";

export class ExchangeClient {
    public static async listAsync() {
        await axios.get(`${proxy}/exchange`)
    }
    
    public static async imageAsync(exchangeName: string) {
        await axios.get(`${proxy}/exchange/${exchangeName}/image`)
    }
}