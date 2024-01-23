import {JSX} from "react";
import useSWR, {SWRResponse} from "swr";
import {ExchangeModel} from "./models/ExchangeModels.ts";
import {IRegisterModel, IUserInfo, IUserLogin} from "../models/Identity.ts";
import {fetcher, imageExchangeFetcher, loginFetcher} from "./clientFetcher.tsx";

export const webApiProxy = process.env.TRADER_PROXY_WEB_API ?? "web-api"

/* Identity */
export function useInfoUser() : SWRResponse<IUserInfo, Error> {
    return useSWR(fetcher(`${webApiProxy}/identity`, null, "GET"))
}

export function useLoginUser(user: IUserLogin) : SWRResponse<{token: string}, Error> {
    return useSWR(loginFetcher(`${webApiProxy}/identity/login`, user))
}

export function useRegisterUser(user: IRegisterModel) : SWRResponse<Response, Error> {
    return useSWR(fetcher(`${webApiProxy}/identity/register`, user, "POST"))
}

/* Exchanges */
export function useExchanges() : SWRResponse<ExchangeModel[], Error> {
    return useSWR(`${webApiProxy}/exchange`)
}

export function useExchangeImage(id: string) : SWRResponse<JSX.Element, Error>  {
    return useSWR(imageExchangeFetcher(id))
}