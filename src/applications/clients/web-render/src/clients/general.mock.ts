import axios from "axios";
import {withProxy} from "../utilities.ts";
import MockAdapter from "axios-mock-adapter";
import {IUserInfo} from "../models/identity.ts";
import {identityEndpoints} from "./identity.ts";
import {IExchange} from "../models/exchange.ts";
import {exchangeEndpoints} from "./exchange.ts";

const mockUserInfo : IUserInfo = {
    username: 'lowern1ght',
    email: 'lowern1ght@yahoo.com',
    id: 'DAQlVqDHD7UGXfYLWws1N',
}

const mockListExchange : IExchange[] = [
    {
        id: '01',
        title: 'Deribit',
        internalName: 'deribit',
        baseUrl: 'www.deribit.com',
    } as IExchange,
    {
        id: '02',
        title: 'Test Deribit',
        internalName: 'test-deribit',
        baseUrl: 'test.deribit.com',
    } as IExchange
]

export function initializeMock() {
    const mock = new MockAdapter(axios, { delayResponse: 3500 });

    mock.onGet(withProxy(identityEndpoints.info))
        .reply( 200, mockUserInfo)

    /*mock.onGet(withProxy(identityEndpoints.info))
        .networkError()
        //.reply( 500, { message: 'ops...' })*/

    mock.onPost(withProxy(identityEndpoints.login))
        .reply(200)
    
    mock.onPost(withProxy(identityEndpoints.logout))
        .reply(200)
    
    mock.onPost(withProxy(identityEndpoints.register))
        .reply( (config) => {
            console.log(config.url)
            return [201, { message: 'Successfully register' }]
        })

    mock.onGet(withProxy(exchangeEndpoints.list))
        .reply(200, mockListExchange)
}