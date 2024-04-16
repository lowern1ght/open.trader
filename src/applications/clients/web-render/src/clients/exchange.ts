import axios from "axios";
import {withProxy} from "../utilities.ts";
import {IExchange} from "../models/exchange.ts";

export const exchangeEndpoints = {
    list: 'api/v1/exchanges',
}

export  const fetchExchangesList = async ()  => {
    return (await axios.get<IExchange[]>(withProxy(exchangeEndpoints.list)))
        .data as IExchange[] | undefined;
}