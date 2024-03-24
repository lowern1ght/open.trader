import {JSX} from "react";
import useSWR, {SWRResponse} from "swr";
import {ExchangeModel} from "../clients/models/ExchangeModels.ts";
import {IRegisterModel, IUserInfo, IUserLogin} from "../models/Identity.ts";
import {fetcher, imageExchangeFetcher, loginFetcher} from "../clients/clientFetcher.tsx";

export var webApiProxy = "web-api"

/* Identity */
export function useInfoUser() : SWRResponse<IUserInfo, Error> {
    return useSWR(fetcher(`${webApiProxy}/identity`, null, "GET"))
}

export function useLogoutUser() : SWRResponse {
    return useSWR(fetcher(`${webApiProxy}/identity/logout`, null, "POST"))
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