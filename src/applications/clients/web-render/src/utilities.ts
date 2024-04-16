

// Running this app from develop
import {IUserInfo} from "./models/identity.ts";

const isDevelop = () => {
    return import.meta.env.DEV
}

export const webApiPart = `${import.meta.env.TRADER_PROXY_API_PART}`

// Return url with 'http://proxy/proxy_route/'
const proxyHost = `${import.meta.env.TRADER_PROXY_HOST}/${import.meta.env.TRADER_PROXY_API_PART}`

// Return url with 'http://proxy/proxy_route/$endpoint'
const withProxy = (endpoint: string) => {
    return `${proxyHost}/${endpoint}`
}

export { proxyHost, withProxy, isDevelop }

//Type checker IUserInfo
export function isUser (responseData?: object): responseData is IUserInfo {
    return (responseData as IUserInfo) !== undefined
}

//Convert test-title to Test Title
export const toTitleCase = (str: string) =>
    str.replace (/^[-_]*(.)/, (_, c) => c.toUpperCase())
        .replace (/[-_]+(.)/g, (_, c) => ' ' + c.toUpperCase())

export const openTraderTitle = 'Open Trader'

export const titleWith = (additional: string) => {
    return `${openTraderTitle} - ${toTitleCase(additional)}`
}

export const isAccountRoute = (): boolean => {
    return document?.location?.pathname?.includes('/account/login') ||
        document?.location?.pathname?.includes('/account/register')
}