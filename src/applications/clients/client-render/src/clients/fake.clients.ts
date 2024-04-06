import axios from "axios";
import {proxy} from "./constants.ts";
import {IUserInfo} from "../models/Identity.ts";
import * as MockAdapter from "axios-mock-adapter";
import {ExchangeModel} from "./models/ExchangeModels.ts";

let mockAxios = new MockAdapter(axios, { delayResponse: 1000 });

interface IMockData {
    identity : { 
        info: IUserInfo 
    }, 
    
    exchange: { 
        list: ExchangeModel[],
        images: Record<string, string>
    } 
}

export const useMockAxios = () => {
    const mockData : IMockData = {
        identity: {

            info: {
                id: "id",
                email: "mock@user.com",
                username: "mock_user"
            }
        },

        exchange: {

            list : [
                {
                    id: '1',
                    title: 'Test Exchange 1',
                    baseUrl: 'test-exchange-1',
                    resourceName: 'test-exchange-1'
                },
                {
                    id: '2',
                    title: 'Test Exchange 2',
                    baseUrl: 'test-exchange-2',
                    resourceName: 'test-exchange-2'
                }
            ],

            images: {
                "test-exchange-1" : "",
                "test-exchange-2" : ""
            }
        }
    }

    mockAxios.onPost(`${proxy}/v1/identity/register`)
        .reply(200)

    mockAxios.onPost(`${proxy}/v1/identity/register`)
        .reply(200);

    mockAxios.onGet(`${proxy}/v1/identity`)
        .reply(200, mockData.identity.info);

    mockAxios.onPost(`${proxy}/v1/identity/logout`)
        .reply(200);

    mockAxios.onGet(`${proxy}/exchange/${mockData.exchange.list[0].resourceName}/image`)
        .reply(300, mockData.exchange.images[0])

    mockAxios.onGet(`${proxy}/exchange/${mockData.exchange.list[1].resourceName}/image`)
        .reply(300, mockData.exchange.images[1])

    mockAxios.onGet(`${proxy}/exchange`)
        .reply(200, mockData.exchange.list)
}