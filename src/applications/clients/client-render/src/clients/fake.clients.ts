import axios from "axios";
import {proxy} from "./constants.ts";
import * as MockAdapter from "axios-mock-adapter";
import {ExchangeModel} from "./models/ExchangeModels.ts";
import {IRegisterModel, IUserInfo, IUserLogin} from "../models/Identity.ts";

let mockAxios = new MockAdapter(axios);

const infoMockData : IUserInfo = {
    id: "id",
    email: "mock@user.com",
    username: "mock_user"
}

export class IdentityClientFake {
    public static async loginAsync(user: IUserLogin) {
        return mockAxios.onPost(`${proxy}/v1/identity/register`, user)
            .reply(200)
    }

    public static async registerAsync(model: IRegisterModel) {
        return mockAxios.onPost(`${proxy}/v1/identity/register`, model)
            .reply(200);
    }

    public static async userInfoAsync() {
        return mockAxios.onGet(`${proxy}/v1/identity`)
            .reply(200, [ infoMockData ]);
    }

    public static async logoutAsync() {
        return mockAxios.onPost(`${proxy}/v1/identity/logout`)
            .reply(200);
    }
}

const exchangesMockData : ExchangeModel[] = [
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
]

export class ExchangeClientFake {
    public static async listAsync() {
        return mockAxios.onGet(`${proxy}/exchange`)
            .reply(200, exchangesMockData)
    }

    public static async imageAsync(exchangeName: string) {
        return mockAxios.onGet(`${proxy}/exchange/${exchangeName}/image`)
            .reply(300, {})
    }
}