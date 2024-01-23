import {JSX} from "react";
import parse from "html-react-parser";
import {webApiProxy} from "./webApiClients.ts";
import axios, {AxiosRequestConfig, AxiosResponse} from "axios";

export let axiosConfig : AxiosRequestConfig = { }

export type RestMethod = 'GET' | 'POST' | 'DELETE' | 'PUT'

export async function fetcher(url : string, data?: any, method?: RestMethod) {
    if (method == null) method = "GET"

    switch (method) {
        case "PUT": {
            return await axios.put(url, data)
        }

        case "POST": {
            return await axios.post(url, data)
        }

        case "DELETE": {
            return await axios.delete(url, data)
        }

        case "GET": {
            return await axios.get(url, data)
        }
    }
}

export async function loginFetcher(url: string, user?: any) {
    const response = await axios.post(url, user)

    if (response.status == 200) {
        axiosConfig.headers = {
            ...axiosConfig.headers,
            'Authorization' : `Bearer ${response.data.token}`
        }
    }

    return response;
}

export async function imageExchangeFetcher(id: string) : Promise<JSX.Element | AxiosResponse> {
    const response = await axios.get(`${webApiProxy}/exchanges/${id}/image`);

    return response.status == 200
        ?   <span style={{width: 'auto', height: 'auto'}}>
                {parse(response.data)}
            </span>
        : response;
}