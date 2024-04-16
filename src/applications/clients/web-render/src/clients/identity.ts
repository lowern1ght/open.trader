import axios from "axios";
import {withProxy} from "../utilities.ts";
import {IRegisterModel, ILoginModel, IUserInfo} from "../models/identity.ts";

export const identityEndpoints = {
    info: 'api/v1/identity/info',
    login: 'api/v1/identity/login',
    logout: 'api/v1/identity/logout',
    register: 'api/v1/identity/register',
}

export  const fetchUserInfo = async ()  => {
    return (await axios.get<IUserInfo>(withProxy(identityEndpoints.info)))
        .data as IUserInfo | undefined;
}

export  const fetchLogout = async () => {
    return await axios.post(withProxy(identityEndpoints.logout))
}

export  const fetchLogin = async (loginModel: ILoginModel) => {
    return await axios.post(withProxy(identityEndpoints.login), loginModel)
}

export  const fetchRegister = async (registerModel: IRegisterModel) => {
    return await axios.post(withProxy(identityEndpoints.register), registerModel)
}